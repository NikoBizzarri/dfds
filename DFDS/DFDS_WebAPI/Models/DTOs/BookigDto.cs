using DFDS_WebAPI.Models.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DFDS_WebAPI.Models.DTOs
{
    public class BookigDto : Booking
    {
        //    public int Id { get; set; }
        //    public string Description { get; set; }
        //    public DateTime DateAndTime { get; set; }

        // passenger
        public List<Passenger> Passengers { get; set; }
    }

    public class AllBookingsDto
    {
        public List<BookigDto> Bookings => new List<BookigDto>();
    }
}
