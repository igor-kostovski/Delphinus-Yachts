﻿using System.Collections.Generic;

namespace Delphinus_Yachts.Domain.Data.Entities
{
    public class Route
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<Location> Locations { get; set; }
    }
}
