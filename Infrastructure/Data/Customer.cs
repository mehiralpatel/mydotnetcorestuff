using System;
using System.Collections.Generic;

namespace Infrastructure.Data
{
    public partial class Customer : BaseEntity
    {
        public Customer()
        {
            Project = new HashSet<Project>();
            Proposal = new HashSet<Proposal>();
        }

        public long CustomerId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public short? Status { get; set; }
        public DateTime? CreatedDateTime { get; set; }
        public DateTime? LastModifiedDateTime { get; set; }
        public int? CreatedByUserId { get; set; }
        public int? LastModifiedByUserId { get; set; }
        public int? CountryId { get; set; }

        public Country Country { get; set; }
        public ICollection<Project> Project { get; set; }
        public ICollection<Proposal> Proposal { get; set; }
    }
}
