using System;
using System.Collections.Generic;

namespace Infrastructure.Data
{
    public partial class Currency : BaseEntity
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
