using ChuckNorrisJokes.Models;
using ChuckNorrisJokes.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ChuckNorrisJokes.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

       
        public IActionResult Index()
        {
            var chuckApi = new ChuckApi();
            var joke = chuckApi.GetChuckJoke();

            return View(joke);
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