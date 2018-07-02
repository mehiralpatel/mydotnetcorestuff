using System;
using System.Collections.Generic;

namespace Infrastructure.Data
{
    public partial class ProjectResourceAssignment
    {
        public long ProjectResourceAssignmentId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public long? ProjectId { get; set; }
        public long? ResourceId { get; set; }
        public short Status { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public DateTime LastModifiedDateTime { get; set; }
        public int CreatedByUserId { get; set; }
        public int LastModifiedByUserId { get; set; }

        public Project Project { get; set; }
        public Resource Resource { get; set; }
    }
}
