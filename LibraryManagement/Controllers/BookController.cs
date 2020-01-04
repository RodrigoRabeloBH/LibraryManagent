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
                Cost = model.Cost,
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

        public void UploadImage(BookDetailModel model, string uniqueName)
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
    }
}