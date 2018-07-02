using System;
using System.Collections.Generic;

namespace Infrastructure.Data
{
    public partial class Role : BaseEntity
    {
        public Role()
        {
            Resource = new HashSet<Resource>();
        }

        public long RoleId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public short Status { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public int CreatedByUserId { get; set; }
        public DateTime LastModifiedByDateTime { get; set; }
        public int LastModifiedByUserId { get; set; }

        public ICollection<Resource> Resource { get; set; }
    }
}
