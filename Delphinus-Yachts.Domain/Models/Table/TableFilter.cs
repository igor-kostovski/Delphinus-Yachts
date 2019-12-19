namespace Delphinus_Yachts.Domain.Models
{
    public class TableFilter
    {
        public int Limit { get; set; } = 10;
        public int Page { get; set; } = 1;
        public string Query { get; set; }
    }
}
