using LibraryData.Models;
using System.Collections.Generic;

namespace LibraryData
{
    public interface IBranch
    {
        void Add(LibraryBranch branch);
        void Delete(LibraryBranch branch);
        void Edit(LibraryBranch branch);
        void AddPatron(int patronId, int branchId);
        void AddAsset(int assetId, int branchId);
        string IsBranchOpen(int branchId);
        LibraryBranch GetById(int branchId);
        IEnumerable<LibraryBranch> GetAll();
        IEnumerable<LibraryAsset> GetAssets(int branchId);
        IEnumerable<Patron> GetPatrons(int branchId);
        IEnumerable<string> GetBranchHours(int branchId);
    }
}
