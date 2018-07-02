
using ApplicationCore.Entities.Entities.Customer;
using ApplicationCore.Entities.Entities.Member;
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


namespace ApplicationCore.Services
{
    public class CustomerService : ICustomerService 
    {
        private readonly ILogger<CustomerService> _logger;

        //private IObjectConverter _converter;

        private readonly IRepository<Customer> _itemRepository;

        //private readonly ICustomerRepository _customerRepository;



        public CustomerService(
          ILoggerFactory loggerFactory, IRepository<Customer> itemRepository, ICustomerRepository customerRepository

         )
        {
            //  this._converter = converter;
            this._itemRepository = itemRepository;
           // this._customerRepository = customerRepository;

        }

        //public string GetMemberList(Dictionary<string, object> parameters)
        //{
        //    string response = string.Empty;

        //    var member =  _memberRepository.GetMemberList(parameters);

        //    response = this._converter.Serialize(member);

        //    return  response;
        //}

        public CustomerResponse GetCustomerList(int pageIndex, int? pageSize)
        {

            var filterSpecification = new CustomerWithCountryData(statusId: (int)Enums.Status.Active);
            //  var members = _testRepository.GetMemberList(new Dictionary<string, object>());
            var root = _itemRepository.List(filterSpecification);

            var totalItems = root.Count();

            var itemsOnPage = root.Skip(pageSize ?? 0 * pageIndex).TakeIfNotNull(pageSize).OrderBy(x => x.Name).ToList();

            var vm = new CustomerResponse()
            {
                CustomerList = itemsOnPage.Select(i => new customer()
                {
                    CustomerId = i.CustomerId,
                     Name = i.Name,
                     Description = i.Description,
                     Status = i.Status,
                     CountryName = i.Country.Name,
                     CreatedByUserId = i.CreatedByUserId,
                     CreatedDateTime = i.CreatedDateTime,
                     LastModifiedByUserId = i.LastModifiedByUserId,
                     LastModifiedDateTime = i.LastModifiedDateTime,
                     CountryId = i.CountryId
            }),
                PaginationInfo = new Entities.Entities.Customer.PaginationInfoModel()
                {
                    CurrentPage = pageIndex,
                    ItemsPerPage = itemsOnPage.Count,
                    TotalItems = totalItems,
                    TotalPages = int.Parse(Math.Ceiling(((decimal)totalItems / pageSize ?? 1)).ToString())
                }
            };
            return vm;
            // return _converter.Serialize(vm);
        }

        public customer Save(customer customer)
        {
            Customer cust = new Customer();
            cust = _itemRepository.GetById(Convert.ToInt32(customer.CustomerId));
            if (cust == null)
            {
                Customer newCustomer = new Customer();
                newCustomer.Description = customer.Description;
                newCustomer.Name = customer.Name;
                newCustomer.Status = 1;
                newCustomer.CountryId = customer.CountryId;
                newCustomer.CreatedByUserId = 2;
                newCustomer.CreatedDateTime = DateTime.UtcNow;
                newCustomer.LastModifiedDateTime = DateTime.UtcNow;
                newCustomer.LastModifiedByUserId = 2;

                _itemRepository.Add(newCustomer);
            }
            else
            {
                cust.Description = customer.Description;
                cust.Name = customer.Name;
                cust.Status = 1;
                cust.CountryId = customer.CountryId;
                cust.LastModifiedDateTime = DateTime.UtcNow;
                cust.LastModifiedByUserId = 2;
                _itemRepository.Update(cust);
            }
            return customer;
        }

        public customer Get(int id)
        {
            var cust_data = _itemRepository.GetById(Convert.ToInt64(id));
            if (cust_data != null)
                return new customer() {
                    CustomerId = cust_data.CustomerId,
                    Name = cust_data.Name,
                    CountryId =cust_data.CountryId,
                    Description = cust_data.Description,
                    Status = cust_data.Status,
                    CreatedByUserId = cust_data.CreatedByUserId,
                    CreatedDateTime = cust_data.CreatedDateTime,
                    LastModifiedByUserId = cust_data.LastModifiedByUserId,
                    LastModifiedDateTime = cust_data.LastModifiedDateTime, };
            return null;
        }
    }
}
