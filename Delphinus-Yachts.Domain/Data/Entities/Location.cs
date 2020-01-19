using System.Collections.Generic;

namespace Delphinus_Yachts.Domain.Data.Entities
{
    public class Location
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<Route> Routes { get; set; }
    }
}
