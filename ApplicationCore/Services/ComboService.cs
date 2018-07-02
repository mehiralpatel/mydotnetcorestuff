
using ApplicationCore.Entities.Entities;
using ApplicationCore.Entities.Entities.Proposal;
using ApplicationCore.Interfaces;
using ApplicationCore.Specifications;
using Common.Extension;
using Infrastructure.Data;
using Microsoft.Extensions.Logging;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ApplicationCore.Entities.Entities.Enums;

namespace ApplicationCore.Services
{
    public class ComboService : IComboService
    {
        private readonly IRepository<Country> _CountryList;
        private readonly IRepository<Currency> _CurrencyList;
        private readonly IRepository<Resource> _ResourceList;
        private readonly IRepository<Model> _ModelList;
        private readonly IRepository<Technology> _TechnologyList;
        private readonly IRepository<Customer> _CustomerList;
        private readonly IRepository<ResourceType> _ResourceTypeList;
        private readonly IRepository<Skill> _SkillList;
        private readonly IRepository<Branch> _BranchList;
        private readonly IRepository<Role> _RoleList;

        public ComboService(
          ILoggerFactory loggerFactory, IRepository<Currency> CurrencyList, IRepository<Country> CountryList, IRepository<Resource> ResourceList, IRepository<Model> ModelList, IRepository<Technology> TechnologyList,
          IRepository<Customer> CustomerList, IRepository<ResourceType> ResourceTypeList, IRepository<Skill> SkillList, IRepository<Branch> BranchList, IRepository<Role> RoleList

         )
        {
            //  this._converter = converter;
            this._SkillList = SkillList;
            this._CountryList = CountryList;
            this._CurrencyList = CurrencyList;
            this._ResourceList = ResourceList;
            this._ModelList = ModelList;
            this._TechnologyList = TechnologyList;
            this._ResourceTypeList = ResourceTypeList;
            this._CustomerList = CustomerList;
            this._BranchList = BranchList;
            this._RoleList = RoleList;
        }

        public List<SelectListItemClass> BranchList()
        {
            var Branchlist = _BranchList.ListAll().Select(x => new SelectListItemClass
            {
                Id = (int)x.BranchId,
                Value = x.BranchName
            });

            return Branchlist.ToList();
        }

        public List<SelectListItemClass> CountryList()
        {
            var Countrylist = _CountryList.ListAll().Select(x => new SelectListItemClass
            {
                Id = x.CountryId,
                Value = x.Name
            });

            return Countrylist.ToList();
        }

        public List<SelectListItemClass> CurrencyList()
        {
            var Currencylist = _CurrencyList.ListAll().Select(x => new SelectListItemClass
            {
                Id = x.CurrencyId,
                Value = x.Name
            });

            return Currencylist.ToList();
        }

        public List<SelectListItemClass> CustomerList()
        {
            var customerlist = _CustomerList.ListAll().Select(x => new SelectListItemClass
            {
                Id = (int)x.CustomerId,
                Value = x.Name
            });

            return customerlist.ToList();
        }

        public List<SelectListItemClass> DesignationList()
        {
            Array values = Enum.GetValues(typeof(DesignationEnum));
            List<SelectListItemClass> items = new List<SelectListItemClass>(values.Length);

            for (var i = 0; i < values.Length; i++)
            {
                items.Add(new SelectListItemClass
                {
                    Value = Enum.GetName(typeof(DesignationEnum), i+1),
                    Id = i+1
                });
            }
            return items;
        }

        public List<SelectListItemClass> EmployeeStatusList()
        {
            Array values = Enum.GetValues(typeof(EmployeeStatus));
            List<SelectListItemClass> items = new List<SelectListItemClass>(values.Length);

            for(var i=0;i < values.Length; i++)
            {
                items.Add(new SelectListItemClass
                {
                    Value = Enum.GetName(typeof(EmployeeStatus), i+1),
                    Id = i+1
                });
            }
            return items;
        }

        public List<SelectListItemClass> ModelList()
        {
            var Modellist = _ModelList.ListAll().Select(x => new SelectListItemClass
            {
                Id = x.ModelId,
                Value = x.Name
            });

            return Modellist.ToList();
        }

        public List<SelectListItemClass> ResourceList()
        {
            var Resourcelist = _ResourceList.ListAll().Select(x => new SelectListItemClass
            {
                Id = (int)x.ResourceId,
                Value = x.Name
            });

            return Resourcelist.ToList();
        }

        public List<SelectListItemClass> ResourceTypeList()
        {
            var resourcetype = _ResourceTypeList.ListAll().Select(x => new SelectListItemClass
            {
                Id = (int)x.ResourceTypeId,
                Value = x.Name
            });

            return resourcetype.ToList();
        }

        public List<SelectListItemClass> RoleList()
        {
            var Rolelist = _RoleList.ListAll().Select(x => new SelectListItemClass
            {
                Id = (int)x.RoleId,
                Value = x.Name
            });

            return Rolelist.ToList();
        }

        public List<SelectListItemClass> SkillList()
        {
            var Skilllist = _SkillList.ListAll().Select(x => new SelectListItemClass
            {
                Id = (int)x.SkillId,
                Value = x.Name
            });

            return Skilllist.ToList();
        }

        public List<SelectListItemClass> TechnologyList()
        {
            var Technologylist = _TechnologyList.ListAll().Select(x => new SelectListItemClass
            {
                Id = (int)x.TechnologyId,
                Value = x.Name
            });

            return Technologylist.ToList();
        }
    }
}
