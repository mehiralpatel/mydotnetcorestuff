using Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCore.Specifications
{
    public class CustomerWithCountryData : BaseSpecification<Customer>
    {

        public CustomerWithCountryData(int statusId)
            : base(b => b.Status == statusId)
        {
            AddInclude(b => b.Country);
            
        }
    }
}

