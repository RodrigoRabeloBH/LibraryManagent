using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using LibraryData;
using LibraryData.Models;
using LibraryManagement.Models.Book;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagement.Controllers
{
    public class BookController : Controller
    {
        private readonly IBook _bookService;
        private readonly IBranch _branchService;
        private readonly IHostingEnvironment _env;

        public BookController(IBook bookService, IBranch branchService, IHostingEnvironment env)
        {
            _bookService = bookService;
            _branchService = branchService;
            _env = env;
        }
        public IActionResult Create()
        {
            var branches = _branchService.GetAll();

            var model = new BookDetailModel
            {
                Branches = branches
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult Create(BookDetailModel model)
        {
            if (!ModelState.IsValid) return View(model);
            var branch = _branchService.GetById(model.LibraryBranchId);
            var status = _bookService.GetStatus(2);
            string uniqueName = Guid.NewGuid() + "_" + model.Image.FileName;
            UploadImage(model, uniqueName);
            var book = new Book
            {
                Author = model.Author,
                Cost = Convert.ToDecimal(model.Cost),
                DeweyIndex = model.DeweyIndex,
                ISBN = model.ISBN,
                NumberOfCopies = model.NumberOfCopies,
                Title = model.Title,
                Year = model.Year,
                Location = branch,
                ImageUrl = uniqueName,
                Status = status
            };
            _bookService.Add(book);
            return RedirectToAction("Detail", "Catalog", new { id = book.Id });
        }

        public IActionResult Edit(int id)
        {
            var book = _bookService.Get(id);
            var branches = _branchService.GetAll();
            var model = new BookDetailModel
            {
                Author = book.Author,
                Cost = book.Cost.ToString(),
                DeweyIndex = book.DeweyIndex,
                Id = book.Id,
                ImageUrl = book.ImageUrl,
                ISBN = book.ISBN,
                Location = book.Location,
                NumberOfCopies = book.NumberOfCopies,              
                Title = book.Title,
                LibraryBranchId = book.Location.Id,
                Year = book.Year,
                Branches = branches
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(BookDetailModel model)
        {
            if (!ModelState.IsValid) return View(model);

            var book = _bookService.Get(model.Id);
            var branch = _branchService.GetById(model.LibraryBranchId);
            if (model.Image != null)
            {
                string uniqueName = Guid.NewGuid() + "_" + model.Image.FileName;
                UploadImage(model, uniqueName);
                DeleteImage(model);
                book.ImageUrl = uniqueName;
            }

            book.Id = model.Id;
            book.DeweyIndex = model.DeweyIndex;
            book.Author = model.Author;
            book.Cost = Convert.ToDecimal(model.Cost);
            book.ISBN = model.ISBN;
            book.Location = model.Location;
            book.NumberOfCopies = model.NumberOfCopies;
            book.Title = model.Title;
            book.Location = branch;

            _bookService.Edit(book);
            return RedirectToAction("Detail", "Catalog", new { id = book.Id });
        }

        public IActionResult Delete(int id)
        {
            var book = _bookService.Get(id);
            return View(book);
        }

        [HttpPost]
        public IActionResult Delete(BookDetailModel model)
        {
            var book = _bookService.Get(model.Id);
            DeleteImage(model);
            _bookService.Delete(book);
            return RedirectToAction("Index", "Catalog");
        }
        private void UploadImage(BookDetailModel model, string uniqueName)
        {
            var uploadFolder = Path.Combine(_env.WebRootPath, "Images/assets");
            var path = Path.Combine(uploadFolder, uniqueName);

            if (model.Image != null)
            {
                using (var stream = new FileStream(path, FileMode.OpenOrCreate))
                {
                    model.Image.CopyTo(stream);
                }
            }
        }

        private void DeleteImage(BookDetailModel model)
        {
            var book = _bookService.Get(model.Id);
            var dir = new DirectoryInfo(Path.Combine(_env.WebRootPath, "Images/assets"));
            FileInfo[] files = dir.GetFiles("*", SearchOption.AllDirectories);
            foreach (var image in files) if (image.Name == book.ImageUrl) image.Delete();
        }

    }
}