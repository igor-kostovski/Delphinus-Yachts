using System;
using Delphinus_Yachts.Domain.Data.Enums;

namespace Delphinus_Yachts.Domain.Data.Entities
{
    public class Booking
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string StartLocation { get; set; }
        public string EndLocation { get; set; }

        public BookingStatus Status { get; set; }

        public string StatusAsString
        {
            get => Status.ToString();
            private set => Status = value.ToEnum<BookingStatus>().Value;
        }
    }
}
