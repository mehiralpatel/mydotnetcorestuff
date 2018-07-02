using System;
using System.Collections.Generic;

namespace Infrastructure.Data
{
    public partial class TechnologySkill
    {
        public long TechnologySkillId { get; set; }
        public long? TechnologyId { get; set; }
        public long? SkillId { get; set; }
        public short? Status { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public DateTime LastModifiedDateTime { get; set; }
        public int CreatedByUserId { get; set; }
        public int LastModifiedByUserId { get; set; }

        public Skill Skill { get; set; }
        public Technology Technology { get; set; }
    }
}
