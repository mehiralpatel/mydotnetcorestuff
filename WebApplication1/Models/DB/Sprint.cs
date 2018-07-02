using System;
using System.Collections.Generic;

namespace WebApplication1.Models.DB
{
    public partial class Sprint
    {
        public long SprintId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public short? DurationInDays { get; set; }
        public string Velocity { get; set; }
        public short Status { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public DateTime LastModifiedDateTime { get; set; }
        public int CreatedByUserId { get; set; }
        public int LastModifiedByUserId { get; set; }
        public long? ProjectId { get; set; }

        public Project Project { get; set; }
    }
}
