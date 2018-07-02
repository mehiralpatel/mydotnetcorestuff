using System;
using System.Collections.Generic;

namespace WebApplication1.Models.DB
{
    public partial class Currency
    {
        public Currency()
        {
            Proposal = new HashSet<Proposal>();
        }

        public int CurrencyId { get; set; }
        public string Name { get; set; }
        public int? CountryId { get; set; }

        public Country Country { get; set; }
        public ICollection<Proposal> Proposal { get; set; }
    }
}
