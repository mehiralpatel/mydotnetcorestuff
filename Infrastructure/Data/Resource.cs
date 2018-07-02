using System;
using System.Collections.Generic;

namespace Infrastructure.Data
{
    public partial class Resource : BaseEntity
    {
        public Resource()
        {
            CustomTaskCreatedByUser = new HashSet<CustomTask>();
            CustomTaskLastModifiedByUser = new HashSet<CustomTask>();
            CustomTaskResource = new HashSet<CustomTask>();
            ProjectCreatedByUser = new HashSet<Project>();
            ProjectLastModifiedByUser = new HashSet<Project>();
            ProjectResourceAssignment = new HashSet<ProjectResourceAssignment>();
            ResourceTechnologyMap = new HashSet<ResourceTechnologyMap>();
            TimeSheetCreatedByUser = new HashSet<TimeSheet>();
            TimeSheetLastModifiedByUser = new HashSet<TimeSheet>();
            TimeSheetResource = new HashSet<TimeSheet>();
            TimeSheetTimeSheetApprovalByUser = new HashSet<TimeSheet>();
            UserSkillTags = new HashSet<UserSkillTags>();
        }

        public long ResourceId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public short Status { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public DateTime LastModifiedDateTime { get; set; }
        public int CreatedByUserId { get; set; }
        public int? LastModifiedByUserId { get; set; }
        public long? TechnologyId { get; set; }
        public decimal? Exp { get; set; }
        public string ProfileUrl { get; set; }
        public string Cvurl { get; set; }
        public string EmailAddress { get; set; }
        public string Address { get; set; }
        public string Mobile { get; set; }
        public string JobTitle { get; set; }
        public string Telephonenumber { get; set; }
        public decimal? Cost { get; set; }
        public int? ResourceTypeId { get; set; }
        public string Designation { get; set; }
        public long? RoleId { get; set; }
        public long? BranchId { get; set; }
        public DateTime? JoinDate { get; set; }
        public DateTime? RelievingDate { get; set; }
        public decimal? ReleventExp { get; set; }
        public long? ReporteeResourceId { get; set; }

        public Branch Branch { get; set; }
        public ResourceType ResourceType { get; set; }
        public Role Role { get; set; }
        public Technology Technology { get; set; }
        public ICollection<CustomTask> CustomTaskCreatedByUser { get; set; }
        public ICollection<CustomTask> CustomTaskLastModifiedByUser { get; set; }
        public ICollection<CustomTask> CustomTaskResource { get; set; }
        public ICollection<Project> ProjectCreatedByUser { get; set; }
        public ICollection<Project> ProjectLastModifiedByUser { get; set; }
        public ICollection<ProjectResourceAssignment> ProjectResourceAssignment { get; set; }
        public ICollection<ResourceTechnologyMap> ResourceTechnologyMap { get; set; }
        public ICollection<TimeSheet> TimeSheetCreatedByUser { get; set; }
        public ICollection<TimeSheet> TimeSheetLastModifiedByUser { get; set; }
        public ICollection<TimeSheet> TimeSheetResource { get; set; }
        public ICollection<TimeSheet> TimeSheetTimeSheetApprovalByUser { get; set; }
        public ICollection<UserSkillTags> UserSkillTags { get; set; }
    }
}
