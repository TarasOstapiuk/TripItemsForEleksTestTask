using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TripItemsForEleks.Models;

namespace TripItemsForEleks.Controllers
{
    public class TripController : Controller
    {
        private readonly ITripRepository _tripRepository;

        public TripController(ITripRepository tripRepository)
        {
             _tripRepository = tripRepository;
        }
        public IActionResult Index()
        {
            IEnumerable<Trip> trips= _tripRepository.GetAllTrips();
            return View(trips);
        }

        [HttpGet]
        public IActionResult CreateTrip()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateTrip(Trip trip)
        {
           
            return View();
        }
    }
}
