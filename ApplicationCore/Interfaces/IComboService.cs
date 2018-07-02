using ApplicationCore.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCore.Interfaces
{
    public interface IComboService
    {
        List<SelectListItemClass> CountryList();
        List<SelectListItemClass> CurrencyList();
        List<SelectListItemClass> TechnologyList();
        List<SelectListItemClass> ResourceList();
        List<SelectListItemClass> ModelList();
        List<SelectListItemClass> CustomerList();
        List<SelectListItemClass> ResourceTypeList();
        List<SelectListItemClass> SkillList();
        List<SelectListItemClass> BranchList();
        List<SelectListItemClass> RoleList();
        List<SelectListItemClass> DesignationList();
        List<SelectListItemClass> EmployeeStatusList();
    }
}
