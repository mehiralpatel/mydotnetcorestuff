using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationCore.Entities.Entities.Project;
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
    [Route("api/timesheet")]
    public class TimesheetController : Controller
    {

        private readonly IProjectService _projectService;

        public TimesheetController(IProjectService projectService)
        {
            _projectService = projectService;
        }

        [Route("")]
        [HttpGet]
        public IActionResult List(int? page, int? itemsPage)
        {

            var projectModel = _projectService.GetProjectList(page ?? 1, itemsPage);
            return Ok(projectModel);
        }

        [Route("")]
        [HttpPost]
        public IActionResult Save(project customer)
        {
            var membersModel = _projectService.Save(customer);
            return Ok(membersModel);
        }

        [Route("{proposalId:int}")]
        [HttpGet]
        public IActionResult Detail(int proposalId)
        {
            var membersModel = _projectService.Get(proposalId);
            if (membersModel == null)
                return NoContent();
            else
                return Ok(membersModel);
        }
    }
}