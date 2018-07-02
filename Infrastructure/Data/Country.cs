using System;
using System.Collections.Generic;

namespace Infrastructure.Data
{
    public partial class Country : BaseEntity
    {
        public Country()
        {
            Currency = new HashSet<Currency>();
            Customer = new HashSet<Customer>();
        }

        public int CountryId { get; set; }
        public string Name { get; set; }

        public ICollection<Currency> Currency { get; set; }
        public ICollection<Customer> Customer { get; set; }
    }
}
