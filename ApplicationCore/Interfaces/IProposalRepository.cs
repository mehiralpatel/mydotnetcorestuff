
using Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCore.Interfaces
{
    public interface IProposalRepository
    {
        List<Proposal> GetProposalList(Dictionary<string, object> parameters);
        string GetModelName(int modelid);
        string GetCurrencyName(int currencyid);
        string GetCustomerName(int customerid);
        string GetTechnologies(int proposalid);
        //void AddSkillToMembers(int memberId, List<int> skillId);
    }
}
