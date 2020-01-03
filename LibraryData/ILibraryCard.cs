using LibraryData.Models;
using System.Collections.Generic;

namespace LibraryData
{
    public interface ILibraryCard
    {
        void Delete(int id);
        LibraryCard Get(int id);
        IEnumerable<LibraryCard> GetAll();
    }
}
