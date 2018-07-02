
using Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCore.Interfaces
{
    public interface ICustomerRepository
    {
        List<Customer> GetCustomerList(Dictionary<string, object> parameters);
        string CountryName(int countryId);
        //void AddSkillToMembers(int memberId, List<int> skillId);
    }
}
