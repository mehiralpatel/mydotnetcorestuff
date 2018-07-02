using System;
using System.Collections.Generic;

namespace WebApplication1.Models.DB
{
    public partial class Customers
    {
        public long CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FirebaseInfo { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? LastDateModified { get; set; }
    }
}
