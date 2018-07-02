using System;
using System.Collections.Generic;

namespace Infrastructure.Data
{
    public partial class WorkItem
    {
        public WorkItem()
        {
            TimeSheet = new HashSet<TimeSheet>();
        }

        public long ParentWorkItemId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public short Type { get; set; }
        public TimeSpan? OriginalEstimate { get; set; }
        public bool IsBillable { get; set; }
        public long? SprintId { get; set; }
        public short? Severity { get; set; }
        public short Status { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public DateTime LastModifiedDateTime { get; set; }
        public int CreatedByUserId { get; set; }
        public int LastModifiedByUserId { get; set; }
        public short? State { get; set; }
        public long? ResourceId { get; set; }

        public ICollection<TimeSheet> TimeSheet { get; set; }
    }
}
