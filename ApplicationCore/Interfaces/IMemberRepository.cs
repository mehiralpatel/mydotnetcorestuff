
using Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCore.Interfaces
{
    public interface IMemberRepository
    {
        List<Resource> GetMemberList(Dictionary<string, object> parameters);

        //void AddSkillToMembers(int memberId, List<int> skillId);
    }
}
