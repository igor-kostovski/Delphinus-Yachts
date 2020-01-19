using System;
using Delphinus_Yachts.Domain.Data.Enums;

namespace Delphinus_Yachts.DTOs
{
    public class BookingDTO
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string StartLocation { get; set; }
        public string EndLocation { get; set; }
        public string Status { get; set; }
        
        public ContractDTO Contract { get; set; }
    }
}