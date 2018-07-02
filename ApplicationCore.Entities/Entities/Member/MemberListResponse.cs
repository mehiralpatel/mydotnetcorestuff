using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ApplicationCore.Entities.Entities.Member
{
    public class MemberListResponse
    {
        public IEnumerable<Member> MemberList { get; set; }
        public PaginationInfoModel PaginationInfo { get; set; }
    }

    public class Member
    {
        public long Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        public string Url { get; set; }
        public string SkillsCSV { get; set; }
        public List<SelectListItem> Skils { get; set; }
        public string Address { get; set; }
        public string EmailAddress { get; set; }

        public string Technology { get; set; }

        public string ResourceType { get; set; }

        public decimal CostPerHour { get; set; }

        public string Designation { get; set; }

        public long ResourceId { get; set; }
        public string Description { get; set; }
        public short Status { get; set; }
        public string CreatedDateTime { get; set; }
        public string LastModifiedDateTime { get; set; }
        public int CreatedByUserId { get; set; }
        public int? LastModifiedByUserId { get; set; }
        public long? TechnologyId { get; set; }
        public decimal? Exp { get; set; }
        public string ProfileUrl { get; set; }
        public string Cvurl { get; set; }
        public string Mobile { get; set; }
        public string JobTitle { get; set; }
        public string Telephonenumber { get; set; }
        public decimal? Cost { get; set; }
        public int? ResourceTypeId { get; set; }
        public long? RoleId { get; set; }
        public long? BranchId { get; set; }
        public string JoinDate { get; set; }
        public string RelievingDate { get; set; }
        public decimal? ReleventExp { get; set; }
        public long ReporteeResourceId { get; set; }

    }
}
