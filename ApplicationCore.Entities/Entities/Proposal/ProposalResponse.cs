using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ApplicationCore.Entities.Entities.Proposal
{
    public class ProposalResponse
    {
        public IEnumerable<proposal> ProposalList { get; set; }
        public PaginationInfoModel PaginationInfo { get; set; }
    }

    public class proposal
    {
        public long ProposalId { get; set; }

        [Required]
        [MaxLength(50)]
        public string ProposalRef { get; set; }
        public DateTime ProposalDate { get; set; }
        public string Title { get; set; }
        public string SignoffDate { get; set; }
        public decimal SignoffAmount { get; set; }
        public int ModelId { get; set; }
        public long CustomerId { get; set; }
        public int CurrencyId { get; set; }
        public decimal ProposalAmount { get; set; }
        public short Status { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public DateTime LastModifiedDateTime { get; set; }
        public long CreatedByUserId { get; set; }
        public long LastModifiedByUserId { get; set; }
        public string ModelName { get; set; }
        public string CustomerName { get; set; }
        public string CurrencyName { get; set; }
        public string Technology { get; set; }
    }
}
