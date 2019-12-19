using System.Collections.Generic;

namespace Delphinus_Yachts.Domain.Models.Table
{
    public class DataAndCount<T>
    {
        public IEnumerable<T> Data { get; set; }
        public int Count { get; set; }
    }
}
