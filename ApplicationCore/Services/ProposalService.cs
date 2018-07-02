
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


namespace ApplicationCore.Services
{
    public class ProposalService : IProposalService
    {
        private readonly ILogger<ProposalService> _logger;

        //private IObjectConverter _converter;

        private readonly IRepository<Proposal> _itemRepository;

        private readonly IProposalRepository _proposalRepository;

        public ProposalService(
          ILoggerFactory loggerFactory, IRepository<Proposal> itemRepository, IProposalRepository proposalRepository

         )
        {
            //  this._converter = converter;

            this._itemRepository = itemRepository;
            this._proposalRepository = proposalRepository;

        }

        //public string GetMemberList(Dictionary<string, object> parameters)
        //{
        //    string response = string.Empty;

        //    var member =  _memberRepository.GetMemberList(parameters);

        //    response = this._converter.Serialize(member);

        //    return  response;
        //}

        public ProposalResponse GetProposalList(int pageIndex, int? pageSize)
        {

            var filterSpecification = new ProposalwithDetailSpecification(statusId: (int)Common.Extension.Enums.Status.Active);
            //  var members = _testRepository.GetMemberList(new Dictionary<string, object>());
            var root = _itemRepository.List(filterSpecification);

            var totalItems = root.Count();

            var itemsOnPage = root.Skip(pageSize ?? 0 * pageIndex).TakeIfNotNull(pageSize).OrderBy(x => x.ProposalRef).ToList();

            var vm = new ProposalResponse()
            {
                ProposalList = itemsOnPage.Select(i => new proposal()
                {
                    ProposalId = i.ProposalId,
                    ProposalAmount = i.ProposalAmount,
                    ProposalDate = i.ProposalDate,
                    SignoffAmount = i.SignoffAmount,
                    SignoffDate = i.SignoffDate.ToString("yyyy/MM/dd"),
                    Title = i.Title,
                    ProposalRef = i.ProposalRef,
                    CurrencyId = i.CurrencyId,
                    CustomerId = i.CustomerId,
                    ModelId = i.ModelId,
                    Status = i.Status,
                    CreatedByUserId = i.CreatedByUserId,
                    CreatedDateTime = i.CreatedDateTime,
                    LastModifiedByUserId = i.LastModifiedByUserId,
                    LastModifiedDateTime = i.LastModifiedDateTime,
                    CurrencyName = i.Currency.Name,//_proposalRepository.GetCurrencyName(i.CurrencyId),
                    CustomerName = i.Customer.Name,//_proposalRepository.GetCustomerName((int)i.CustomerId),
                    ModelName = string.Join(",", i.Project.Select(x => x.Model.Name)),//_proposalRepository.GetModelName(i.ModelId),
                    Technology = string.Join(",", i.ProposalTechnologyMap.Select(x => x.Technology.Name)) //_proposalRepository.GetTechnologies(i.ProposalId)
                }),
                PaginationInfo = new Entities.Entities.Proposal.PaginationInfoModel()
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

        public proposal Save(proposal proposal)
        {
            Proposal prop = new Proposal();
            prop = _itemRepository.GetId((int)proposal.ProposalId);
            if (prop == null)
            {
                Proposal newProposal = new Proposal();
                newProposal.CreatedByUserId = proposal.CreatedByUserId;
                newProposal.CreatedDateTime = DateTime.UtcNow;
                newProposal.CurrencyId = proposal.CurrencyId;
                newProposal.CustomerId = proposal.CustomerId;
                newProposal.LastModifiedByUserId = proposal.LastModifiedByUserId;
                newProposal.LastModifiedDateTime = DateTime.UtcNow;
                newProposal.ModelId = proposal.ModelId;
                newProposal.ProposalAmount = proposal.ProposalAmount;
                newProposal.ProposalDate = proposal.ProposalDate;
                newProposal.ProposalRef = proposal.ProposalRef;
                newProposal.SignoffAmount = proposal.SignoffAmount;
                newProposal.SignoffDate = DateTime.Parse(proposal.SignoffDate);
                newProposal.Status = 1;
                newProposal.Title = proposal.Title;

                _itemRepository.Add(newProposal);
            }
            else
            {
                //prop.CreatedByUserId = proposal.CreatedByUserId;
                //prop.CreatedDateTime = DateTime.UtcNow;
                prop.CurrencyId = proposal.CurrencyId;
                prop.CustomerId = proposal.CustomerId;
                prop.LastModifiedByUserId = proposal.LastModifiedByUserId;
                prop.LastModifiedDateTime = DateTime.UtcNow;
                prop.ModelId = proposal.ModelId;
                prop.ProposalAmount = proposal.ProposalAmount;
                prop.ProposalDate = proposal.ProposalDate;
                prop.ProposalRef = proposal.ProposalRef;
                prop.SignoffAmount = proposal.SignoffAmount;
                prop.SignoffDate = DateTime.Parse(proposal.SignoffDate);
                prop.Status = proposal.Status;
                prop.Title = proposal.Title;

                _itemRepository.Update(prop);
            }
            return proposal;
        }

        public proposal Get(int id)
        {
            var proposal = _itemRepository.GetId(id);
            if (proposal != null)
                return new proposal()
                {
                    ProposalId = proposal.ProposalId,
                    ProposalRef = proposal.ProposalRef,
                    CreatedByUserId = proposal.CreatedByUserId,
                    CreatedDateTime = proposal.CreatedDateTime,
                    CurrencyId = proposal.CurrencyId,
                    CustomerId = proposal.CustomerId,
                    LastModifiedByUserId = proposal.LastModifiedByUserId,
                    LastModifiedDateTime = proposal.LastModifiedDateTime,
                    ModelId = proposal.ModelId,
                    ProposalAmount = proposal.ProposalAmount,
                    ProposalDate = proposal.ProposalDate,
                    SignoffAmount = proposal.SignoffAmount,
                    SignoffDate = proposal.SignoffDate.ToString(),
                    Status = proposal.Status,
                    Title = proposal.Title
                };
            return null;
        }


    }
}
