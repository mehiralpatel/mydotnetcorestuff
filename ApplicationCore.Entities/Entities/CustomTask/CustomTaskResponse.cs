using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ApplicationCore.Entities.Entities.CustomTask
{
    public class CustomTaskResponse
    {
        public IEnumerable<Customtask> CustomTaskList { get; set; }
        public PaginationInfoModel PaginationInfo { get; set; }
    }

    public class Customtask
    {
        public int CustomTaskId { get; set; }

        [Required]
        [MaxLength(50)]
        public string CustomTaskName { get; set; }
        public string Description { get; set; }
        public short Status { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public long CreatedByUserId { get; set; }
        public DateTime LastModifiedDateTime { get; set; }
        public long LastModifiedByUserId { get; set; }
        public string DueDate { get; set; }
        public long? ResourceId { get; set; }
        public string ResourceName { get; set; }
        public string StatusName { get; set; }

    }
}
