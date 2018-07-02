using ApplicationCore.Interfaces;
using ApplicationCore.Specifications;
using Common.Extension;
using Infrastructure.Data;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using ObjectConverter.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Interfaces;
using WebApplication1.ViewModel.Member;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.DataProtection.KeyManagement;
using System.Linq.Expressions;

namespace WebApplication1.Services
{
    public class MemberService : WebApplication1.Interfaces.IMemberService
    {
        private readonly ILogger<MemberService> _logger;

        private IObjectConverter _converter;

        private readonly IRepository<Resource> _itemRepository;

        private readonly IMemberRepository _memberRepository;
        


        public MemberService(
          ILoggerFactory loggerFactory, IObjectConverter converter, IRepository<Resource> itemRepository, IMemberRepository memberRepository
            
         )
        {
            this._converter = converter;
            this._itemRepository = itemRepository;
            this._memberRepository = memberRepository;
        
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
            var root =  _itemRepository.List(filterSpecification);

            var totalItems = root.Count();

            var itemsOnPage = root.Skip(pageSize ?? 0 * pageIndex).TakeIfNotNull(pageSize).OrderBy(x => x.Name).ToList();

            var vm = new MemberListResponse()
            {
                MemberList = itemsOnPage.Select(i => new Member()
                {
                    Id = i.ResourceId,
                    Name = i.Name,
                    //Skils = i.UserSkillTags.Select(s => new SelectListItem() { Text = s.Skill.Name, Value = (s.SkillId.HasValue ? s.SkillId.ToString() : string.Empty) }).ToList(),
                    SkillsCSV = string.Join(",", i.UserSkillTags.Select(x => x.Skill.Name))
                }),
                PaginationInfo = new Infrastructure.Data.PaginationInfoModel()
                {
                    CurrentPage = pageIndex,
                    ItemsPerPage = itemsOnPage.Count,
                    TotalItems = totalItems,
                    TotalPages = int.Parse(Math.Ceiling(((decimal)totalItems / pageSize ?? 1)).ToString())
                }
            };

            return vm;
        }

        public Member Save(Member member)
        {
            var resource = _itemRepository.GetById(member.Id);
            resource.Name = member.Name;
            _itemRepository.Update(resource);
            return member;
        }
    }
}
