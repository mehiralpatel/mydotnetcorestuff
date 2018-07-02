using System;
using System.Collections.Generic;

namespace WebApplication1.Models.DB
{
    public partial class Project
    {
        public Project()
        {
            ProjectResourceAssignment = new HashSet<ProjectResourceAssignment>();
            ProjectSkillSet = new HashSet<ProjectSkillSet>();
            Sprint = new HashSet<Sprint>();
        }

        public long ProjectId { get; set; }
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
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public short? State { get; set; }
        public long? TechnologyId { get; set; }
        public int? ProposalId { get; set; }

        public Resource CreatedByUser { get; set; }
        public Customer Customer { get; set; }
        public Resource LastModifiedByUser { get; set; }
        public Model Model { get; set; }
        public Proposal Proposal { get; set; }
        public Technology Technology { get; set; }
        public ICollection<ProjectResourceAssignment> ProjectResourceAssignment { get; set; }
        public ICollection<ProjectSkillSet> ProjectSkillSet { get; set; }
        public ICollection<Sprint> Sprint { get; set; }
    }
}
