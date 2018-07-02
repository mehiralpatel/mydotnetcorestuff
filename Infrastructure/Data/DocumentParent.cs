using System;
using System.Collections.Generic;

namespace Infrastructure.Data
{
    public partial class DocumentParent
    {
        public DocumentParent()
        {
            DocumentCategory = new HashSet<DocumentCategory>();
        }

        public long DocumentParentId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsSystem { get; set; }
        public short Status { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public DateTime LastModifiedDateTime { get; set; }
        public int CreatedByUserId { get; set; }
        public int LastModifiedByUserId { get; set; }

        public ICollection<DocumentCategory> DocumentCategory { get; set; }
    }
}
