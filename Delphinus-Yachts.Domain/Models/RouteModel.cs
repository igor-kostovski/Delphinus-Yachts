using System.Collections.Generic;

namespace Delphinus_Yachts.Domain.Models
{
    public class RouteModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<LocationModel> Locations { get; set; }
    }
}
