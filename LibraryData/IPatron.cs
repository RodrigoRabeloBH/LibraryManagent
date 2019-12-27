using LibraryData.Models;
using System.Collections.Generic;

namespace LibraryData
{
    public interface IPatron
    {
        void Add(Patron patron);
        void Edit(Patron patron);
        void Delete(Patron patron);
        Patron Get(int id);       
        IEnumerable<Patron> GetAll();
        IEnumerable<Checkout> GetCheckouts(int patronId);
        IEnumerable<CheckoutHistory> GetCheckoutHistories(int patronId);
        IEnumerable<Hold> GetHolds(int patronId);
    }
}
