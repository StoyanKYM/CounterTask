using System.Diagnostics;
using CounterTask.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace CounterTask.Controllers
{
    public class HomeController : Controller
    {
        public HomeController()
        {
        }

        public IActionResult Index()
        {
            var numbers = HttpContext.Session.Get<List<int>>("Numbers") ?? new List<int>();

            var sum = numbers.Sum();

            // Store the numbers and sum in ViewData for rendering in the view
            ViewData["Numbers"] = numbers;
            ViewData["Sum"] = sum;

            return View();
        }

        // Add a random number to the session
        [HttpPost]
        public IActionResult AddNumber()
        {
            var numbers = HttpContext.Session.Get<List<int>>("Numbers") ?? new List<int>();
            var random = new Random().Next(1, 1001);
            numbers.Add(random);
            HttpContext.Session.Set("Numbers", numbers);

            return Json(new { numbers, sum = numbers.Sum() });
        }

        // Clear all numbers in the session
        [HttpPost]
        public IActionResult ClearNumbers()
        {
            HttpContext.Session.Set("Numbers", new List<int>());
            return Json(new { numbers = new List<int>(), sum = 0 });
        }

        // Calculate the sum of the numbers in the session
        [HttpGet]
        public IActionResult SumNumbers()
        {
            var numbers = HttpContext.Session.Get<List<int>>("Numbers") ?? new List<int>();
            return Json(new { numbers, sum = numbers.Sum() });
        }
    }
}
