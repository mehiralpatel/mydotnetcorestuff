using System;
using System.Collections.Generic;

namespace WebApplication1.Models.DB
{
    public partial class DocumentParent
    {
        public long DocumentParentId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsSystem { get; set; }
        public short Status { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public DateTime LastModifiedDateTime { get; set; }
        public int CreatedByUserId { get; set; }
        public int LastModifiedByUserId { get; set; }
    }
}
