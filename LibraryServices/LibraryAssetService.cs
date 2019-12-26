using LibraryData;
using LibraryData.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace LibraryServices
{
    public class LibraryAssetService : ILibraryAsset
    {
        private readonly LibraryContext _context;
        public LibraryAssetService(LibraryContext context)
        {
            _context = context;
        }
        public void Add(LibraryAsset newAsset)
        {
            _context.LibraryAssets.Add(newAsset);
            _context.SaveChanges();
        }
        public IEnumerable<LibraryAsset> GetAll()
        {
            return _context.LibraryAssets
                .AsNoTracking()
                .Include(asset => asset.Status)
                .Include(asset => asset.Location)
                .ToList();
        }
        public LibraryAsset GetById(int id)
        {
            return _context.LibraryAssets
                .AsNoTracking()
                .Include(asset => asset.Location)
                .Include(asset => asset.Status)
                .Where(asset => asset.Id == id)
                .FirstOrDefault();
        }
        public LibraryBranch GetCurrentLocation(int id)
        {
            var asset = _context.LibraryAssets
                .AsNoTracking()
                .FirstOrDefault(a => a.Id == id);
            return asset.Location;
        }
        public string GetDeweyIndex(int id)
        {
            var book = _context.Books.AsNoTracking().FirstOrDefault(b => b.Id == id);
            if (book != null)
            {
                return book.DeweyIndex;
            }
            else
                return "";
        }
        public string GetIsbn(int id)
        {
            var book = _context.Books.AsNoTracking().FirstOrDefault(b => b.Id == id);
            if (book != null)
            {
                return book.ISBN;
            }
            else
                return "";
        }
        public string GetTitle(int id)
        {
            var book = _context.Books.AsNoTracking().FirstOrDefault(b => b.Id == id);
            if (book != null)
            {
                return book.Title;
            }
            else
                return "";
        }
        public string GetType(int id)
        {
            var book = _context.LibraryAssets.OfType<Book>().Where(b => b.Id == id);
            return book.Any() ? "Book" : "Video";
        }
        public string GetAuthorOrDirector(int id)
        {
            var isBook = _context.LibraryAssets.OfType<Book>().Where(a => a.Id == id).Any();
            if (isBook)
            {
                var book = _context.Books.AsNoTracking().FirstOrDefault(b => b.Id == id);
                return book.Author;
            }
            else
            {
                var video = _context.Videos.AsNoTracking().FirstOrDefault(v => v.Id == id);
                return video.Director;
            }
        }
    }
}
