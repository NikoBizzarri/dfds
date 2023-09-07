using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DFDS_WebAPI.Models.DB
{
    public class Passenger
    {
        public string Fullname { get; set; }
        [Key]
        public string Email { get; set; }
        public string Phone { get; set; }
    }
}
