using System;
using System.Collections.Generic;

namespace Infrastructure.Data
{
    public partial class Skill : BaseEntity
    {
        public Skill()
        {
            ProjectSkillSet = new HashSet<ProjectSkillSet>();
            TechnologySkill = new HashSet<TechnologySkill>();
            UserSkillTags = new HashSet<UserSkillTags>();
        }

        public long SkillId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public short Status { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public DateTime LastModifiedDateTime { get; set; }
        public int CreatedByUserId { get; set; }
        public int LastModifiedByUserId { get; set; }

        public ICollection<ProjectSkillSet> ProjectSkillSet { get; set; }
        public ICollection<TechnologySkill> TechnologySkill { get; set; }
        public ICollection<UserSkillTags> UserSkillTags { get; set; }
    }
}
