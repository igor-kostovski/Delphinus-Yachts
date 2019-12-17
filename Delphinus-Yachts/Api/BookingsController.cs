using System.Collections.Generic;
using System.Web.Http;
using AutoMapper;
using Delphinus_Yachts.Domain.Services;
using Delphinus_Yachts.DTOs;

namespace Delphinus_Yachts.Api
{
    [Authorize]
    [Route("api/[controller]")]
    public class BookingsController : ApiController
    {
        private readonly BookingService _bookingService;
        private readonly IMapper _mapper;

        public BookingsController(BookingService bookingService, IMapper mapper)
        {
            _bookingService = bookingService;
            _mapper = mapper;
        }

        [HttpGet]
        public IHttpActionResult Get()
        {
            var bookings = _bookingService.GetAll();

            return Ok(_mapper.Map<List<BookingDTO>>(bookings));
        }
    }
}