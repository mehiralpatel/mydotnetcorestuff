using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationCore.Entities.Entities.Member;
using ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebApplication1.Helpers;

namespace WebApplication1.Controllers
{
    [EnableCors("SiteCorsPolicy")]
    [Produces("application/json")]
    [Route("api/Member")]
    [ValidateModel]
    public class MemberController : Controller
    {
        
        private readonly IMemberService _memberService;

        public MemberController(IMemberService memberService)
        {
            _memberService = memberService;
        }

        [Route("")]
        [HttpGet]
        public IActionResult List(int? page, int? itemsPage)
        {

            var membersModel = _memberService.GetMemberList(page ?? 1, itemsPage);
            return Ok(membersModel);
        }

        [Route("")]
        [HttpPost]
        public IActionResult Save(Member member)
        {
            var membersModel = _memberService.Save(member);
            return Ok(membersModel);
        }

        [Route("{memberId:int}")]
        [HttpGet]
        public IActionResult Detail(int memberId)
        {
            var membersModel = _memberService.Get(memberId);
            if (membersModel == null)
                return NoContent();
            else
                return Ok(membersModel);
        }
    }
}