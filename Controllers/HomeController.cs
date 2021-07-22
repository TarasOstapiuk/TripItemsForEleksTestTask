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
        private readonly AppDBContext contextDB;
        public HomeController(AppDBContext contextDB)
        {
            contextDB = contextDB;
        }
        public IActionResult Index()
        {
            

            return View();
        }
    }
}
