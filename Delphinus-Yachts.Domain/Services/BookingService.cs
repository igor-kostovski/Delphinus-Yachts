using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Delphinus_Yachts.Domain.Data;
using Delphinus_Yachts.Domain.Models;

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

        public List<BookingModel> GetAll()
        {
            var entities = _context.Bookings.ToList();

            return _mapper.Map<List<BookingModel>>(entities);
        }
    }
}
