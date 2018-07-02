using ApplicationCore.Interfaces;
using Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infrastructure.DataAccess.SqlServer.Repository
{
    public class ProjectRepository : IProjectRepository
    {
        protected readonly PPMContext _dbContext;

        public ProjectRepository(PPMContext dbContext)
        {
            _dbContext = dbContext;
        }

        public string GetCustomerName(int customerid)
        {
            var customerName = _dbContext.Customer.Where(x => x.CustomerId == customerid).Select(x => x.Name).FirstOrDefault();
            if (customerName == null)
                return "No customer selected";
            else
                return customerName;
        }

        public string GetModelName(int modelid)
        {
            var ModelName = _dbContext.Model.Where(x => x.ModelId == modelid).Select(x => x.Name).FirstOrDefault();
            if (ModelName == null)
                return "No ModelName Selected";
            else
                return ModelName;
        }


        //public string CountryName(int countryId)
        //{
        //    var countryName = _dbContext.Country.Where(x => x.CountryId == countryId).Select(x => x.Name).FirstOrDefault();
        //    if (countryName == null)
        //        return "No Country Selected";
        //    else
        //        return countryName;
        //}

        public List<Project> GetProjectList(Dictionary<string, object> parameters)
        {
            var ProjectList = _dbContext.Set<Project>().ToList();
            return ProjectList;
        }

        public string GetTechnologyName(int technologyid)
        {
            var TechName = _dbContext.Technology.Where(x => x.TechnologyId == technologyid).Select(x => x.Name).FirstOrDefault();
            if (TechName == null)
                return "No Technology Name Selected";
            else
                return TechName;
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
