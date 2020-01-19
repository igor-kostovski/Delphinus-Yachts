using System;
using System.Linq;
using System.Linq.Expressions;
using AutoMapper;
using Delphinus_Yachts.Domain.Data;
using Delphinus_Yachts.Domain.Data.Entities;
using Delphinus_Yachts.Domain.Models;
using Delphinus_Yachts.Domain.Models.Table;
using System.Data.Entity;

namespace Delphinus_Yachts.Domain.Services
{
    public class LocationService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public LocationService(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public DataAndCount<Location> GetAll(TableFilter filter)
        {
            Expression<Func<Location, bool>> searchLocationNames = x => true;
            if (!string.IsNullOrWhiteSpace(filter.Query))
            {
                searchLocationNames = x => x.Name.Contains(filter.Query);
            }

            var query = _context.Locations
                .Where(searchLocationNames)
                .OrderBy(x => x.Id)
                .Skip((filter.Page - 1) * filter.Limit)
                .Take(filter.Limit);

            return new DataAndCount<Location>
            {
                Data = query.ToList(),
                Count = _context.Locations.Count()
            };
        }

        public LocationModel Get(int id)
        {
            var entity = _context.Locations
                .Include(x => x.Routes)
                .SingleOrDefault(x => x.Id == id);

            return _mapper.Map<LocationModel>(entity);
        }

        public LocationModel Create(LocationModel model)
        {
            var entity = _mapper.Map<Location>(model);

            _context.Locations.Add(entity);
            _context.SaveChanges();

            model.Id = entity.Id;
            return model;
        }

        public LocationModel Update(LocationModel model)
        {
            var entity = _context.Locations.SingleOrDefault(x => x.Id == model.Id);

            _mapper.Map(model, entity);
            _context.SaveChanges();

            return model;
        }

        public void Delete(int id)
        {
            var entity = _context.Locations.SingleOrDefault(x => x.Id == id);

            _context.Locations.Remove(entity);
            _context.SaveChanges();
        }
    }
}
