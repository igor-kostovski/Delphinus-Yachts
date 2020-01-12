using System;
using System.Data.Entity.Core.EntityClient;
using System.Linq;
using System.Linq.Expressions;
using AutoMapper;
using Delphinus_Yachts.Domain.Data;
using Delphinus_Yachts.Domain.Data.Entities;
using Delphinus_Yachts.Domain.Models;
using Delphinus_Yachts.Domain.Models.Table;

namespace Delphinus_Yachts.Domain.Services
{
    public class ContractService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public ContractService(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public DataAndCount<Contract> GetAll(TableFilter filter)
        {
            Expression<Func<Contract, bool>> searchExpression = x => true;

            if (!string.IsNullOrWhiteSpace(filter.Query))
            {
                searchExpression = x => x.PayingPassenger.Contains(filter.Query);
            }

            var query = _context.Contracts
                .Where(searchExpression)
                .OrderBy(x => x.Id)
                .Skip((filter.Page - 1) * filter.Limit)
                .Take(filter.Limit);

            return new DataAndCount<Contract>
            {
                Data = query.ToList(),
                Count = _context.Contracts.Count()
            };
        }

        public ContractModel Get(int id)
        {
            var entity = _context.Contracts.SingleOrDefault(x => x.Id == id);

            return _mapper.Map<ContractModel>(entity);
        }

        public ContractModel Update(ContractModel model)
        {
            var entity = _context.Contracts.SingleOrDefault(x => x.Id == model.Id);

            _mapper.Map(model, entity);
            _context.SaveChanges();

            return model;
        }

        public ContractModel Create(ContractModel model)
        {
            var entity = _mapper.Map<Contract>(model);

            _context.Contracts.Add(entity);
            _context.SaveChanges();

            model.Id = entity.Id;
            return model;
        }

        public void Delete(int id)
        {
            var entity = _context.Contracts.SingleOrDefault(x => x.Id == id);

            _context.Contracts.Remove(entity);
            _context.SaveChanges();
        }
    }
}
