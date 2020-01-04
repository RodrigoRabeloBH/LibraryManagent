using LibraryData.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LibraryManagement.Models.Book
{
    public class BookDetailModel
    {
        public int Id { get; set; }
        public int LibraryBranchId { get; set; }

        public int StatusId { get; set; }

        [Required(ErrorMessage = "{0} is required!")]
        [StringLength(60, MinimumLength = 3, ErrorMessage = "{0} must be between {2} and {1} characters")]
        public string Title { get; set; }

        [Required(ErrorMessage = "{0} is required!")]
        [StringLength(60, MinimumLength = 3, ErrorMessage = "{0} must be between {2} and {1} characters")]
        public string Author { get; set; }

        [Required(ErrorMessage = "{0} is required!")]
        public int NumberOfCopies { get; set; }

        [Required(ErrorMessage = "{0} is required!")]
        public string ISBN { get; set; }

        public int Year { get; set; }
        public string DeweyIndex { get; set; }
        public decimal Cost { get; set; }
        public string ImageUrl { get; set; }
        public IFormFile Image { get; set; }
        public LibraryBranch Location { get; set; }
        public IEnumerable<LibraryBranch> Branches { get; set; }
    }
}
