using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DFDS_WebAPI.Models.DB
{
    public class Booking
    {
        [Key]
        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime DateAndTime { get; set; }

        public List<Passenger> Passengers { get; set; }

    }
}
