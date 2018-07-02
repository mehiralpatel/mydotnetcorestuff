using ApplicationCore.Interfaces;
using Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infrastructure.DataAccess.SqlServer.Repository
{
    public class ProposalRepository : IProposalRepository
    {
        protected readonly PPMContext _dbContext;

        public ProposalRepository(PPMContext dbContext)
        {
            _dbContext = dbContext;
        }

        public string GetCurrencyName(int currencyid)
        {
            var currencyname = _dbContext.Currency.Where(x => x.CurrencyId == currencyid).Select(x => x.Name).FirstOrDefault();
            if (currencyname != null)
                return currencyname;
            else
                return " --- ";
        }

        public string GetCustomerName(int customerid)
        {
            var customername = _dbContext.Customer.Where(x => x.CustomerId == customerid).Select(x => x.Name).FirstOrDefault();
            if (customername != null)
                return customername;
            else
                return " --- ";
        }

        public string GetModelName(int modelid)
        {
            var modelname = _dbContext.Model.Where(x => x.ModelId == modelid).Select(x => x.Name).FirstOrDefault();
            if (modelname != null)
                return modelname;
            else
                return " --- ";
        }
        public string GetTechnologies(int proposalid)
        {
            var modelname = (from i in _dbContext.ProposalTechnologyMap
                             join j in _dbContext.Technology on i.TechnologyId equals j.TechnologyId
                             select j.Name).ToList();
            if (modelname.Count > 0)
                return String.Join(',', modelname);
            else
                return " --- ";
        }
        //public string CountryName(int countryId)
        //{
        //    var countryName = _dbContext.Country.Where(x => x.CountryId == countryId).Select(x => x.Name).FirstOrDefault();
        //    if (countryName == null)
        //        return "No Country Selected";
        //    else
        //        return countryName;
        //}

        public List<Proposal> GetProposalList(Dictionary<string, object> parameters)
        {
            var ProposalList = _dbContext.Set<Proposal>().ToList();
            return ProposalList;
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
