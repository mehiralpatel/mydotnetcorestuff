using ApplicationCore.Interfaces;
using Infrastructure.Data;
using System.Collections.Generic;
using System.Linq;

namespace Infrastructure.DataAccess.SqlServer.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        protected readonly PPMContext _dbContext;

        public CustomerRepository(PPMContext dbContext)
        {
            _dbContext = dbContext;
        }

        public string CountryName(int countryId)
        {
            var countryName = _dbContext.Country.Where(x => x.CountryId == countryId).Select(x => x.Name).FirstOrDefault();
            if (countryName == null)
                return "No Country Selected";
            else
                return countryName;
        }
        
        public List<Customer> GetCustomerList(Dictionary<string, object> parameters)
        {
            var customerList = _dbContext.Set<Customer>().ToList();
            return customerList;
        }

        //public Member AddSkillToMembers(int memberId, List<int> skillId)
        //{
        //    //Add skills to members
        //    //retrun member entity

        //    return new Member() { Id = 1, Name = "Test Member1", Skils = new List<int>() { 1, 2 }, Url = "TODO" };

        //}

        //public List<Resource> GetMemberList(Dictionary<string, object> parameters)
        //{
        //    var memberlist = _dbContext.Set<Resource>().ToList();
        //    //MemberListResponse members = new MemberListResponse();
        //    //members.MemberList = new List<Member>();

        //    //members.PaginationInfo = new PaginationInfoModel()
        //    //{ CurrentPage = 1, ItemsPerPage = 10, TotalItems = 100, TotalPages = 10 };

        //    //Member detail1 = new Member() { Id = 1, Name = "Member1", Url = "" };
        //    //members.MemberList.Add(detail1);

        //    return memberlist;
        //}
    }
}
