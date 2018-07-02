using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationCore.Entities.Entities;
using ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    [EnableCors("SiteCorsPolicy")]
    [Produces("application/json")]
    [Route("api/combo")]
    public class ComboController : Controller
    {
        private readonly IComboService _comboService;

        public ComboController(IComboService comboService)
        {
            _comboService = comboService;
        }

        [Route("")]
        [HttpGet]
        public IActionResult List(int choice)
        {
            List<SelectListItemClass> list = new List<SelectListItemClass>();
            switch (choice)
            {
                case 1:
                    list = _comboService.CountryList();
                    break;
                case 2:
                    list = _comboService.CurrencyList();
                    break;
                case 3:
                    list = _comboService.ModelList();
                    break;
                case 4:
                    list = _comboService.ResourceList();
                    break;
                case 5:
                    list = _comboService.TechnologyList();
                    break;
                case 6:
                    list = _comboService.ResourceTypeList();
                    break;
                case 7:
                    list = _comboService.CustomerList();
                    break;
                case 8:
                    list = _comboService.SkillList();
                    break;
                case 9:
                    list = _comboService.BranchList();
                    break;
                case 10:
                    list = _comboService.RoleList();
                    break;
                case 11:
                    list = _comboService.DesignationList();
                    break;
                case 12:
                    list = _comboService.EmployeeStatusList();
                    break;
            }
            return Ok(list);
        }
        //[Route("")]
        //[HttpGet]
        //public IActionResult CurrencyList()
        //{
        //    var currency = _comboService.CurrencyList();
        //    return Ok(currency);
        //}
        //[Route("")]
        //[HttpGet]
        //public IActionResult ModelList()
        //{
        //    var model = _comboService.ModelList();
        //    return Ok(model);
        //}
        //[Route("")]
        //[HttpGet]
        //public IActionResult TechnologyList()
        //{
        //    var tech = _comboService.TechnologyList();
        //    return Ok(tech);
        //}
        //[Route("")]
        //[HttpGet]
        //public IActionResult ResourceList()
        //{
        //    var resource = _comboService.ResourceList();
        //    return Ok(resource);
        //}

    }
}