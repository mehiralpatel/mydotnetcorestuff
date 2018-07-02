using System;
using System.Collections.Generic;

namespace WebApplication1.Models.DB
{
    public partial class DocumentVersion
    {
        public long DocumentVersionId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public long DocumentId { get; set; }
        public byte? VersionNumber { get; set; }
        public string FileName { get; set; }
        public string StoragePath { get; set; }
        public string CoverImageFilePath { get; set; }
        public string ContentType { get; set; }
        public string FileExtension { get; set; }
        public long? StorageSize { get; set; }
        public Guid? UniqueId { get; set; }
        public short Status { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public DateTime LastModifiedByDateTime { get; set; }
        public int CreatedByUserId { get; set; }
        public int LastModifiedByUserId { get; set; }

        public Document Document { get; set; }
    }
}
