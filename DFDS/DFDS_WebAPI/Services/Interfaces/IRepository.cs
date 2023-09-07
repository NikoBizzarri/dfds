using DFDS_WebAPI.Models.DB;
using DFDS_WebAPI.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DFDS_WebAPI.Services.Interfaces
{
    public interface IRepository
    {
        #region CRUD bookings
        AllBookingsDto GetAllBookings();
        BookingDto GetBookingById(int id);
        BookingDto UpdateBooking(BookingDto entry);
        bool DeleteBookingById(int id);
        BookingDto CreateBooking(BookingDto entry); 

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
