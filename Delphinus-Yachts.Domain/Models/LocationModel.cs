using System.Collections.Generic;

namespace Delphinus_Yachts.Domain.Models
{
    public class LocationModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<RouteModel> Routes { get; set; }
    }
}
