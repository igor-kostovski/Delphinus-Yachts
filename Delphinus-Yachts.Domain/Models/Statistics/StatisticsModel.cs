using System.Collections.Generic;
using Delphinus_Yachts.Domain.Models.Statistics;

namespace Delphinus_Yachts.Domain.Models
{
    public class StatisticsModel
    {
        public double MonthlyEarnings { get; set; }
        public double AnnualEarnings { get; set; }
        public double DoneBookingsPercentage { get; set; }
        public CountByStatus CountByStatus { get; set; }
        public Dictionary<string,double> EarningsPerMonth { get; set; }
    }
}
