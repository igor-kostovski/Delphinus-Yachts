using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using AutoMapper;
using Delphinus_Yachts.Domain.Data;
using Delphinus_Yachts.Domain.Data.Entities;
using Delphinus_Yachts.Domain.Models;
using Delphinus_Yachts.Domain.Models.Statistics;
using System.Data.Entity;
using System.Globalization;

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
            Expression<Func<Booking, bool>> yearFilter = x => x.StartDate.Year == 2019;/*DateTime.Now.Year;*/

            var annualEarnings = _context
                .Bookings
                .Include(x => x.Contract)
                .Where(yearFilter)
                .Sum(x => x.Contract.Price);

            var monthlyEarnings = annualEarnings / 12;

            var earningsPerMonth = GetEarningsPerMonth(yearFilter);

            var doneBookings = _context
                .Bookings
                .Where(yearFilter)
                .Where(x => x.StatusAsString == "Complete")
                .Count(x => x.EndDate <= DateTime.Now);

            var doneBookingsPercentage = (double)doneBookings / 
                 _context
                    .Bookings
                    .Where(yearFilter)
                    .Where(x => x.StatusAsString == "Complete")
                    .Count() * 100;

            var bookingsByStatus = _context
                .Bookings
                .Where(yearFilter)
                .GroupBy(x => x.StatusAsString)
                .Select(x => new
                {
                    x.Key,
                    Count = x.Count()
                });

            var countByStatus = new CountByStatus
            {
                CompleteBookingsNumber = bookingsByStatus.SingleOrDefault(x => x.Key == "Complete")?.Count ?? 0,
                OptionalBookingsNumber = bookingsByStatus.SingleOrDefault(x => x.Key == "Optional")?.Count ?? 0,
                CancelledBookingsNumber = bookingsByStatus.SingleOrDefault(x => x.Key == "Cancelled")?.Count ?? 0
            };

            return new StatisticsModel
            {
                AnnualEarnings = Math.Round(annualEarnings,2),
                MonthlyEarnings = Math.Round(monthlyEarnings,2),
                CountByStatus = countByStatus,
                DoneBookingsPercentage = Math.Round(doneBookingsPercentage,2),
                EarningsPerMonth = earningsPerMonth
            };
        }

        private Dictionary<string, double> GetEarningsPerMonth(Expression<Func<Booking, bool>> yearFilter)
        {
            var earningsPerMonth = new Dictionary<string, double>();

            var earningsPerMonthGrouping = _context
                .Bookings
                .Include(x => x.Contract)
                .Where(yearFilter)
                .Where(x => x.StatusAsString == "Complete")
                .ToList()
                .GroupBy(x => x.StartDate.Month);

            var monthNames = DateTimeFormatInfo
                .CurrentInfo?
                .MonthNames
                .Where(x => x != DateTimeFormatInfo.CurrentInfo.MonthNames.Last())
                .Select(x => x.Substring(0, 3))
                .ToList();

            for (int i = 0; i < monthNames?.Count; i++)
            {
                earningsPerMonth
                    .Add(monthNames[i], earningsPerMonthGrouping
                                            .SingleOrDefault(x => x.Key == (i + 1))?
                                            .Sum(x => x.Contract?.Price) ?? 0
                    );
            }

            return earningsPerMonth;
        }
    }
}
