using AutoMapper;
using LibraryData.Models;
using LibraryManagement.Models.Branch;
using LibraryManagement.Models.Patron;

namespace LibraryManagement.Mapper
{
    public class AutoMapper: Profile
    {
        public AutoMapper()
        {
            CreateMap<Patron, PatronDetailModel>().ReverseMap();
            CreateMap<LibraryBranch, BranchDetailModel>().ReverseMap();
        }
    }
}
