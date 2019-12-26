using System;
using System.IO;
using System.Linq;
using LibraryData;
using LibraryData.Models;
using LibraryManagement.Models.Branch;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagement.Controllers
{
    public class BranchController : Controller
    {
        private readonly IBranch _branchServices;
        private readonly IHostingEnvironment _env;

        public BranchController(IBranch branchServices, IHostingEnvironment env)
        {
            _branchServices = branchServices;
            _env = env;
        }

        public IActionResult Index()
        {
            var branches = _branchServices.GetAll().Select(b => new BranchDetailModel
            {
                Id = b.Id,
                Name = b.Name,
                //IsOpen = _branchServices.IsBranchOpen(b.Id),
                NumberOfAssets = _branchServices.GetAssets(b.Id).Count(),
                NumberOfPatrons = _branchServices.GetPatrons(b.Id).Count(),
            });

            var model = new BranchIndexModel
            {
                Branches = branches
            };
            return View(model);
        }

        public IActionResult Detail(int id)
        {
            var branch = _branchServices.GetById(id);

            var model = new BranchDetailModel
            {
                Id = branch.Id,
                Name = branch.Name,
                //IsOpen = _branchServices.IsBranchOpen(id),
                NumberOfAssets = _branchServices.GetAssets(id).Count(),
                NumberOfPatrons = _branchServices.GetPatrons(id).Count(),
                Description = branch.Description,
                ImageUrl = branch.ImageUrl,
                Address = branch.Address,
                Telephone = branch.Telephone,
                OpenedDate = branch.OpenedDate,
                HoursOpen = _branchServices.GetBranchHours(id),
                TotalAssetsValue = _branchServices.GetAssets(id).Sum(a => a.Cost)
            };

            return View(model);
        }

        public IActionResult Edit(int id)
        {
            var branch = _branchServices.GetById(id);

            var model = new BranchDetailModel
            {
                Id = branch.Id,
                Address = branch.Address,
                Description = branch.Description,
                Name = branch.Name,
                OpenedDate = branch.OpenedDate,
                Telephone = branch.Telephone,
                ImageUrl = branch.ImageUrl
            };

            return View(model);
        }
        [HttpPost]
        public IActionResult Edit(BranchDetailModel model)
        {

            string uniqueName = Guid.NewGuid() + "_" + model.Image.FileName;
            string uploadFolder = Path.Combine(_env.WebRootPath, "Images/branches");
            string filePath = Path.Combine(uploadFolder, uniqueName);
            string imageUrl = $"/Images/branches/{uniqueName}";

            using (var stream = new FileStream(filePath, FileMode.OpenOrCreate))
            {
                model.Image.CopyTo(stream);
            }

            if (model != null)
            {
                var branch = new LibraryBranch
                {
                    Id = model.Id,
                    Address = model.Address,
                    Description = model.Description,
                    Name = model.Name,
                    OpenedDate = model.OpenedDate,
                    Telephone = model.Telephone,
                    ImageUrl = imageUrl
                };
                _branchServices.Edit(branch);
                return RedirectToAction("Index", new { branch.Id });
            }
            else
                return View(model);
        }
        public IActionResult Delete(int id)
        {
            var branch = _branchServices.GetById(id);
            return View(branch);
        }

        [HttpPost]
        public IActionResult Delete(LibraryBranch branch)
        {
            _branchServices.Delete(branch);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(BranchDetailModel model)
        {
            string uniqueName = Guid.NewGuid() + "_" + model.Image.FileName;
            string uploadFolder = Path.Combine(_env.WebRootPath, "Images/branches");
            string filePath = Path.Combine(uploadFolder, uniqueName);
            string imageUrl = $"/Images/branches/{uniqueName}";

            using (var stream = new FileStream(filePath, FileMode.OpenOrCreate))
            {
                model.Image.CopyTo(stream);
            }

            if (model != null)
            {
                var branch = new LibraryBranch
                {
                    Id = model.Id,
                    Address = model.Address,
                    Description = model.Description,
                    Name = model.Name,
                    OpenedDate = model.OpenedDate,
                    Telephone = model.Telephone,
                    ImageUrl = imageUrl
                };

                _branchServices.Add(branch);
                return RedirectToAction("Detail", new { id = branch.Id });
            }

            else
                return View(model);
        }

        [HttpGet]
        public IActionResult AddPatron(int id)
        {
            var branch = _branchServices.GetById(id);

            var model = new BranchDetailModel
            {
                Id = branch.Id,
                Address = branch.Address,
                Description = branch.Description,
                Name = branch.Name,
                ImageUrl = branch.ImageUrl,
                AssetId = "",
                PatronId = ""
            };
            return View(model);
        }
        [HttpPost]
        public IActionResult AddPatron(int patronId, int id)
        {
            _branchServices.AddPatron(patronId, id);
            return RedirectToAction("Detail", new { id = id });
        }

        [HttpGet]
        public IActionResult AddAsset(int id)
        {
            var branch = _branchServices.GetById(id);

            var model = new BranchDetailModel
            {
                Id = branch.Id,
                Address = branch.Address,
                Description = branch.Description,
                Name = branch.Name,
                ImageUrl = branch.ImageUrl,
                AssetId = "",
                PatronId = ""
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult AddAsset(int id, int assetId)
        {
            _branchServices.AddAsset(assetId, id);
            return RedirectToAction("Detail", new { id = id });
        }
    }
}