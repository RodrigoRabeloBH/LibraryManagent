using LibraryData;
using LibraryManagement.Models.Catalog;
using LibraryManagement.Models.CheckoutModels;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace LibraryManagement.Controllers
{
    public class CatalogController : Controller
    {
        private readonly ILibraryAsset _assetServices;
        private readonly ICheckout _checkoutServices;
        private readonly ILibraryCard _cardServices;
        public CatalogController(ILibraryAsset assetServices, ICheckout checkoutServices, ILibraryCard cardServices)
        {
            _assetServices = assetServices;
            _checkoutServices = checkoutServices;
            _cardServices = cardServices;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var listAssets = _assetServices.GetAll();
            var listingResult = listAssets
                .Select(result => new AssetIndexListModel
                {
                    Id = result.Id,
                    ImageUrl = result.ImageUrl,
                    AuthorOrDirector = _assetServices.GetAuthorOrDirector(result.Id),
                    DeweyCallNumber = _assetServices.GetDeweyIndex(result.Id),
                    Type = _assetServices.GetType(result.Id),
                    Title = result.Title,
                    NumberOfCopies = result.NumberOfCopies
                });
            var model = new AssetIndexModel()
            {
                Assets = listingResult
            };
            return View(model);
        }

        public IActionResult Detail(int id)
        {
            var asset = _assetServices.GetById(id);

            var curreantHolds = _checkoutServices.GetCurrentHolds(id)
                .Select(a => new AssetHoldModel
                {
                    HoldPlaced = _checkoutServices.GetCurrentHoldPlaced(a.Id).ToString("d"),
                    PatronName = _checkoutServices.GetCurrentHoldPatronName(a.Id)
                });

            var model = new AssetDetailModel
            {
                AssetId = asset.Id,
                Title = asset.Title,
                Type = _assetServices.GetType(id),
                Year = asset.Year,
                Cost = asset.Cost,
                Status = asset.Status.Name,
                ImageUrl = asset.ImageUrl,
                AuthorOrDirector = _assetServices.GetAuthorOrDirector(id),
                DeweyCallNumber = _assetServices.GetDeweyIndex(id),
                CheckoutHistory = _checkoutServices.GetCheckoutHistory(id),
                CurrentHolds = curreantHolds,
                CurrentLocation = asset.Location.Name,
                ISBN = _assetServices.GetIsbn(id),
                PatronName = _checkoutServices.GetCurrentCheckoutPatron(asset.Id)
            };
            return View(model);
        }

        public IActionResult Checkout(int id)
        {
            var asset = _assetServices.GetById(id);

            var model = new CheckoutModel
            {
                AssetId = id,
                ImageUrl = asset.ImageUrl,
                Title = asset.Title,
                IsCheckedOut = _checkoutServices.IsCheckedOut(id),
                LibraryCardId = ""
            };
            return View(model);
        }

        public IActionResult CheckIn(int id)
        {
            _checkoutServices.CheckInItem(id);
            return RedirectToAction("Detail", new { id });
        }

        public IActionResult MarkLost(int assetId)
        {
            _checkoutServices.MarkLost(assetId);
            return RedirectToAction("Detail", new { id = assetId });
        }

        public IActionResult MarkFound(int assetId)
        {
            _checkoutServices.MarkFound(assetId);
            return RedirectToAction("Detail", new { id = assetId });
        }

        public IActionResult Hold(int id)
        {
            var asset = _assetServices.GetById(id);

            var model = new CheckoutModel
            {
                AssetId = asset.Id,
                ImageUrl = asset.ImageUrl,
                Title = asset.Title,
                LibraryCardId = "",
                IsCheckedOut = _checkoutServices.IsCheckedOut(id),
                HoldCount = _checkoutServices.GetCurrentHolds(id).Count()
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult PlaceCheckout(int assetId, int libraryCardId)
        {
            if (ValidateLibraryCard(libraryCardId))
            {
                _checkoutServices.CheckOutItem(assetId, libraryCardId);
                return RedirectToAction("Detail", new { id = assetId });
            }

            return RedirectToAction("Checkout", new { id = assetId });
        }

        [HttpPost]
        public IActionResult PlaceHold(int assetId, int libraryCardId)
        {
            if (ValidateLibraryCard(libraryCardId))
            {
                _checkoutServices.PlaceHold(assetId, libraryCardId);
                return RedirectToAction("Detail", new { id = assetId });
            }
            return RedirectToAction("Hold", new { id = assetId });
        }

        private bool ValidateLibraryCard(int libraryCardId)
        {
            var libraryCard = _cardServices.Get(libraryCardId);

            if (libraryCard != null) return true;

            return false;
        }
    }
}
