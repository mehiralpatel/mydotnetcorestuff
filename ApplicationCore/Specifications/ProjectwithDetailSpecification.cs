using Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCore.Specifications
{
    public class ProjectwithDetailSpecification : BaseSpecification<Project>
    {
        public ProjectwithDetailSpecification(int statusId)
            : base(b => b.Status == statusId)
        {
            AddInclude(b => b.Customer);
            AddInclude(b => b.Technology);
            AddInclude(b => b.Model);
        }

    }
}
