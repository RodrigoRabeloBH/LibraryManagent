using LibraryData;
using LibraryData.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LibraryServices
{
    public class CheckoutService : ICheckout
    {
        private readonly LibraryContext _context;
        public CheckoutService(LibraryContext context)
        {
            _context = context;
        }
        public void Add(Checkout checkout)
        {
            _context.Checkouts.Add(checkout);
            _context.SaveChanges();
        }
        public IEnumerable<Checkout> GetAll()
        {
            return _context.Checkouts.AsNoTracking().ToList();
        }
        public Checkout GetById(int id)
        {
            return GetAll().FirstOrDefault(ch => ch.Id == id);
        }
        public IEnumerable<CheckoutHistory> GetCheckoutHistory(int id)
        {
            return _context.CheckoutHistories
                .Include(h => h.LibraryAsset)
                .Include(h => h.LibraryCard)
                .Where(h => h.LibraryAsset.Id == id);
        }
        public IEnumerable<Hold> GetCurrentHolds(int id)
        {
            return _context.Holds
                .Include(h => h.LibraryAsset)
                .Where(h => h.LibraryAsset.Id == id);
        }
        public Checkout GetLatestCheckout(int assetId)
        {
            return _context.Checkouts
                .Where(ch => ch.LibraryAsset.Id == assetId)
                .OrderByDescending(ch => ch.Since)
                .FirstOrDefault();
        }
        public void MarkFound(int assetId)
        {
            var now = DateTime.Now;
            UpdateAssetStatus(assetId, "Available");
            // remove any existing checkouts on the item
            RemoveExistingCheckouts(assetId);
            // close any existing checkout history
            CloseExistingCheckoutHistory(assetId, now);
            _context.SaveChanges();
        }
        public void MarkLost(int assetId)
        {
            UpdateAssetStatus(assetId, "Lost");
            _context.SaveChanges();
        }
        public void PlaceHold(int assetId, int libraryCardId)
        {
            var now = DateTime.Now;

            var asset = _context.LibraryAssets
                .Include(a => a.Status)
                .FirstOrDefault(a => a.Id == assetId);

            var card = _context.LibraryCards.FirstOrDefault(c => c.Id == libraryCardId);

            if (asset.Status.Name == "Available")
            {
                UpdateAssetStatus(assetId, "On Hold");
            }
            else
            {
                var hold = new Hold
                {
                    HoldPlaced = now,
                    LibraryAsset = asset,
                    LibraryCard = card
                };
                _context.Holds.Add(hold);
            }
            _context.SaveChanges();
        }
        public void CheckInItem(int assetId)
        {
            var now = DateTime.Now;

            var item = _context.LibraryAssets
                .FirstOrDefault(a => a.Id == assetId);

            // remove any existing checkouts on the item
            RemoveExistingCheckouts(assetId);

            // close any existing checkout history
            CloseExistingCheckoutHistory(assetId, now);

            // look for current holds
            var currentHolds = _context.Holds
                .Include(a => a.LibraryAsset)
                .Include(a => a.LibraryCard)
                .Where(a => a.LibraryAsset.Id == assetId);

            // if there are current holds, check out the item to the earliest
            if (currentHolds.Any())
            {
                CheckoutToEarliestHold(assetId, currentHolds);
                return;
            }

            // otherwise, set item status to available
            UpdateAssetStatus(assetId, "Available");

            _context.SaveChanges();
        }
        public void CheckOutItem(int assetId, int libraryCardId)
        {
            var now = DateTime.Now;

            var item = _context.LibraryAssets
                .Include(a => a.Status)
                .FirstOrDefault(asset => asset.Id == assetId);

            UpdateAssetStatus(assetId, "Checked Out");

            var libraryCard = _context.LibraryCards
                .Include(card => card.Checkouts)
                .FirstOrDefault(card => card.Id == libraryCardId);

            var checkout = new Checkout
            {
                LibraryAsset = item,
                LibraryCard = libraryCard,
                Since = now,
                Until = GetDefaultCheckoutTime(now)
            };

            _context.Checkouts.Add(checkout);

            var checkoutHistory = new CheckoutHistory
            {
                CheckedOut = now,
                LibraryAsset = item,
                LibraryCard = libraryCard
            };
            _context.CheckoutHistories.Add(checkoutHistory);

            _context.SaveChanges();
        }
        public string GetCurrentHoldPatronName(int holdId)
        {
            var hold = _context.Holds
                .Include(h => h.LibraryCard)
                .Include(h => h.LibraryAsset)
                .FirstOrDefault(h => h.Id == holdId);

            var cardId = hold?.LibraryCard.Id;

            var patron = _context.Patrons
                .Include(p => p.LibraryCard)
                .FirstOrDefault(p => p.LibraryCard.Id == cardId);

            return patron?.FirstName + " " + patron?.LastName;

        }
        public string GetCurrentCheckoutPatron(int assetId)
        {
            var checkout = GetCheckoutByAssetId(assetId);

            if (checkout == null)
            {
                return "Not Check Out!";
            }
            else
            {
                var cardId = checkout.LibraryCard.Id;
                var patron = _context.Patrons.FirstOrDefault(p => p.LibraryCard.Id == cardId);
                return patron.FirstName + " " + patron.LastName;
            }
        }
        public DateTime GetCurrentHoldPlaced(int holdId)
        {
            return _context.Holds
             .Include(h => h.LibraryCard)
             .Include(h => h.LibraryAsset)
             .FirstOrDefault(h => h.Id == holdId)
             .HoldPlaced;
        }
        private void RemoveExistingCheckouts(int assetId)
        {
            var checkout = _context.Checkouts
                .Include(ch => ch.LibraryAsset)
                .Include(ch => ch.LibraryCard)
                .FirstOrDefault(ch => ch.LibraryAsset.Id == assetId);

            if (checkout != null)
            {
                _context.Remove(checkout);
            }
        }
        private void CloseExistingCheckoutHistory(int assetId, DateTime now)
        {
            var history = _context.CheckoutHistories
                .FirstOrDefault(h => h.LibraryAsset.Id == assetId && h.CheckedIn == null);

            if (history != null)
            {
                _context.Update(history);
                history.CheckedIn = now;
            }
        }
        private void UpdateAssetStatus(int assetId, string v)
        {
            var item = _context.LibraryAssets
                .FirstOrDefault(asset => asset.Id == assetId);
            _context.Update(item);
            item.Status = _context.Statuses.FirstOrDefault(status => status.Name == v);
        }
        private void CheckoutToEarliestHold(int assetId, IEnumerable<Hold> currentHolds)
        {
            var earliestHold = currentHolds.OrderBy(a => a.HoldPlaced).FirstOrDefault();
            if (earliestHold == null) return;
            var card = earliestHold.LibraryCard;
            _context.Remove(earliestHold);
            _context.SaveChanges();

            CheckOutItem(assetId, card.Id);
        }
        private DateTime GetDefaultCheckoutTime(DateTime now)
        {
            return now.AddDays(30);
        }
        public bool IsCheckedOut(int assetId)
        {
            return _context.Checkouts
                .Where(ch => ch.LibraryAsset.Id == assetId)
                .Any();
        }
        private Checkout GetCheckoutByAssetId(int assetId)
        {
            return _context.Checkouts
                .Include(ch => ch.LibraryAsset)
                .Include(ch => ch.LibraryCard)
                .FirstOrDefault(ch => ch.LibraryAsset.Id == assetId);
        }
    }
}
