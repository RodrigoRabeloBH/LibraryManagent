using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LibraryManagement.Models.Branch
{
    public class BranchDetailModel
    {
        public int Id { get; set; }
        public int NumberOfPatrons { get; set; }
        public int NumberOfAssets { get; set; }
        public string PatronId { get; set; }
        public string AssetId { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        [StringLength(30, ErrorMessage = "Limit branch name to 30 characteres.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        public string Address { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Opened Date")]
        [DisplayFormat(DataFormatString = "{0: dd/MM/yyyy}")]
        [Required(ErrorMessage = "{0} is required")]
        public DateTime OpenedDate { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        public string Telephone { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        public string Description { get; set; }
        public string ImageUrl { get; set; }     
        public IFormFile Image { get; set; }
        public decimal TotalAssetsValue { get; set; }
        public string IsOpen { get; set; }
        public IEnumerable<string> HoursOpen { get; set; }
    }
}
