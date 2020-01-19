using System.Web.Http;
using AutoMapper;
using Delphinus_Yachts.Domain.Services;

namespace Delphinus_Yachts.Api
{
    public class LocationsController : ApiController
    {
        private readonly LocationService _locationService;
        private readonly IMapper _mapper;

        public LocationsController(LocationService locationService, IMapper mapper)
        {
            _locationService = locationService;
            _mapper = mapper;
        }


    }
}