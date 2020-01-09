using System;
using System.Collections.Generic;
using Delphinus_Yachts.Domain.Data;
using Delphinus_Yachts.Domain.Models;

namespace Delphinus_Yachts.Domain.Services
{
    public class AvailabilityService
    {
        private readonly DataContext _dataContext;

        public AvailabilityService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public List<AvailabilityModel> Get()
        {
            throw new NotImplementedException();
        }
    }
}
