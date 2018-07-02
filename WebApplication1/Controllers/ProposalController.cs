using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationCore.Entities.Entities.Proposal;
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
    [Route("api/proposal")]

    public class ProposalController : Controller
    {

        private readonly IProposalService _proposalService;

        public ProposalController(IProposalService proposalService)
        {
            _proposalService = proposalService;
        }

        [Route("")]
        [HttpGet]
        public IActionResult List(int? page, int? itemsPage)
        {

            var membersModel = _proposalService.GetProposalList(page ?? 1, itemsPage);
            return Ok(membersModel);
        }

        [Route("")]
        [HttpPost]
        public IActionResult Save(proposal proposal)
        {
            var proposalModel = _proposalService.Save(proposal);
            return Ok(proposalModel);
        }

        [Route("{proposalId:int}")]
        [HttpGet]
        public IActionResult Detail(int proposalId)
        {
            var proposalModel = _proposalService.Get(proposalId);
            if (proposalModel == null)
                return NoContent();
            else
                return Ok(proposalModel);
        }
    }
}