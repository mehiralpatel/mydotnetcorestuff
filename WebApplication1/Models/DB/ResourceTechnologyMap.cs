using System;
using System.Collections.Generic;

namespace WebApplication1.Models.DB
{
    public partial class ResourceTechnologyMap
    {
        public long ResourceTechnologyMapId { get; set; }
        public short? Level { get; set; }
        public short Status { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public DateTime LastModifiedDateTime { get; set; }
        public long? TechnologyId { get; set; }
        public long? ResourceId { get; set; }

        public Resource Resource { get; set; }
        public Technology Technology { get; set; }
    }
}
