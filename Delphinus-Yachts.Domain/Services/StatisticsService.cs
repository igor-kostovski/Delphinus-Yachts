using System.Linq;
using AutoMapper;
using Delphinus_Yachts.Domain.Data;
using Delphinus_Yachts.Domain.Data.Enums;
using Delphinus_Yachts.Domain.Models;
using Delphinus_Yachts.Domain.Models.Statistics;

namespace Delphinus_Yachts.Domain.Services
{
    public class StatisticsService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public StatisticsService(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public StatisticsModel Get()
        {
            var annualEarnings = _context
                .Contracts
                .Sum(x => x.Price);

            var monthlyEarnings = annualEarnings / 12;

            var totalPassengersNumber = _context
                .Bookings
                .Sum(x => 200);

            var bookingsByStatus = _context
                .Bookings
                .GroupBy(x => x.Status);

            var countByStatus = new CountByStatus
            {
                CompleteBookingsNumber = bookingsByStatus.Count(x => x.Key == BookingStatus.Complete),
                OptionalBookingsNumber = bookingsByStatus.Count(x => x.Key == BookingStatus.Optional),
                CancelledBookingsNumber = bookingsByStatus.Count(x => x.Key == BookingStatus.Cancelled)
            };

            return new StatisticsModel
            {
                AnnualEarnings = annualEarnings,
                MonthlyEarnings = monthlyEarnings,
                TotalNumberOfPassengers = totalPassengersNumber,
                CountByStatus = countByStatus
            };
        }
    }
}
