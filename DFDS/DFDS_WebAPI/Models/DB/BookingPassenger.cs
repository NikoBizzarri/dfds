using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DFDS_WebAPI.Models.DB
{
    [Obsolete]
    public class BookingPassenger
    {
        [Key]
        public int Id { get; set; }
        public int BookingId { get; set; }
        public string PassengerEmail { get; set; }
    }
}
