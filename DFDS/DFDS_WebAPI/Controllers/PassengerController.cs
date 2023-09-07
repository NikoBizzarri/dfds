using DFDS_WebAPI.Models.DB;
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
    [Route("api/[controller]")]
    [ApiController]
    public class PassengerController : ControllerBase
    {

        private readonly IRepository _repo;
        private readonly ILogger<PassengerController> _logger;

        public PassengerController(ILogger<PassengerController> logger, IRepository repo)
        {
            _logger = logger;
            _repo = repo;
        }

        // rest compliant
        [HttpGet]
        [Route("GetAll")]
        public IEnumerable<Passenger> GetAll()
        {
            var passengers = _repo.GetAllPassengers();
            return passengers;
        }

        [HttpGet]
        [Route("GetbyEmail/{email}")]
        public Passenger GetbyEmail(string email)
        {
            var passenger = _repo.GetPassengerByEmail(email);
            return passenger;
        }

        [HttpPut]
        [Route("Update")]
        public Passenger Update(Passenger entity)
        {
            var passenger = _repo.UpdatePassenger(entity);
            return passenger;
        }

        [HttpPost]
        [Route("Create")]
        public Passenger Create(Passenger entity)
        {
            var passenger = _repo.CreatePassenger(entity);
            return passenger;
        }

        [HttpDelete]
        [Route("Delete/{id}")]
        public Passenger Delete(string email)
        {
            var passenger = _repo.DeletePassengerByEmail(email);
            return passenger;
        }

    }
}
