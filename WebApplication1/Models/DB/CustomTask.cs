using System;
using System.Collections.Generic;

namespace WebApplication1.Models.DB
{
    public partial class CustomTask
    {
        public CustomTask()
        {
            TimeSheet = new HashSet<TimeSheet>();
        }

        public int CustomTaskId { get; set; }
        public string CustomTaskName { get; set; }
        public string Description { get; set; }
        public short Status { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public long CreatedByUserId { get; set; }
        public DateTime LastModifiedDateTime { get; set; }
        public long LastModifiedByUserId { get; set; }
        public DateTime? DueDate { get; set; }
        public long? ResourceId { get; set; }

        public Resource CreatedByUser { get; set; }
        public Resource LastModifiedByUser { get; set; }
        public ICollection<TimeSheet> TimeSheet { get; set; }
    }
}
