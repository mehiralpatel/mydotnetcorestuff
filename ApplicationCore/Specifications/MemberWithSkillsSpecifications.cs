using Infrastructure.Data;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace ApplicationCore.Specifications
{
    public class MemberWithSkillsSpecifications : BaseSpecification<Resource>
    {
        public MemberWithSkillsSpecifications(int statusId )
            : base(b => b.Status == statusId)
        {
            AddInclude(b => b.UserSkillTags);
            AddInclude(b => b.ResourceTechnologyMap);
            AddInclude("UserSkillTags.Skill");
            AddInclude("ResourceTechnologyMap.Technology");
            AddInclude(b => b.ResourceType);

        }

    }

}
