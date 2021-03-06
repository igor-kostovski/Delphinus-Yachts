﻿using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Delphinus_Yachts.Domain.Data;
using Delphinus_Yachts.Domain.Models;
using Delphinus_Yachts.Domain.Models.Availability;

namespace Delphinus_Yachts.Domain.Services
{
    public class AvailabilityService
    {
        private readonly DataContext _dataContext;
        private readonly IMapper _mapper;

        public AvailabilityService(DataContext dataContext, IMapper mapper)
        {
            _dataContext = dataContext;
            _mapper = mapper;
        }

        public List<AvailabilityModel> Get(AvailabilityFilter filter)
        {
            return _dataContext.Bookings
                .Where(x => x.StartDate >= filter.FromDate && x.EndDate <= filter.ToDate)
                .ProjectTo<AvailabilityModel>(_mapper.ConfigurationProvider)
                .ToList();
        }
    }
}
