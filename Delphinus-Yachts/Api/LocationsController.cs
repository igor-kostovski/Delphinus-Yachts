using System.Web.Http;
using AutoMapper;
using Delphinus_Yachts.Domain.Models;
using Delphinus_Yachts.Domain.Services;
using Delphinus_Yachts.DTOs;

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

        [HttpGet]
        public IHttpActionResult Get([FromUri]TableFilter filter)
        {
            var dataAndCount = _locationService.GetAll(filter);

            return Ok(dataAndCount);
        }

        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            var location = _locationService.Get(id);

            return Ok(_mapper.Map<LocationDTO>(location));
        }

        [HttpPost]
        public IHttpActionResult Create(LocationDTO dto)
        {
            var model = _mapper.Map<LocationModel>(dto);
            model = _locationService.Create(model);

            return Ok(model.Id);
        }

        [HttpPut]
        public IHttpActionResult Update(LocationDTO dto)
        {
            var model = _mapper.Map<LocationModel>(dto);
            model = _locationService.Update(model);

            return Ok(model);
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            _locationService.Delete(id);

            return Ok();
        }
    }
}