using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCore.Entities.Entities.Customer
{
    public class PaginationInfoModel
    {
        public int TotalItems { get; set; }
        public int ItemsPerPage { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
    }
}
