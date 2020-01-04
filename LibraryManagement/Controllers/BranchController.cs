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
        private readonly IPatron _patronServices;
        private readonly ILibraryAsset _assetServices;
        private readonly IHostingEnvironment _env;

        public BranchController(IBranch branchServices, IHostingEnvironment env, IPatron patronServices, ILibraryAsset assetsServices)
        {
            _branchServices = branchServices;
            _patronServices = patronServices;
            _assetServices = assetsServices;
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
        public IActionResult Edit(BranchDetailModel branchModel)
        {
            var branch = _branchServices.GetById(branchModel.Id);

            if (!ModelState.IsValid) return View(branchModel);

            branch.Name = branchModel.Name;
            branch.Address = branchModel.Address;
            branch.Telephone = branchModel.Telephone;
            branch.Description = branchModel.Description;
            branch.OpenedDate = branchModel.OpenedDate;

            if (branchModel.Image != null)
            {
                string uniqueName = Guid.NewGuid() + "_" + branchModel.Image.FileName;

                DeleteImage(branchModel);

                UploadImage(branchModel, uniqueName);

                branch.ImageUrl = uniqueName;
            }

            _branchServices.Edit(branch);

            return RedirectToAction("Detail", new { branch.Id });
        }
        public IActionResult Delete(int id)
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
        public IActionResult Delete(BranchDetailModel model)
        {
            DeleteImage(model);

            var branch = _branchServices.GetById(model.Id);

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
            if (!ModelState.IsValid) return View(model);

            string uniqueName = Guid.NewGuid() + "_" + model.Image.FileName;

            UploadImage(model, uniqueName);

            var branch = new LibraryBranch
            {
                Id = model.Id,
                Address = model.Address,
                Description = model.Description,
                Name = model.Name,
                OpenedDate = model.OpenedDate,
                Telephone = model.Telephone,
                ImageUrl = uniqueName
            };

            _branchServices.Add(branch);

            return RedirectToAction("Detail", new { id = branch.Id });
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
            if (ValidatePatron(id, patronId))
            {
                _branchServices.AddPatron(patronId, id);
                return RedirectToAction("Index");
            }
            return RedirectToAction("AddPatron", new { id = id });
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
            if (ValidateAsset(id, assetId))
            {
                _branchServices.AddAsset(assetId, id);
                return RedirectToAction("Index");
            }
            return RedirectToAction("AddAsset", new { id = id });
        }

        private void UploadImage(BranchDetailModel model, string imageName)
        {
            string uploadFolder = Path.Combine(_env.WebRootPath, "Images/branches");
            string path = Path.Combine(uploadFolder, imageName);

            if (model.Image != null)
            {
                using (var stream = new FileStream(path, FileMode.OpenOrCreate))
                {
                    model.Image.CopyTo(stream);
                }
            }
        }

        private void DeleteImage(BranchDetailModel model)
        {
            var branch = _branchServices.GetById(model.Id);

            string folder = Path.Combine(_env.WebRootPath, "Images/branches");

            var directory = new DirectoryInfo(folder);

            FileInfo[] files = directory.GetFiles("*", SearchOption.AllDirectories);

            foreach (var image in files) if (image.Name == branch.ImageUrl) image.Delete();
        }

        private bool ValidatePatron(int id, int patronId)
        {
            var patron = _patronServices.Get(patronId);
            if (patron == null || _branchServices.GetPatrons(id).Any(p => p.Id == patronId)) return false;
            return true;
        }

        private bool ValidateAsset(int id, int assetId)
        {
            var asset = _assetServices.GetById(assetId);
            if (asset == null || _branchServices.GetAssets(id).Any(a => a.Id == assetId)) return false;
            return true;
        }
    }
}