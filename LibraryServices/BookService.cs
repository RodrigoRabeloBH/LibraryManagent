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
            return _context.Books.Include(b => b.Location).ToList();
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

        public void Delete(int id)
        {
            _context.Books.Remove(Get(id));
        }

        public void Edit(int id)
        {
            _context.Books.Update(Get(id));
        }

        public Status GetStatus(int id)
        {
            return _context.Statuses.FirstOrDefault(s => s.Id == id);
        }
    }
}
