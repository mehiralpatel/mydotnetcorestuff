using System;
using System.Collections.Generic;

namespace Infrastructure.Data
{
    public partial class ProposalTechnologyMap
    {
        public int ProposalTechnologyMapId { get; set; }
        public int? ProposalId { get; set; }
        public long? TechnologyId { get; set; }
        public short Status { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public DateTime LastModifiedDateTime { get; set; }
        public long CreatedByUserId { get; set; }
        public long LastModifiedByUserId { get; set; }

        public Proposal Proposal { get; set; }
        public Technology Technology { get; set; }
    }
}
