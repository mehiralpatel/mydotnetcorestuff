using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.ViewModel.Member;

namespace WebApplication1.Interfaces
{
    public interface IMemberService
    {
        MemberListResponse GetMemberList(int pageIndex, int? itemsPage);

        Member Save(Member member);


    }
}

}
