using Microsoft.AspNetCore.Mvc;
using ReserveTeste.Core.Services;
using ReserveTeste.Mvc.Models;
using System.Diagnostics;

namespace ReserveTeste.Mvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IServiceCountry _service;

        public HomeController(ILogger<HomeController> logger, IServiceCountry service)
        {
            _logger = logger;
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var countries = await _service.GetCountryResponse();
            return View(countries);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}