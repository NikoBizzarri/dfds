using DFDS_WebAPI.Models.DB;
using DFDS_WebAPI.Models.DTOs;
using DFDS_WebAPI.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DFDS_WebAPI.Controllers
{
    // todo: auth
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {

        private readonly IRepository _repo;
        private readonly ILogger<BookingController> _logger;

        public BookingController(ILogger<BookingController> logger, IRepository repo)
        {
            _repo = repo;
            _logger = logger;
        }

        // rest compliant
        [HttpGet]
        [Route("GetAll")]
        public AllBookingsDto GetAll()
        {
            var bookings = _repo.GetAllBookings();
            return bookings;
        }

        [HttpGet]
        [Route("GetbyId/{id}")]
        public BookingDto GetbyId(int id)
        {
            var booking = _repo.GetBookingById(id);
            return booking;
        }

        [HttpPut]
        [Route("Update")]
        public Booking Update(Booking entity)
        {
            var booking = _repo.UpdateBooking(entity);
            return booking;
        }

        [HttpPost]
        [Route("Create")]
        public Booking Create(BookingDto entity)
        {
            var booking = _repo.CreateBooking(entity);
            return booking;
        }

        [HttpDelete]
        [Route("Delete/{id}")]
        public Booking Delete(int id)
        {
            var booking = _repo.DeleteBookingById(id);
            return booking;
        }

    }
}
