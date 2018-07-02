using System;
using System.Collections.Generic;

namespace Infrastructure.Data
{
    public partial class TimeSheet
    {
        public int TimeSheetId { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public long? ParentWorkItemId { get; set; }
        public TimeSpan TimeSpent { get; set; }
        public TimeSpan TimeRemaining { get; set; }
        public TimeSpan EfficientTimeOndesk { get; set; }
        public short Status { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public long CreatedByUserId { get; set; }
        public DateTime LastModifiedDateTime { get; set; }
        public long LastModifiedByUserId { get; set; }
        public DateTime? TimeSheetAppovedOn { get; set; }
        public long? TimeSheetApprovalByUserId { get; set; }
        public short? TimeSheetApprovalState { get; set; }
        public TimeSpan? BillableTimeSpentByPm { get; set; }
        public TimeSpan? BillableTimeSpentByBd { get; set; }
        public long ResourceId { get; set; }
        public int? CustomTaskId { get; set; }

        public Resource CreatedByUser { get; set; }
        public CustomTask CustomTask { get; set; }
        public Resource LastModifiedByUser { get; set; }
        public WorkItem ParentWorkItem { get; set; }
        public Resource Resource { get; set; }
        public Resource TimeSheetApprovalByUser { get; set; }
    }
}
