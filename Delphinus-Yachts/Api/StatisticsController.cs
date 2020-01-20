using System.Web.Http;
using AutoMapper;
using Delphinus_Yachts.Domain.Services;
using Delphinus_Yachts.DTOs;

namespace Delphinus_Yachts.Api
{
    public class StatisticsController : ApiController
    {
        private readonly StatisticsService _statisticsService;
        private readonly IMapper _mapper;

        public StatisticsController(StatisticsService statisticsService, IMapper mapper)
        {
            _statisticsService = statisticsService;
            _mapper = mapper;
        }

        public IHttpActionResult Get()
        {
            var model = _statisticsService.Get();

            return Ok(_mapper.Map<StatisticsDTO>(model));
        }
    }
}