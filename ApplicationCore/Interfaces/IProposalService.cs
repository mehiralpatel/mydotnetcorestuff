using ApplicationCore.Entities.Entities;
using ApplicationCore.Entities.Entities.Proposal;
using Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Interfaces
{
    public interface IProposalService
    {
         ProposalResponse GetProposalList(int pageIndex, int? itemsPage);

        proposal Save(proposal proposal);

        proposal Get(int id);
        
    }
}
