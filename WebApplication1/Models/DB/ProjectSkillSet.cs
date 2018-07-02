using System;
using System.Collections.Generic;

namespace WebApplication1.Models.DB
{
    public partial class ProjectSkillSet
    {
        public long ProjectSkillSetId { get; set; }
        public long? SkillId { get; set; }
        public long? ProjectId { get; set; }
        public short Status { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public DateTime LastModifiedDateTime { get; set; }
        public int CreatedByUserId { get; set; }
        public int LastModifiedByUserId { get; set; }

        public Project Project { get; set; }
        public Skill Skill { get; set; }
    }
}
