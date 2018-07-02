using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationCore.Entities.Entities.Customer;
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
    [Route("api/customer")]
    [ValidateModel]
    public class CustomerController : Controller
    {

        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [Route("")]
        [HttpGet]
        public IActionResult List(int? page, int? itemsPage)
        {

            var membersModel = _customerService.GetCustomerList(page ?? 1, itemsPage);
            return Ok(membersModel);
        }

        [Route("")]
        [HttpPost]
        public IActionResult Save(customer customer)
        {
            var membersModel = _customerService.Save(customer);
            return Ok(membersModel);
        }

        [Route("{customerId:int}")]
        [HttpGet]
        public IActionResult Detail(int customerId)
        {
            var membersModel = _customerService.Get(customerId);
            if (membersModel == null)
                return NoContent();
            else
                return Ok(membersModel);
        }
    }
}