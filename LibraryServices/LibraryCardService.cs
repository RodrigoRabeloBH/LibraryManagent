using LibraryData;
using LibraryData.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LibraryServices
{
    public class LibraryCardService : ILibraryCard
    {
        private readonly LibraryContext _context;

        public LibraryCardService(LibraryContext context)
        {
            _context = context;
        }
        public IEnumerable<LibraryCard> GetAll()
        {
            return _context.LibraryCards.Include(l => l.Checkouts).ToList();
        }

        public LibraryCard Get(int id)
        {
            return GetAll().FirstOrDefault(l => l.Id == id);
        }
        public void Delete(int id)
        {
            var libraryCard = Get(id);              
            _context.LibraryCards.Remove(libraryCard);
        }
    }
}
