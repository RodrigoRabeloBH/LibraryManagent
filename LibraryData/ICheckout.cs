using LibraryData.Models;
using System;
using System.Collections.Generic;

namespace LibraryData
{
    public interface ICheckout
    {
        void Add(Checkout checkout);
        void PlaceHold(int assetId, int libraryCardId);
        void CheckOutItem(int assetId, int libraryCardId);
        void CheckInItem(int assetId);
        void MarkLost(int assetId);
        void MarkFound(int assetId);
        string GetCurrentHoldPatronName(int id);
        string GetCurrentCheckoutPatron(int assetId);
        bool IsCheckedOut(int assetId);
        IEnumerable<CheckoutHistory> GetCheckoutHistory(int id);
        IEnumerable<Checkout> GetAll();
        IEnumerable<Hold> GetCurrentHolds(int id);
        DateTime GetCurrentHoldPlaced(int id);
        Checkout GetById(int id);
        Checkout GetLatestCheckout(int assetId);
    }
}
