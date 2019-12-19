using System;
using System.Linq;
using System.Linq.Expressions;
using AutoMapper;
using Delphinus_Yachts.Domain.Data;
using Delphinus_Yachts.Domain.Data.Entities;
using Delphinus_Yachts.Domain.Models;
using Delphinus_Yachts.Domain.Models.Table;

namespace Delphinus_Yachts.Domain.Services
{
    public class BookingService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public BookingService(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public DataAndCount<Booking> GetAll(TableFilter filter)
        {
            Expression<Func<Booking, bool>> searchBookingNumbers = x => true;
            if (!string.IsNullOrWhiteSpace(filter.Query))
            {
                searchBookingNumbers = x => x.Number.Contains(filter.Query);
            }

            var query = _context.Bookings
                .Where(searchBookingNumbers)
                .OrderBy(x => x.Id)
                .Skip((filter.Page - 1) * filter.Limit)
                .Take(filter.Limit);

            return new DataAndCount<Booking>
            {
                Data = query.ToList(),
                Count = query.Count()
            };
        }

        public BookingModel Get(int id)
        {
            var entity = _context.Bookings.SingleOrDefault(x => x.Id == id);

            return _mapper.Map<BookingModel>(entity);
        }

        public BookingModel Create(BookingModel model)
        {
            var entity = _mapper.Map<Booking>(model);

            _context.Bookings.Add(entity);
            _context.SaveChanges();

            model.Id = entity.Id;
            return model;
        }

        public BookingModel Update(BookingModel model)
        {
            var entity = _context.Bookings.SingleOrDefault(x => x.Id == model.Id);

            _mapper.Map(model, entity);
            _context.SaveChanges();

            return model;
        }

        public void Delete(int id)
        {
            var entity = _context.Bookings.SingleOrDefault(x => x.Id == id);

            _context.Bookings.Remove(entity);
            _context.SaveChanges();
        }
    }
}
