using LibraryData.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LibraryManagement.Models.Patron
{
    public class PatronDetailModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        public int LibraryCardId { get; set; }

        [Display(Name = "First Name")]
        [Required(ErrorMessage = "{0} is required")]
        [StringLength(60, MinimumLength = 3, ErrorMessage = " {0} size should be between {2} and {1}")]
        public string FirstName { get; set; }


        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "{0} is required")]
        [StringLength(60, MinimumLength = 3, ErrorMessage = " {0} size should be between {2} and {1}")]
        public string LastName { get; set; }

        public string ImageUrl { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        [Display(Name = "Birth Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0: dd/MM/yyyy}")]
        public DateTime DateOfBirth { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        public IFormFile Image { get; set; }

        public string FullName
        {
            get { return FirstName + " " + LastName; }

        }

     
        [Required(ErrorMessage = "{0} is required")]
        [StringLength(60, MinimumLength = 5, ErrorMessage = " {0} size should be between {2} and {1}")]
        public string Address { get; set; }

        [Required(ErrorMessage = "{0} is required")]    
        public string Telephone { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        public string HomeLibraryBranch { get; set; }

        public decimal OverdueFees { get; set; }

        public DateTime MemberSince { get; set; }

        public IEnumerable<Checkout> Checkouts { get; set; }

        public IEnumerable<CheckoutHistory> CheckoutHistories { get; set; }

        public IEnumerable<Hold> Holds { get; set; }
    }
}
