﻿using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using TripItemsForEleks.Models;
using TripItemsForEleks.Models.DTO;

namespace TripItemsForEleks.Controllers
{
    public class TripController : Controller
    {
        private readonly ITripRepository _tripRepository;
        private readonly IItemRepository _itemRepository;

        public TripController(ITripRepository tripRepository, 
                              IItemRepository itemRepository)
        {
            _tripRepository = tripRepository;
            _itemRepository = itemRepository;
        }
        public IActionResult Index()
        {
            IEnumerable<Trip> trips = _tripRepository.GetAllTrips();
            return View(trips);
        }

        [HttpGet]
        public IActionResult CreateTrip()
        {
            IEnumerable<Item> allItem = _itemRepository.GetAllItems();
            return View(allItem);
        }
        [HttpPost]
        public RedirectToActionResult CreateTrip(TripItemsDTO trip)
        {
            var a = HttpContext.Request;
            //a.Body.InputStream.Seek(0, SeekOrigin.Begin);
           // string jsonString = new StreamReader(a.InputStream).ReadToEnd();
            
            /*Trip newTrip = _tripRepository.AddTrip(trip);*/ 
            return RedirectToAction("Index");
        }
    }
}
