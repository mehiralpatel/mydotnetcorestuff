using System;
using System.Collections.Generic;

namespace Infrastructure.Data
{
    public partial class ProposalPayment
    {
        public int ProposalPaymentId { get; set; }
        public int ProposalId { get; set; }
        public DateTime PlannedInvoiceDate { get; set; }
        public decimal PlannedInvoiceAmount { get; set; }
        public byte PlannedInvoiceSequence { get; set; }
        public DateTime PlannedRemittanceDate { get; set; }
        public string Summary { get; set; }
        public short Status { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public DateTime LastModifiedDateTime { get; set; }
        public long CreatedByUserId { get; set; }
        public long LastModifiedByUserId { get; set; }

        public Proposal Proposal { get; set; }
    }
}
