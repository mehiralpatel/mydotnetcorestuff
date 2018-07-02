using ApplicationCore.Entities.Entities.Member;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Interfaces
{
    public interface IMemberService
    {
        MemberListResponse GetMemberList(int pageIndex, int? itemsPage);

        Member Save(Member member);

        Member Get(int id);


    }
}
