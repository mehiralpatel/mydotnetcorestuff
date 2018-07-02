using System;
using System.Collections.Generic;

namespace WebApplication1.Models.DB
{
    public partial class Proposal
    {
        public Proposal()
        {
            Project = new HashSet<Project>();
            ProposalPayment = new HashSet<ProposalPayment>();
            ProposalResourceType = new HashSet<ProposalResourceType>();
            ProposalTechnologyMap = new HashSet<ProposalTechnologyMap>();
        }

        public int ProposalId { get; set; }
        public string ProposalRef { get; set; }
        public DateTime ProposalDate { get; set; }
        public string Title { get; set; }
        public DateTime SignoffDate { get; set; }
        public decimal SignoffAmount { get; set; }
        public int ModelId { get; set; }
        public long CustomerId { get; set; }
        public int CurrencyId { get; set; }
        public decimal ProposalAmount { get; set; }
        public short Status { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public DateTime LastModifiedDateTime { get; set; }
        public long CreatedByUserId { get; set; }
        public long LastModifiedByUserId { get; set; }

        public Currency Currency { get; set; }
        public Customer Customer { get; set; }
        public ICollection<Project> Project { get; set; }
        public ICollection<ProposalPayment> ProposalPayment { get; set; }
        public ICollection<ProposalResourceType> ProposalResourceType { get; set; }
        public ICollection<ProposalTechnologyMap> ProposalTechnologyMap { get; set; }
    }
}
