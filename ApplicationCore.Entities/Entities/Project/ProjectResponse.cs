using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ApplicationCore.Entities.Entities.Project
{
    public class ProjectResponse
    {
        public IEnumerable<project> ProjectList { get; set; }
        public PaginationInfoModel PaginationInfo { get; set; }
    }

    public class project
    {
        public long ProjectId { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        public string Description { get; set; }
        public short Status { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public DateTime LastModifiedDateTime { get; set; }
        public long CreatedByUserId { get; set; }
        public long LastModifiedByUserId { get; set; }
        public long? CustomerId { get; set; }
        public int? ModelId { get; set; }
        public string Code { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public short? State { get; set; }
        public long? TechnologyId { get; set; }
        public int? ProposalId { get; set; }
        public string CustomerName { get; set; }
        public string ModelName { get; set; }
        public string Technology { get; set; }
        public string PrimaryReposting { get; set; }
        public string SecondaryReporting { get; set; }
    }
}
