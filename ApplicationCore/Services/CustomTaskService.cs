
using ApplicationCore.Entities.Entities.CustomTask;
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
using static ApplicationCore.Entities.Entities.CustomTask.Enum;

namespace ApplicationCore.Services
{
    public class CustomTaskService : ICustomTaskService 
    {
        private readonly ILogger<CustomTaskService> _logger;

        //private IObjectConverter _converter;

        private readonly IRepository<CustomTask> _itemRepository;
        private readonly IRepository<Resource> _itemResourceRepo;

        private readonly ICustomTaskRepository _customtaskRepository;



        public CustomTaskService(
          ILoggerFactory loggerFactory, IRepository<CustomTask> itemRepository, ICustomTaskRepository customtaskRepository, IRepository<Resource> itemResourceRepo

         )
        {
            //  this._converter = converter;
            this._itemResourceRepo = itemResourceRepo;
            this._itemRepository = itemRepository;
            this._customtaskRepository = customtaskRepository;

        }

        //public string GetMemberList(Dictionary<string, object> parameters)
        //{
        //    string response = string.Empty;

        //    var member =  _memberRepository.GetMemberList(parameters);

        //    response = this._converter.Serialize(member);

        //    return  response;
        //}

        public CustomTaskResponse GetCustomTaskList(int pageIndex, int? pageSize)
        {

            var filterSpecification = new CustomTaskWithResourceData(statusId: (int)Enums.Status.Active);
            //  var members = _testRepository.GetMemberList(new Dictionary<string, object>());
            var root = _itemRepository.List(filterSpecification);

            var totalItems = root.Count();

            var itemsOnPage = root.Skip(pageSize ?? 0 * pageIndex).TakeIfNotNull(pageSize).OrderBy(x => x.CustomTaskName).ToList();

            var vm = new CustomTaskResponse()
            {
                CustomTaskList = itemsOnPage.Select(i => new Customtask()
                {
                    CustomTaskId = i.CustomTaskId,
                    CustomTaskName = i.CustomTaskName,
                    Description = i.Description,
                    DueDate = i.DueDate != null ? i.DueDate.Value.ToString("yyyy/MM/dd"):DateTime.Now.ToString("yyyy/MM/dd"),
                    CreatedByUserId = i.CreatedByUserId,
                    CreatedDateTime = i.CreatedDateTime,
                    Status = i.Status,
                    LastModifiedByUserId=i.LastModifiedByUserId,
                    LastModifiedDateTime = i.LastModifiedDateTime,
                    ResourceId = i.ResourceId,
                    ResourceName = i.Resource.Name,
                    StatusName = System.Enum.GetName(typeof(CustomTaskStatus),i.Status)
        }),
                PaginationInfo = new Entities.Entities.CustomTask.PaginationInfoModel()
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

        public Customtask Save(Customtask customTask)
        {
            CustomTask cust_task = new CustomTask();
            cust_task = _itemRepository.GetId(customTask.CustomTaskId);
            if (cust_task == null)
            {
                CustomTask newCustomTask = new CustomTask();
                newCustomTask.Description = customTask.Description;
                newCustomTask.DueDate = DateTime.Parse(customTask.DueDate);
                newCustomTask.ResourceId = customTask.ResourceId;
                newCustomTask.Status = 1;
                newCustomTask.CustomTaskName = customTask.CustomTaskName;
                newCustomTask.CreatedByUserId = customTask.CreatedByUserId;
                newCustomTask.CreatedDateTime = DateTime.UtcNow;
                newCustomTask.LastModifiedDateTime = DateTime.UtcNow;
                newCustomTask.LastModifiedByUserId = customTask.LastModifiedByUserId;

                _itemRepository.Add(newCustomTask);
            }
            else
            {
                cust_task.Description = customTask.Description;
                cust_task.DueDate = DateTime.Parse(customTask.DueDate);
                cust_task.ResourceId = customTask.ResourceId;
                cust_task.Status = 1;
                cust_task.CustomTaskName = customTask.CustomTaskName;
                cust_task.LastModifiedDateTime = DateTime.UtcNow;
                cust_task.LastModifiedByUserId = customTask.LastModifiedByUserId;
                _itemRepository.Update(cust_task);
            }
            return customTask;
        }

        public Customtask Get(int id)
        {
            var customTask = _itemRepository.GetId(id);
            if (customTask != null)
                return new Customtask() { CustomTaskId = customTask.CustomTaskId,
                    CustomTaskName = customTask.CustomTaskName,
                    Description = customTask.Description,
                    DueDate = customTask.DueDate.ToString(),
                    ResourceId = customTask.ResourceId,
                    CreatedByUserId = customTask.CreatedByUserId,
                    LastModifiedByUserId = customTask.LastModifiedByUserId,
                    CreatedDateTime = customTask.CreatedDateTime,
                    LastModifiedDateTime = customTask.LastModifiedDateTime,
                    Status= customTask.Status
                };
            return null;
        }
    }
}
