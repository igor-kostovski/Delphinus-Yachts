namespace Delphinus_Yachts.DTOs
{
    public class ContractDTO
    {
        public int Id { get; set; }
        public double Price { get; set; }
        public double Discount { get; set; }
        public double APA { get; set; }
        public double Tax { get; set; }
        public string PayingPassenger { get; set; }
        public string Type { get; set; }
    }
}