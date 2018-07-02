using ApplicationCore.Entities.Entities.Customer;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Interfaces
{
    public interface ICustomerService
    {
        CustomerResponse GetCustomerList(int pageIndex, int? itemsPage);

        customer Save(customer customer);

        customer Get(int id);


    }
}
