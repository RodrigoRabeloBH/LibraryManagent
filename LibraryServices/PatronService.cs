using LibraryData;
using LibraryData.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace LibraryServices
{
    public class PatronService : IPatron
    {
        private readonly LibraryContext _context;
        public PatronService(LibraryContext context)
        {
            _context = context;
        }
        public void Add(Patron patron)
        {
            _context.Patrons.Add(patron);
            _context.SaveChanges();
        }

        public Patron Get(int id)
        {
            return GetAll().FirstOrDefault(p => p.Id == id);
        }

        public IEnumerable<Patron> GetAll()
        {
            return _context.Patrons
                .Include(p => p.LibraryCard)
                .Include(p => p.HomeLibraryBranch)
                .ToList();
        }

        public IEnumerable<CheckoutHistory> GetCheckoutHistories(int patronId)
        {
            int cardId = Get(patronId).LibraryCard.Id;

            return _context.CheckoutHistories
                .Include(ch => ch.LibraryCard)
                .Include(ch => ch.LibraryAsset)
                .Where(ch => ch.LibraryCard.Id == cardId)
                .OrderByDescending(ch => ch.CheckedOut);
        }

        public IEnumerable<Checkout> GetCheckouts(int patronId)
        {
            int cardId = Get(patronId).LibraryCard.Id;

            return _context.Checkouts
                .Include(ch => ch.LibraryCard)
                .Include(ch => ch.LibraryAsset)
                .Where(ch => ch.LibraryCard.Id == cardId)
                .OrderByDescending(ch => ch.Since);
        }

        public IEnumerable<Hold> GetHolds(int patronId)
        {
            int cardId = Get(patronId).LibraryCard.Id;

            return _context.Holds
                .Include(h => h.LibraryCard)
                .Include(h => h.LibraryAsset)
                .Where(h => h.LibraryCard.Id == cardId)
                .OrderByDescending(h => h.HoldPlaced);
        }
    }
}
