using LibraryData;
using LibraryData.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LibraryServices
{
    public class BranchService : IBranch
    {
        private readonly LibraryContext _context;

        public BranchService(LibraryContext context)
        {
            _context = context;
        }

        public IEnumerable<LibraryBranch> GetAll()
        {
            return _context.LibraryBranches
                .Include(b => b.LibraryAssets)
                .Include(b => b.Patrons)
                .ToList();
        }

        public LibraryBranch GetById(int branchId)
        {
            return GetAll().FirstOrDefault(b => b.Id == branchId);
        }

        public void Add(LibraryBranch branch)
        {
            _context.LibraryBranches.Add(branch);
            _context.SaveChanges();
        }

        public void Delete(LibraryBranch branch)
        {
            _context.LibraryBranches.Remove(branch);
            _context.SaveChanges();
        }

        public void Edit(LibraryBranch branch)
        {
            _context.LibraryBranches.Update(branch);
            _context.SaveChanges();
        }


        public IEnumerable<LibraryAsset> GetAssets(int branchId)
        {
            return _context.LibraryBranches
                .Include(b => b.LibraryAssets)
                .FirstOrDefault(b => b.Id == branchId)
                .LibraryAssets;
        }


        public IEnumerable<Patron> GetPatrons(int branchId)
        {
            return _context.LibraryBranches
                .Include(b => b.Patrons)
                .FirstOrDefault(b => b.Id == branchId)
                .Patrons;
        }

        public IEnumerable<string> GetBranchHours(int branchId)
        {
            var brachHours = _context.BranchHours
                .Include(b => b.Branch)
                .Where(b => b.Branch.Id == branchId);

            return DataHelpers.HumanizeBizHours(brachHours);
        }

        public string IsBranchOpen(int branchId)
        {
            var branchHours = _context.BranchHours
               .Include(b => b.Branch)
               .Where(b => b.Branch.Id == branchId);

            int currentlyTimeHour = (int)DateTime.Now.Hour;

            int currentlyTimeDay = (int)DateTime.Now.DayOfWeek + 1;

            var daysHours = branchHours.FirstOrDefault(b => b.DayOfWeek == currentlyTimeDay);

            bool isOpen = currentlyTimeHour < daysHours.CloseTime && currentlyTimeHour > daysHours.OpenTime;

            if (isOpen) return "Yes";

            else return "No";
        }

        public void AddPatron(int patronId, int branchId)
        {
            var branch = GetById(branchId);
            var patron = _context.Patrons.FirstOrDefault(p => p.Id == patronId);
            branch.Patrons.Add(patron);
            _context.SaveChanges();
        }

        public void AddAsset(int assetId, int branchId)
        {
            var branch = GetById(branchId);
            var asset = _context.LibraryAssets.FirstOrDefault(p => p.Id == assetId);
            branch.LibraryAssets.Add(asset);
            _context.SaveChanges();
        }
    }
}
