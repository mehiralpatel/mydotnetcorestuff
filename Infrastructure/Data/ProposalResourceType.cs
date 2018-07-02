using System;
using System.Collections.Generic;

namespace Infrastructure.Data
{
    public partial class ProposalResourceType
    {
        public int ProposalResourceTypeId { get; set; }
        public int ResourceTypeId { get; set; }
        public int ProposalId { get; set; }
        public decimal ApprovedHours { get; set; }
        public decimal Rates { get; set; }
        public string Notes { get; set; }
        public short Status { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public DateTime LastModifiedDateTime { get; set; }
        public long CreatedByUserId { get; set; }
        public long LastModifiedByUserId { get; set; }

        public Proposal Proposal { get; set; }
        public ResourceType ResourceType { get; set; }
    }
}
