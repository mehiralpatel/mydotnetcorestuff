using System;
using System.Collections.Generic;

namespace Infrastructure.Data
{
    public partial class UserSkillTags
    {
        public long SkillUserId { get; set; }
        public long? SkillId { get; set; }
        public long? ResourceId { get; set; }
        public int? Level { get; set; }
        public DateTime? CreatedDateTime { get; set; }
        public DateTime? LastModifiedDateTime { get; set; }
        public int? CreatedByUserId { get; set; }
        public int? LastModifiedByUserId { get; set; }

        public Resource Resource { get; set; }
        public Skill Skill { get; set; }
    }
}
