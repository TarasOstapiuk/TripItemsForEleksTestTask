using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using TripItemsForEleks.Models;


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
        public ViewResult Index()
        {
            IEnumerable<Trip> trips = _tripRepository.GetAllTrips();
            return View(trips);
        }

        [HttpGet]
        public IActionResult CreateTrip()
        {
            IEnumerable<Item> allItem = _itemRepository.GetAllItems();
            ViewBag.ReadyMadeTrips = _tripRepository.GetAllTrips();
            return View(allItem);
        }
        [HttpPost]
        public RedirectToActionResult CreateTrip(string name, int[] tripid)
        {
            _tripRepository.CreateTrip(name, tripid);

            return RedirectToAction("Index", "Trip");
        }
        [HttpGet]
        public ActionResult EditDelete(int id)
        {
            Trip trip = _tripRepository.GetTrip(id);
            List<Item> listOfAllItems = (List<Item>)_itemRepository.GetAllItems();
            ViewBag.ListOtItems = listOfAllItems;
            return View("~/Views/Trip/EditDelete.cshtml", trip);
        }

        [HttpPost]
        public RedirectToActionResult DeleteTrip(int id)
        {
            Trip tripToBeDelited = _tripRepository.Delete(id);
            return RedirectToAction("Index");
        }
        [HttpPost]
        public void DeleteItemFromTrip(int Id)
        {
            _tripRepository.DeleteItemFromTrip(Id);
        }
        [HttpPost]
        public void AddingItemToExistingTrip(int idItem, int IdTrip)
        {
            _tripRepository.AddingItemToExistingTrip(IdTrip, idItem);
        }
        [HttpPost]
        public void RenameTrip(int IdTrip, string newName)
        {
            _tripRepository.RenameTrip(IdTrip, newName);
        }
        [HttpPost]
        public RedirectToActionResult CreateTripFromExistingOne(string tripNameFromOld, int oldTripID) 
        {
            _tripRepository.CreateTripFromExistingOne(tripNameFromOld, oldTripID);
            return RedirectToAction("Index");
        }
    }
}
