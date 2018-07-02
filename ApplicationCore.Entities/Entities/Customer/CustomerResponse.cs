using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ApplicationCore.Entities.Entities.Customer
{
    public class CustomerResponse
    {
        public IEnumerable<customer> CustomerList { get; set; }
        public PaginationInfoModel PaginationInfo { get; set; }
    }

    public class customer
    {
        public long CustomerId { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        public string Description { get; set; }
        public short? Status { get; set; }
        public DateTime? CreatedDateTime { get; set; }
        public DateTime? LastModifiedDateTime { get; set; }
        public int? CreatedByUserId { get; set; }
        public int? LastModifiedByUserId { get; set; }
        public int? CountryId { get; set; }
        public string CountryName { get; set; }
    }
}
