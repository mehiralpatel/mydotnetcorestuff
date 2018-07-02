using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace WebApplication1.ViewModel.Member
{
    public class MemberListResponse
    {
        public IEnumerable<Member> MemberList { get; set; }
        public PaginationInfoModel PaginationInfo { get; set; }
    }

    public class Member
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public string SkillsCSV { get; set; }
        public List<SelectListItem> Skils { get; set; }
    }
}
