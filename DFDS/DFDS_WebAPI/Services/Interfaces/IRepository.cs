using DFDS_WebAPI.Models.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DFDS_WebAPI.Services.Interfaces
{
    public interface IRepository
    {
        #region CRUD bookings
        List<Booking> GetAllBookings();
        Booking GetBookingById(int id);
        Booking UpdateBooking(Booking entry); // todo: use DTO instead
        Booking DeleteBookingById(int id);
        Booking CreateBooking(Booking entry); // todo: use DTO instead

        #endregion

        #region CRUD Passenger
        List<Passenger> GetAllPassengers();
        Passenger GetPassengerByEmail(string email);
        Passenger UpdatePassenger(Passenger entry); // todo: use DTO instead
        Passenger DeletePassengerByEmail(string email);
        Passenger CreatePassenger(Passenger entry); // todo: use DTO instead

        #endregion

    }
}
