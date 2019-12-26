using LibraryData;
using LibraryData.Models;
using LibraryManagement.Models.Patron;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace LibraryManagement.Controllers
{
    public class PatronController : Controller
    {
        private readonly IPatron _patronService;

        public PatronController(IPatron patronService)
        {
            _patronService = patronService;
        }
        public IActionResult Index()
        {
            var listPatrons = _patronService.GetAll();

            var patronModel = listPatrons.Select(p => new PatronDetailModel
            {
                Id = p.Id,
                FirstName = p.FirstName,
                LastName = p.LastName,
                LibraryCardId = p.LibraryCard.Id,
                HomeLibraryBranch = p.HomeLibraryBranch.Name,
                OverdueFees = p.LibraryCard.Fees
            }).ToList();

            var model = new PatronIndexModel
            {
                Patrons = patronModel
            };

            return View(model);
        }
        public IActionResult Detail(int id)
        {
            var patron = _patronService.Get(id);

            var model = new PatronDetailModel
            {
                Id = id,
                Address = patron.Address,
                FirstName = patron.FirstName,
                LastName = patron.LastName,
                CheckoutHistories = _patronService.GetCheckoutHistories(id),
                Checkouts = _patronService.GetCheckouts(id).ToList() ?? new List<Checkout>(),
                Holds = _patronService.GetHolds(id),
                HomeLibraryBranch = patron.HomeLibraryBranch.Name,
                LibraryCardId = patron.LibraryCard.Id,
                Telephone = patron.TelephoneNumber,
                MemberSince = patron.LibraryCard.Created,
                OverdueFees = patron.LibraryCard.Fees                                
            };

            return View(model);
        }
    }
}