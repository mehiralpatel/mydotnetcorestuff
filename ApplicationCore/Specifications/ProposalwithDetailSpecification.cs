using Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCore.Specifications
{
    public class ProposalwithDetailSpecification : BaseSpecification<Proposal>
    {
        public ProposalwithDetailSpecification(int statusId)
            : base(b => b.Status == statusId)
        {
            AddInclude(b => b.Customer);
            AddInclude(b => b.Currency);
            AddInclude(b => b.Project);
            AddInclude("ProposalTechnologyMap.Technology");
            AddInclude("Project.Model");

        }

    }
}
