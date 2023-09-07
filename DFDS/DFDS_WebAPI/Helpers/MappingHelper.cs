using DFDS_WebAPI.Models.DB;
using DFDS_WebAPI.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DFDS_WebAPI.Helpers
{
    public static class MappingHelper
    {

        public static AllBookingsDto MapAllBookings(List<Booking> bookings, List<Passenger> passengers, List<BookingPassenger> rel)
        {
            var result = new AllBookingsDto();

            foreach (var booking in bookings)
            {
                var partialMap = new BookingDto();
                partialMap.DateAndTime = booking.DateAndTime;
                partialMap.Id = booking.Id;
                partialMap.Description = booking.Description;

                var passengersEmailToAdd = rel.Where(x => x.BookingId == booking.Id).Select(y => y.PassengerEmail).ToList();
                var passengersToAdd = passengers.Where(x => passengersEmailToAdd.Contains(x.Email)).ToList();
                partialMap.Passengers.AddRange(passengersToAdd);

                result.Bookings.Add(partialMap);
            }

            return result;
        }

        public static BookingDto MapBooking(Booking booking, List<Passenger> passengers, List<BookingPassenger> rel)
        {
            var map = new BookingDto();
            map.DateAndTime = booking.DateAndTime;
            map.Id = booking.Id;
            map.Description = booking.Description;

            var passengersEmailToAdd = rel.Where(x => x.BookingId == booking.Id).Select(y => y.PassengerEmail).Distinct();
            var passengersToAdd = passengers.Where(x => passengersEmailToAdd.Contains(x.Email)).ToList();
            map.Passengers.AddRange(passengersToAdd);
            

            return map;
        }
    }
}
