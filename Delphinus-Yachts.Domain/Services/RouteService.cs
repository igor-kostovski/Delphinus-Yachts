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
    public class RouteService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public RouteService(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public DataAndCount<Route> GetAll(TableFilter filter)
        {
            Expression<Func<Route, bool>> searchRouteNames = x => true;
            if (!string.IsNullOrWhiteSpace(filter.Query))
            {
                searchRouteNames = x => x.Name.Contains(filter.Query);
            }

            var query = _context.Routes
                .Where(searchRouteNames)
                .OrderBy(x => x.Id)
                .Skip((filter.Page - 1) * filter.Limit)
                .Take(filter.Limit);

            return new DataAndCount<Route>
            {
                Data = query.ToList(),
                Count = _context.Bookings.Count()
            };
        }

        public RouteModel Get(int id)
        {
            var entity = _context.Routes
                .Include(x => x.Locations)
                .SingleOrDefault(x => x.Id == id);

            return _mapper.Map<RouteModel>(entity);
        }

        public RouteModel Create(RouteModel model)
        {
            var entity = _mapper.Map<Route>(model);

            _context.Routes.Add(entity);
            _context.SaveChanges();

            model.Id = entity.Id;
            return model;
        }

        public RouteModel Update(RouteModel model)
        {
            var entity = _context.Routes.SingleOrDefault(x => x.Id == model.Id);

            _mapper.Map(model, entity);
            _context.SaveChanges();

            return model;
        }

        public void Delete(int id)
        {
            var entity = _context.Routes.SingleOrDefault(x => x.Id == id);

            _context.Routes.Remove(entity);
            _context.SaveChanges();
        }
    }
}
