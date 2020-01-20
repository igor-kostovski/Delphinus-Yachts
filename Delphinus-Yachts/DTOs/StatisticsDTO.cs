using Delphinus_Yachts.Domain.Models.Statistics;

namespace Delphinus_Yachts.DTOs
{
    public class StatisticsDTO
    {
        public double MonthlyEarnings { get; set; }
        public double AnnualEarnings { get; set; }
        public int TotalNumberOfPassengers { get; set; }
        public CountByStatus CountByStatus { get; set; }
    }
}