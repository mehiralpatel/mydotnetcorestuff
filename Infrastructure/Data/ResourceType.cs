using System;
using System.Collections.Generic;

namespace Infrastructure.Data
{
    public partial class ResourceType : BaseEntity
    {
        public ResourceType()
        {
            ProposalResourceType = new HashSet<ProposalResourceType>();
            Resource = new HashSet<Resource>();
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
        public ICollection<Resource> Resource { get; set; }
    }
}
