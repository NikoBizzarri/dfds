using DFDS_WebAPI.Helpers;
using DFDS_WebAPI.Models.DB;
using DFDS_WebAPI.Models.DTOs;
using DFDS_WebAPI.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DFDS_WebAPI.Services
{
    public class Repository : IRepository
    {
        public Repository()
        {
            using (var context = new WebApiDbContext())
            {
                // populare the DB a bit...
                var passengers = new List<Passenger>
                {
                new Passenger
                {
                    Email = "bizzarriniko@gmail.com",
                    Fullname = "Niko Bizzarri",
                    Phone = "123456789"

                },
                new Passenger
                {
                    Email = "johndoe@email.com",
                    Fullname = "John Doe",
                    Phone = "987654321"

                }
                };
                if (!context.Passengers.Any())
                {
                    context.Passengers.AddRange(passengers);
                    context.SaveChanges();
                }

                var bookings = new List<Booking>
                {
                new Booking
                {
                    DateAndTime = DateTime.UtcNow.AddDays(-13),
                    Id = 1,
                    Description = "this is a booking"
                },
                new Booking
                {
                    DateAndTime = DateTime.UtcNow.AddDays(-13),
                    Id = 2,
                    Description = "this is a second booking"
                }
                };
                if (!context.Bookings.Any())
                {
                    context.Bookings.AddRange(bookings);
                    context.SaveChanges();
                }

                var bookingPass = new List<BookingPassenger>
                {
                new BookingPassenger
                {
                    Id = 1,
                    BookingId = bookings.FirstOrDefault().Id,
                    PassengerEmail = passengers.FirstOrDefault().Email
                },
                new BookingPassenger
                {
                    Id = 2,
                    BookingId = bookings.FirstOrDefault().Id,
                    PassengerEmail = passengers.LastOrDefault().Email
                },
                new BookingPassenger
                {
                    Id = 3,
                    BookingId = bookings.LastOrDefault().Id,
                    PassengerEmail = passengers.LastOrDefault().Email
                },
                //new BookingPassenger
                //{
                //    Id = 4,
                //    BookingId = bookings.LastOrDefault().Id,
                //    PassengerEmail = passengers.FirstOrDefault().Email
                //},
                };
                if (!context.BookingPassengers.Any())
                {
                    context.BookingPassengers.AddRange(bookingPass);
                    context.SaveChanges();
                }

            }
        }

        public BookingDto CreateBooking(BookingDto entry)
        {
            using (var context = new WebApiDbContext())
            {
                var result = context.Bookings.Add(entry);

                foreach (var rel in entry.Passengers)
                {
                    context.BookingPassengers.Add(new BookingPassenger { BookingId = entry.Id, PassengerEmail = rel.Email });
                }

                context.SaveChanges();
                // todo: set ID as auto increment 
                // todo: read the new entity after creation and return it
                return entry;
            }
        }

        public Passenger CreatePassenger(Passenger entry)
        {
            using (var context = new WebApiDbContext())
            {
                var result = context.Passengers.Add(entry);

                context.SaveChanges();
                // todo: set ID as auto increment 
                // todo: read the new entity after creation and return it
                return entry;
            }
        }

        public bool DeleteBookingById(int id)
        {
            using (var context = new WebApiDbContext())
            {
                var toRemove = context.Bookings.FirstOrDefault(x => x.Id == id);

                var result = context.Bookings.Remove(toRemove);

                var relToRemove = context.BookingPassengers.Where(x => x.BookingId == id);

                context.BookingPassengers.RemoveRange(relToRemove);

                context.SaveChanges();
                return true; ;
            }
        }

        public Passenger DeletePassengerByEmail(string email)
        {
            using (var context = new WebApiDbContext())
            {
                var toRemove = context.Passengers.FirstOrDefault(x => x.Email == email);

                var result = context.Passengers.Remove(toRemove);

                context.SaveChanges();
                return toRemove;
            }
        }

        public AllBookingsDto GetAllBookings()
        {
            using (var context = new WebApiDbContext())
            {
                var bookings = context.Bookings.ToList();
                var rel = context.BookingPassengers.ToList();
                var passengers = context.Passengers.ToList();

                var result = MappingHelper.MapAllBookings(bookings, passengers, rel);

                return result;
            }
        }

        public List<Passenger> GetAllPassengers()
        {
            using (var context = new WebApiDbContext())
            {
                var list = context.Passengers
                    .ToList();
                return list;
            }
        }

        public BookingDto GetBookingById(int id)
        {
            using (var context = new WebApiDbContext())
            {

                var booking = context.Bookings.FirstOrDefault(x => x.Id == id);
                var rel = context.BookingPassengers.ToList();
                var passengers = context.Passengers.ToList();

                var result = MappingHelper.MapBooking(booking, passengers, rel);
                return result;
            }
        }

        public Passenger GetPassengerByEmail(string email)
        {
            using (var context = new WebApiDbContext())
            {
                var result = context.Passengers.FirstOrDefault(x => x.Email == email);
                return result;
            }
        }

        public BookingDto UpdateBooking(BookingDto entry)
        {
            using (var context = new WebApiDbContext())
            {
                context.Bookings.Update(entry);

                var oldRelationships = context.BookingPassengers.Where(X => X.BookingId == entry.Id);
                context.BookingPassengers.RemoveRange(oldRelationships);

                foreach (var rel in entry.Passengers)
                {
                    context.BookingPassengers.Add(new BookingPassenger { BookingId = entry.Id, PassengerEmail = rel.Email });
                }

                context.SaveChanges();

                return entry;
            }
        }

        public Passenger UpdatePassenger(Passenger entry)
        {
            using (var context = new WebApiDbContext())
            {
                context.Passengers.Update(entry);
                context.SaveChanges();

                return entry;
            }
        }
    }
}
