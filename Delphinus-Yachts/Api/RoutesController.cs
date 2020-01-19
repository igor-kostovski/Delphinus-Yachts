using System.Web.Http;
using AutoMapper;
using Delphinus_Yachts.Domain.Models;
using Delphinus_Yachts.Domain.Services;
using Delphinus_Yachts.DTOs;

namespace Delphinus_Yachts.Api
{
    [Authorize]
    public class RoutesController : ApiController
    {
        private readonly RouteService _routeService;
        private readonly IMapper _mapper;

        public RoutesController(RouteService routeService, IMapper mapper)
        {
            _routeService = routeService;
            _mapper = mapper;
        }

        [HttpGet]
        public IHttpActionResult Get([FromUri]TableFilter filter)
        {
            var dataAndCount = _routeService.GetAll(filter);

            return Ok(dataAndCount);
        }

        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            var booking = _routeService.Get(id);

            return Ok(_mapper.Map<RouteDTO>(booking));
        }

        [HttpPost]
        public IHttpActionResult Create(RouteDTO dto)
        {
            var model = _mapper.Map<RouteModel>(dto);
            model = _routeService.Create(model);

            return Ok(model.Id);
        }

        [HttpPut]
        public IHttpActionResult Update(RouteDTO dto)
        {
            var model = _mapper.Map<RouteModel>(dto);
            model = _routeService.Update(model);

            return Ok(model);
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            _routeService.Delete(id);

            return Ok();
        }
    }
}