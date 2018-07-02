
using ApplicationCore.Entities.Entities.Project;
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
    public class ProjectService : IProjectService 
    {
        private readonly ILogger<ProjectService> _logger;

        //private IObjectConverter _converter;

        private readonly IRepository<Project> _itemRepository;

        private readonly IProjectRepository _projectRepository;



        public ProjectService(
          ILoggerFactory loggerFactory, IRepository<Project> itemRepository, IProjectRepository projectRepository

         )
        {
            //  this._converter = converter;
            this._itemRepository = itemRepository;
            this._projectRepository = projectRepository;

        }

        //public string GetMemberList(Dictionary<string, object> parameters)
        //{
        //    string response = string.Empty;

        //    var member =  _memberRepository.GetMemberList(parameters);

        //    response = this._converter.Serialize(member);

        //    return  response;
        //}

        public ProjectResponse GetProjectList(int pageIndex, int? pageSize)
        {

            var filterSpecification = new ProjectwithDetailSpecification(statusId: (int)Enums.Status.Active);
            
            var root = _itemRepository.List(filterSpecification);

            var totalItems = root.Count();

            var itemsOnPage = root.Skip(pageSize ?? 0 * pageIndex).TakeIfNotNull(pageSize).OrderBy(x => x.Name).ToList();

            var vm = new ProjectResponse()
            {
                ProjectList = itemsOnPage.Select(i => new project()
                {
                   ProjectId = i.ProjectId,
                   Name = i.Name,
                   ProposalId= i.ProposalId,
                   Code = i.Code,
                  CustomerId = i.CustomerId,
                  Description = i.Description,
                  ModelId = i.ModelId,
                  StartDate = i.StartDate != null ? i.StartDate.Value.ToString("yyyy/MM/dd"):DateTime.Now.ToString("yyyy/MM/dd"),
                  State = i.State,
                  EndDate = i.EndDate != null ? i.EndDate.Value.ToString("yyyy/MM/dd"): DateTime.Now.ToString("yyyy/MM/dd"),
                  Status = i.Status,
                  CreatedByUserId = i.CreatedByUserId,
                  CreatedDateTime = i.CreatedDateTime,
                  LastModifiedByUserId = i.LastModifiedByUserId,
                  LastModifiedDateTime = i.LastModifiedDateTime,
                  TechnologyId = i.TechnologyId,
                  CustomerName = i.Customer != null ? i.Customer.Name:"n/a",
                    ModelName = i.Model != null ? i.Model.Name : "n/a",
                  Technology = i.Technology != null ? i.Technology.Name : "n/a",
                  PrimaryReposting = "",
                  SecondaryReporting = ""
                }),
                PaginationInfo = new Entities.Entities.Project.PaginationInfoModel()
                {
                    CurrentPage = pageIndex,
                    ItemsPerPage = itemsOnPage.Count,
                    TotalItems = totalItems,
                    TotalPages = int.Parse(Math.Ceiling(((decimal)totalItems / pageSize ?? 1)).ToString())
                }
            };
            return vm;
            
        }
        
        public project Save(project project)
        {
            Project proj = new Project();
            proj = _itemRepository.GetById((int)project.ProjectId);
            if (proj == null)
            {
                Project newProject = new Project();
                newProject.Name = project.Name;
                newProject.Code = project.Code;
                newProject.CreatedByUserId = 2;
                newProject.CreatedDateTime = DateTime.UtcNow;
                newProject.CustomerId = project.CustomerId;
                newProject.Description = project.Description;
                newProject.EndDate = DateTime.Parse(project.EndDate);
                newProject.LastModifiedByUserId = 2;
                newProject.LastModifiedDateTime = DateTime.UtcNow;
                newProject.ModelId = project.ModelId;
                newProject.State = project.State;
                newProject.Status = 1;
                newProject.TechnologyId = project.TechnologyId;
                newProject.ProposalId = project.ProposalId;                
                newProject.StartDate = DateTime.Parse(project.StartDate);
                _itemRepository.Add(newProject);
            }
            else
            {
                proj.Name = project.Name;
                proj.Code = project.Code;
                proj.CreatedByUserId = project.CreatedByUserId;
                
                proj.CustomerId = project.CustomerId;
                proj.Description = project.Description;
                proj.EndDate = DateTime.Parse(project.EndDate);
                proj.LastModifiedByUserId = project.LastModifiedByUserId;
                proj.LastModifiedDateTime = DateTime.UtcNow;
                proj.ModelId = project.ModelId;
                proj.State = project.State;
                proj.Status = 1;
                proj.TechnologyId = project.TechnologyId;
                proj.ProposalId = project.ProposalId;
                proj.StartDate = DateTime.Parse(project.StartDate);
                _itemRepository.Update(proj);
            }
            return project;
        }

        public project Get(int id)
        {
            var project = _itemRepository.GetById(Convert.ToInt64(id));
            if (project != null)
                return new project()
                {
                    CustomerId = project.CustomerId,
                    Name = project.Name,
                    Code = project.Code,
                    CreatedByUserId= project.CreatedByUserId,
                    CreatedDateTime= project.CreatedDateTime,
                    Description= project.Description,
                    EndDate= project.EndDate.ToString(),
                    LastModifiedByUserId= project.LastModifiedByUserId,
                    LastModifiedDateTime= project.LastModifiedDateTime,
                    ModelId= project.ModelId,
                    ProjectId = project.ProjectId,
                    ProposalId = project.ProposalId,
                    StartDate = project.StartDate.ToString(),
                    State= project.State,
                    Status= project.Status,
                    TechnologyId= project.TechnologyId
                };
            return null;
        }
    }
}
