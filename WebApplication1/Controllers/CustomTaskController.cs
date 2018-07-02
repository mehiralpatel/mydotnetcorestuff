using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationCore.Entities.Entities.CustomTask;
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
    [Route("api/CustomTask")]
     
    public class CustomTaskController : Controller
    {

        private readonly ICustomTaskService _customTaskService;

        public CustomTaskController(ICustomTaskService customTaskService)
        {
            _customTaskService = customTaskService;
        }

        [Route("")]
        [HttpGet]
        public IActionResult List(int? page, int? itemsPage)
        {

            var membersModel = _customTaskService.GetCustomTaskList(page ?? 1, itemsPage);
            return Ok(membersModel);
        }

        [Route("")]
        [HttpPost]
        public IActionResult Save(Customtask customtask)
        {
            var membersModel = _customTaskService.Save(customtask);
            return Ok(membersModel);
        }

        [Route("{customTaskId:int}")]
        [HttpGet]
        public IActionResult Detail(int customTaskId)
        {
            var membersModel = _customTaskService.Get(customTaskId);
            if (membersModel == null)
                return NoContent();
            else
                return Ok(membersModel);
        }
    }
}