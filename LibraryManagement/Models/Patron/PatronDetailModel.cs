using LibraryData.Models;
using System;
using System.Collections.Generic;

namespace LibraryManagement.Models.Patron
{
    public class PatronDetailModel
    {
        public int Id { get; set; }
        public int LibraryCardId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName
        {
            get { return FirstName + " " + LastName; }

        }
        public string Address { get; set; }
        public string Telephone { get; set; }
        public string HomeLibraryBranch { get; set; }
        public decimal OverdueFees { get; set; }
        public DateTime MemberSince { get; set; }
        public IEnumerable<Checkout> Checkouts { get; set; }
        public IEnumerable<CheckoutHistory> CheckoutHistories { get; set; }
        public IEnumerable<Hold> Holds { get; set; }
    }
}
