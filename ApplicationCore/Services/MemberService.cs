
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
    public class MemberService : IMemberService
    {
        private readonly ILogger<MemberService> _logger;

        //private IObjectConverter _converter;

        private readonly IRepository<Resource> _itemRepository;

    



        public MemberService(
          ILoggerFactory loggerFactory, IRepository<Resource> itemRepository

         )
        {
          //  this._converter = converter;
            this._itemRepository = itemRepository;
          

        }

        //public string GetMemberList(Dictionary<string, object> parameters)
        //{
        //    string response = string.Empty;

        //    var member =  _memberRepository.GetMemberList(parameters);

        //    response = this._converter.Serialize(member);

        //    return  response;
        //}

        public MemberListResponse GetMemberList(int pageIndex, int? pageSize)
        {

            var filterSpecification = new MemberWithSkillsSpecifications(statusId: (int)Enums.Status.Active);
            //  var members = _testRepository.GetMemberList(new Dictionary<string, object>());
            var root = _itemRepository.List(filterSpecification);

            var totalItems = root.Count();

            var itemsOnPage = root.Skip(pageSize ?? 0 * pageIndex).TakeIfNotNull(pageSize).OrderBy(x => x.Name).ToList();

            var vm = new MemberListResponse()
            {
                MemberList = itemsOnPage.Select(i => new Member()
                {
                    Id = i.ResourceId,
                    Name = i.Name,
                    //Skils = i.UserSkillTags.Select(s => new SelectListItem() { Text = s.Skill.Name, Value = (s.SkillId.HasValue ? s.SkillId.ToString() : string.Empty) }).ToList(),
                    SkillsCSV = string.Join(",", i.UserSkillTags.Select(x => x.Skill.Name)),
                    EmailAddress = i.EmailAddress,
                    Cost = i.Cost ?? 0,
                    ResourceType = i.ResourceType == null ? string.Empty : i.ResourceType.Name,
                    Technology = string.Join(",", i.ResourceTechnologyMap.Select(x => x.Technology.Name)) ,
                    Designation = i.Designation
                    //designation = i.Description
                    // Technology = i.TechnologyId
                }),
                PaginationInfo = new Entities.Entities.Member.PaginationInfoModel()
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

        public Member Save(Member member)
        {
            Resource resource = new Resource();
            resource = _itemRepository.GetById((int)member.Id);
            if (resource == null)
            {
                Resource newResource = new Resource();
                newResource.Name = member.Name;
                newResource.Address = member.Address;
                newResource.Mobile = member.Mobile;                
                newResource.EmailAddress = member.EmailAddress;
                newResource.Designation = member.Designation;
                //newResource.Cost = member.CostPerHour;
                newResource.Cost = member.Cost;
                newResource.CreatedDateTime = DateTime.UtcNow;
                newResource.LastModifiedDateTime = DateTime.UtcNow;
                newResource.CreatedByUserId = 2;
                newResource.LastModifiedByUserId = 2;
                newResource.Status = 1;
                newResource.JoinDate = string.IsNullOrWhiteSpace(member.JoinDate) ?DateTime.Now : DateTime.Parse(member.JoinDate);
                newResource.ReleventExp = member.ReleventExp;
                newResource.Exp = member.Exp;
                newResource.RelievingDate = string.IsNullOrWhiteSpace(member.RelievingDate) ? DateTime.Now : DateTime.Parse(member.RelievingDate);
                newResource.TechnologyId = member.TechnologyId;
                newResource.RoleId = member.RoleId;
                newResource.BranchId = member.BranchId;
                newResource.ReporteeResourceId = member.ReporteeResourceId;
                _itemRepository.Add(newResource);
            }
            else
            {                
                resource.Name = member.Name;
                resource.Address = member.Address;
                resource.Mobile = member.Mobile;
                resource.EmailAddress = member.EmailAddress;
                resource.Designation = member.Designation;
                //resource.Cost = member.CostPerHour;
                resource.Cost = member.Cost;
                resource.LastModifiedDateTime = DateTime.UtcNow;
                resource.LastModifiedByUserId = 2;
                resource.JoinDate = string.IsNullOrWhiteSpace(member.JoinDate) ? DateTime.Now : DateTime.Parse(member.JoinDate);
                resource.ReleventExp = member.ReleventExp;
                resource.Exp = member.Exp;
                resource.RelievingDate = string.IsNullOrWhiteSpace(member.RelievingDate) ? DateTime.Now : DateTime.Parse(member.RelievingDate);
                resource.TechnologyId = member.TechnologyId;
                resource.RoleId = member.RoleId;
                resource.BranchId = member.BranchId;
                resource.ReporteeResourceId = member.ReporteeResourceId;
                _itemRepository.Update(resource);
            }
            return member;
        }

        public Member Get(int id)
        {
            var resource = _itemRepository.GetById(Convert.ToInt64(id));
            if(resource != null)
                return new Member() { Id = resource.ResourceId,
                    Name = resource.Name,
                    SkillsCSV = string.Join(",", resource.UserSkillTags.Select(x => x.Skill.Name)),
                    Address = resource.Address,
                    BranchId = resource.BranchId,
                    Cost = resource.Cost,
                    //CostPerHour = resource.Cost ?? 0,
                    CreatedByUserId = resource.CreatedByUserId,
                    CreatedDateTime = resource.CreatedDateTime.ToString("yyyy/MM/dd"),
                    Cvurl = resource.Cvurl,
                    Description = resource.Description,
                    Designation = resource.Designation,
                    EmailAddress = resource.EmailAddress,
                    Exp = resource.Exp,
                    JobTitle = resource.JobTitle,
                    JoinDate = resource.JoinDate != null ? resource.JoinDate.Value.ToString("yyyy/MM/dd") : "" ,
                    LastModifiedByUserId = resource.LastModifiedByUserId,
                    LastModifiedDateTime = resource.LastModifiedDateTime.ToString("yyyy/MM/dd"),
                    Mobile =resource.Mobile,
                    ProfileUrl = resource.ProfileUrl,
                    RelievingDate = resource.RelievingDate != null ? resource.RelievingDate.Value.ToString("yyyy/MM/dd"): "",
                    ReleventExp = resource.ReleventExp,
                    ResourceId = resource.ResourceId,
                    ResourceTypeId = resource.ResourceTypeId,
                    RoleId = resource.RoleId,
                    Status = resource.Status,
                    TechnologyId = resource.TechnologyId,
                    Telephonenumber = resource.Telephonenumber,
                    ReporteeResourceId = resource.ReporteeResourceId ?? 0
                    //Url = resource.ProfileUrl
                };
            return null;
        }
    }
}
