using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TripItemsForEleks.Models;

namespace TripItemsForEleks.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHomeRepository _homeRepository;

        public HomeController(IHomeRepository homeRepository)
        {
            _homeRepository = homeRepository;
        }
              
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Favorites()
        {
            IEnumerable<Item> items = _homeRepository.GetFavorites();
            return View(items);
        }
    }
}
