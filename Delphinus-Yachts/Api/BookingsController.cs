using System.Collections.Generic;
using System.Web.Http;
using AutoMapper;
using Delphinus_Yachts.Domain.Models;
using Delphinus_Yachts.Domain.Services;
using Delphinus_Yachts.DTOs;

namespace Delphinus_Yachts.Api
{
    [Authorize]
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

        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            var booking = _bookingService.Get(id);

            return Ok(_mapper.Map<BookingDTO>(booking));
        }

        [HttpPost]
        public IHttpActionResult Create(BookingDTO dto)
        {
            var model = _mapper.Map<BookingModel>(dto);
            model = _bookingService.Create(model);

            return Ok(model.Id);
        }

        [HttpPut]
        public IHttpActionResult Update(BookingDTO dto)
        {
            var model = _mapper.Map<BookingModel>(dto);
            model = _bookingService.Update(model);

            return Ok(model);
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            _bookingService.Delete(id);

            return Ok();
        }
    }
}