using LibraryData.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryData
{
    public interface IBook
    {
        void Add(Book book);
        void Edit(int id);
        void Delete(int id);
        Book Get(int id);
        Status GetStatus(int id);
        IEnumerable<Book> GetAll();
    }
}
