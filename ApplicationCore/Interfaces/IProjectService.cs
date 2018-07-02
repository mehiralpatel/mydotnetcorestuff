using ApplicationCore.Entities.Entities.Project;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Interfaces
{
    public interface IProjectService
    {
         ProjectResponse GetProjectList(int pageIndex, int? itemsPage);

        project Save(project project);

        project Get(int id);


    }
}
