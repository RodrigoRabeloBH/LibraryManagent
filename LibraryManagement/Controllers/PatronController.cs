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
        private readonly IBranch _branchService;

        public PatronController(IPatron patronService, IHostingEnvironment env, IBranch branchService)
        {
            _patronService = patronService;
            _env = env;
            _branchService = branchService;
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
            var branches = _branchService.GetAll();

            var model = new PatronDetailModel { Branches = branches };

            return View(model);
        }

        [HttpPost]
        public IActionResult Create(PatronDetailModel model)
        {
            if (!ModelState.IsValid) return View(model);

            var libraryCard = new LibraryCard();

            var branch = _branchService.GetById(model.LibraryBranchId);

            string uniqueName = Guid.NewGuid() + "_" + model.Image.FileName;

            UploadImage(model, uniqueName);

            var patron = new Patron
            {
                Address = model.Address,
                DateOfBirth = model.DateOfBirth,
                FirstName = model.FirstName,
                ImageUrl = uniqueName,
                LastName = model.LastName,
                TelephoneNumber = model.Telephone,
                HomeLibraryBranch = branch,
                LibraryCard = libraryCard
            };
            _patronService.Add(patron);
            return RedirectToAction("Index");
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
            if (!ModelState.IsValid) return View(model);

            var patron = _patronService.Get(model.Id);

            if (model.Image != null)
            {
                string uniqueName = Guid.NewGuid() + "_" + model.Image.FileName;
                DeleteImage(model);
                UploadImage(model, uniqueName);
                patron.ImageUrl = uniqueName;
            }

            patron.Id = model.Id;
            patron.FirstName = model.FirstName;
            patron.LastName = model.LastName;
            patron.Address = model.Address;
            patron.DateOfBirth = model.DateOfBirth;
            patron.TelephoneNumber = model.Telephone;

            _patronService.Edit(patron);

            return RedirectToAction("Detail", new { id = patron.Id });
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var model = _patronService.Get(id);
            return View(model);
        }

        [HttpPost]
        public IActionResult Delete(PatronDetailModel model)
        {
            DeleteImage(model);
            var patron = _patronService.Get(model.Id);
            _patronService.Delete(patron);
            return RedirectToAction(nameof(Index));
        }

        private void UploadImage(PatronDetailModel model, string uniqueName)
        {
            string uploadFolder = Path.Combine(_env.WebRootPath, "Images/patrons");
            string path = Path.Combine(uploadFolder, uniqueName);

            if (model.Image != null)
            {
                using (var stream = new FileStream(path, FileMode.OpenOrCreate))
                {
                    model.Image.CopyTo(stream);
                }
            }
        }

        private void DeleteImage(PatronDetailModel model)
        {
            var patron = _patronService.Get(model.Id);
            var folder = Path.Combine(_env.WebRootPath, "Images/patrons");
            var directory = new DirectoryInfo(folder);
            FileInfo[] files = directory.GetFiles("*", SearchOption.AllDirectories);
            foreach (var image in files) if (image.Name == patron.ImageUrl) image.Delete();
        }
    }
}