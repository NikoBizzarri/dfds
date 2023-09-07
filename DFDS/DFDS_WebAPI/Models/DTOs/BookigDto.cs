using DFDS_WebAPI.Models.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DFDS_WebAPI.Models.DTOs
{
    public class BookingDto : Booking
    {
        public BookingDto()
        {
            Passengers = new List<Passenger>();
        }

        // passenger
        public List<Passenger> Passengers { get; set; }
    }

    public class AllBookingsDto
    {
        public AllBookingsDto()
        {
            Bookings = new List<BookingDto>();
        }
        public List<BookingDto> Bookings  {get; set;}
}
}
