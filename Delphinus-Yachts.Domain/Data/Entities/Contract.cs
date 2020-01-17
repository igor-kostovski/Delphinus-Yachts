using System;
using Delphinus_Yachts.Domain.Data.Enums;

namespace Delphinus_Yachts.Domain.Data.Entities
{
    public class Contract
    {
        public int Id { get; set; }
        public double Price { get; set; }
        public double Discount { get; set; }
        public double APA { get; set; }
        public double Tax { get; set; }
        public string PayingPassenger { get; set; }
        public ContractType Type { get; set; }

        public string TypeAsString
        {
            get => Type.ToString();
            private set => Type = value.ToEnum<ContractType>().Value;
        }

        public Booking Booking { get; set; }
    }
}
