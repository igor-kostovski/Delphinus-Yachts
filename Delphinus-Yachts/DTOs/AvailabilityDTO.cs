using System;

namespace Delphinus_Yachts.DTOs
{
    public class AvailabilityDTO
    {
        public int BookingId { get; set; }
        public DateTime BookingStart { get; set; }
        public DateTime BookingEnd { get; set; }
        public string BookingStatus { get; set; }
    }
}