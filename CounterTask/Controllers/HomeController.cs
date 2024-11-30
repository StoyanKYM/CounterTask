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
            var counter = HttpContext.Session.GetInt32("Counter") ?? 0;

            var sum = numbers.Sum();

            // Store the numbers and sum in ViewData for rendering in the view
            ViewData["Numbers"] = numbers;
            ViewData["Sum"] = sum;
            ViewData["Counter"] = counter;

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

            // Increment counter
            var counter = HttpContext.Session.GetInt32("Counter") ?? 0;
            HttpContext.Session.SetInt32("Counter", counter + 1);

            return Json(new { numbers, sum = numbers.Sum(), counter = counter + 1 });
        }

        // Clear all numbers in the session
        [HttpPost]
        public IActionResult ClearNumbers()
        {
            HttpContext.Session.Set("Numbers", new List<int>());
            HttpContext.Session.SetInt32("Counter", 0); // Reset counter

            return Json(new { numbers = new List<int>(), sum = 0, counter = 0 });
        }
    }
}
