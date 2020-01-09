﻿using System.Collections.Generic;
using System.Web.Http;
using AutoMapper;
using Delphinus_Yachts.Domain.Services;
using Delphinus_Yachts.DTOs;

namespace Delphinus_Yachts.Api
{
    [Authorize]
    public class AvailabilitiesController : ApiController
    {
        private readonly IMapper _mapper;
        private readonly AvailabilityService _availabilityService;

        public AvailabilitiesController(IMapper mapper, AvailabilityService availabilityService)
        {
            _mapper = mapper;
            _availabilityService = availabilityService;
        }

        public IHttpActionResult Get()
        {
            var models = _availabilityService.Get();

            return Ok(_mapper.Map<List<AvailabilityDTO>>(models));
        }
    }
}