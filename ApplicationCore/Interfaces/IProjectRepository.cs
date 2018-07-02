
using Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCore.Interfaces
{
    public interface IProjectRepository
    {
        List<Project> GetProjectList(Dictionary<string, object> parameters);
        string GetTechnologyName(int technologyid);
        string GetCustomerName(int customerid);
        string GetModelName(int modelid);
        //void AddSkillToMembers(int memberId, List<int> skillId);
    }
}
