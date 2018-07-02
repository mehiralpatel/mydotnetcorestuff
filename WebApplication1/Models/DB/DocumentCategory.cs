using System;
using System.Collections.Generic;

namespace WebApplication1.Models.DB
{
    public partial class DocumentCategory
    {
        public DocumentCategory()
        {
            Document = new HashSet<Document>();
        }

        public long DocumentCategoryId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsSystem { get; set; }
        public long? DocumentParentId { get; set; }
        public short Status { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public DateTime LastModifiedDateTime { get; set; }
        public int CreatedByUserId { get; set; }
        public int LastModifiedByUserId { get; set; }

        public ICollection<Document> Document { get; set; }
    }
}
