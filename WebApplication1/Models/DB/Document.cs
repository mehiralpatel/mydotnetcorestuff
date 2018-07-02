using System;
using System.Collections.Generic;

namespace WebApplication1.Models.DB
{
    public partial class Document
    {
        public Document()
        {
            DocumentVersion = new HashSet<DocumentVersion>();
        }

        public long DocumentId { get; set; }
        public string Name { get; set; }
        public short Status { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public DateTime LastModifiedByDateTime { get; set; }
        public int CreatedByUserId { get; set; }
        public int LastModifiedByUserId { get; set; }
        public long DocumentCategoryId { get; set; }
        public long EntityId { get; set; }
        public byte CurrentVersionNumber { get; set; }

        public DocumentCategory DocumentCategory { get; set; }
        public ICollection<DocumentVersion> DocumentVersion { get; set; }
    }
}
