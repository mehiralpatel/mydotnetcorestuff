using System;
using System.Collections.Generic;

namespace Infrastructure.Data
{
    public partial class Branch : BaseEntity
    {
        public Branch()
        {
            Resource = new HashSet<Resource>();
        }

        public long BranchId { get; set; }
        public string BranchName { get; set; }
        public string Description { get; set; }
        public short Status { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public DateTime LastModifiedDateTime { get; set; }
        public int CreatedByUserId { get; set; }
        public int LastModifiedByUserId { get; set; }

        public ICollection<Resource> Resource { get; set; }
    }
}
