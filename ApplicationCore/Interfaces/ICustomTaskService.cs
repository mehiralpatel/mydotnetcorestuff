using ApplicationCore.Entities.Entities.CustomTask;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Interfaces
{
    public interface ICustomTaskService
    {
         CustomTaskResponse GetCustomTaskList(int pageIndex, int? itemsPage);

        Customtask Save(Customtask customtask);

        Customtask Get(int id);


    }
}
