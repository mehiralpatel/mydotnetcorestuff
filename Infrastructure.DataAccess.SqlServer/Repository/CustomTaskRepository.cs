using ApplicationCore.Interfaces;
using Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infrastructure.DataAccess.SqlServer.Repository
{
    public class CustomTaskRepository : ICustomTaskRepository
    {
        protected readonly PPMContext _dbContext;

        public CustomTaskRepository(PPMContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<CustomTask> GetCustomTaskList(Dictionary<string, object> parameters)
        {
            var customTaskList = _dbContext.Set<CustomTask>().ToList();
            return customTaskList;
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
