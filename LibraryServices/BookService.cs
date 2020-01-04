using LibraryData;
using LibraryData.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LibraryServices
{
    public class BookService : IBook
    {
        private readonly LibraryContext _context;

        public BookService(LibraryContext context)
        {
            _context = context;
        }
        public IEnumerable<Book> GetAll()
        {
            return _context.Books
                .Include(b => b.Location)
                .Include(b => b.Status)
                .ToList();
        }
        public Book Get(int id)
        {
            return GetAll().FirstOrDefault(b => b.Id == id);
        }
        public void Add(Book book)
        {
            _context.Books.Add(book);
            _context.SaveChanges();
        }

        public void Delete(Book book)
        {
            var hold = _context.Holds.FirstOrDefault(h => h.LibraryAsset.Id == book.Id);
            if (hold != null)
            {
                _context.Holds.Remove(hold);
            }

            _context.Books.Remove(book);
            _context.SaveChanges();
        }

        public void Edit(Book book)
        {
            _context.Books.Update(book);
            _context.SaveChanges();
        }

        public Status GetStatus(int id)
        {
            return _context.Statuses.FirstOrDefault(s => s.Id == id);
        }
    }
}
