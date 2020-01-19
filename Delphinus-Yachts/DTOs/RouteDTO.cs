using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Delphinus_Yachts.DTOs
{
    public class RouteDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<LocationDTO> Locations { get; set; }
    }
}