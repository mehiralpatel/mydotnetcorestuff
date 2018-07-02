using System;
using System.Collections.Generic;

namespace WebApplication1.Models.DB
{
    public partial class ResourceType
    {
        public ResourceType()
        {
            ProposalResourceType = new HashSet<ProposalResourceType>();
        }

        public int ResourceTypeId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public short Status { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public DateTime LastModifiedDateTime { get; set; }
        public long CreatedByUserId { get; set; }
        public long LastModifiedByUserId { get; set; }
        public bool IsBillable { get; set; }

        public ICollection<ProposalResourceType> ProposalResourceType { get; set; }
    }
}
