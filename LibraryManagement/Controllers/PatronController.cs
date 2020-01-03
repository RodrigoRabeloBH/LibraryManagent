using LibraryData;
using LibraryData.Models;
using LibraryManagement.Models.Patron;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace LibraryManagement.Controllers
{
    public class PatronController : Controller
    {
        private readonly IPatron _patronService;
        private readonly IHostingEnvironment _env;

        public PatronController(IPatron patronService, IHostingEnvironment env)
        {
            _patronService = patronService;
            _env = env;
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

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(PatronDetailModel model)
        {
            string uniqueName = Guid.NewGuid() + "_" + model.Image.FileName;
            string uploadFolder = Path.Combine(_env.WebRootPath, "Images/patrons");
            string filePath = Path.Combine(uploadFolder, uniqueName);
            string imageUrl = $"/Images/patrons/{uniqueName}";

            if (ModelState.IsValid)
            {
                if (model.Image != null)
                {
                    using (var stream = new FileStream(filePath, FileMode.OpenOrCreate))
                    {
                        model.Image.CopyTo(stream);
                    }
                }

                var patron = new Patron
                {
                    Address = model.Address,
                    DateOfBirth = model.DateOfBirth,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    TelephoneNumber = model.Telephone,
                    ImageUrl = imageUrl
                };

                _patronService.Add(patron);

                return RedirectToAction("Index");
            }

            else
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
                OverdueFees = patron.LibraryCard.Fees,
                ImageUrl = patron.ImageUrl

            };

            return View(model);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var patron = _patronService.Get(id);

            var model = new PatronDetailModel
            {
                Id = patron.Id,
                Address = patron.Address,
                DateOfBirth = patron.DateOfBirth,
                FirstName = patron.FirstName,
                LastName = patron.LastName,
                ImageUrl = patron.ImageUrl,
                Telephone = patron.TelephoneNumber
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(PatronDetailModel model)
        {
            if (!ModelState.IsValid)
            {
                string uniqueName = Guid.NewGuid() + "_" + model.Image.FileName;
                string uploadFolder = Path.Combine(_env.WebRootPath, "Images/patrons");
                string filePath = Path.Combine(uploadFolder, uniqueName);
                string imageUrl = $"/Images/patrons/{uniqueName}";

                if (model.Image != null)
                {
                    using (var stream = new FileStream(filePath, FileMode.OpenOrCreate))
                    {
                        model.Image.CopyTo(stream);
                    }
                }

                var patron = new Patron
                {
                    Id = model.Id,
                    Address = model.Address,
                    TelephoneNumber = model.Telephone,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    DateOfBirth = model.DateOfBirth,
                    ImageUrl = imageUrl
                };

                _patronService.Edit(patron);

                return RedirectToAction("Detail", new { id = patron.Id });
            }
            else
                return View(model);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var model = _patronService.Get(id);
            return View(model);
        }

        [HttpPost]
        public IActionResult Delete(Patron patron)
        {
            _patronService.Delete(patron);
            return RedirectToAction(nameof(Index));
        }
    }
}