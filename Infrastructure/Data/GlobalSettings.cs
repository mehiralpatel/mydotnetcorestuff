using System;
using System.Collections.Generic;

namespace Infrastructure.Data
{
    public partial class GlobalSettings
    {
        public int GlobalSettingsId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Value { get; set; }
        public short Status { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public DateTime LastModifiedDateTime { get; set; }
        public int CreatedByUserId { get; set; }
        public int LastModifiedByUserId { get; set; }
    }
}
