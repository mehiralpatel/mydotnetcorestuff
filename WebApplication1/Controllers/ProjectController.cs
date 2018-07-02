
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
    [Route("api/project")]

    public class ProjectController : Controller
    {

        private readonly IProjectService _projectService;

        public ProjectController(IProjectService projectService)
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
        public IActionResult Save(project project)
        {
            var projectModel = _projectService.Save(project);
            return Ok(projectModel);
        }

        [Route("{projectId:int}")]
        [HttpGet]
        public IActionResult Detail(int projectId)
        {
            var projectModel = _projectService.Get(projectId);
            if (projectModel == null)
                return NoContent();
            else
                return Ok(projectModel);
        }
    }
}