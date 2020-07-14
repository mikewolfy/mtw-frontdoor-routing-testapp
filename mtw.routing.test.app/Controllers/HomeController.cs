using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using mtw.routing.test.app.Models;

namespace mtw.routing.test.app.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private Counter _counter;
        IConfiguration _config;

        public HomeController(ILogger<HomeController> logger, IConfiguration config, IMemoryCache cache)
        {
            var counter = cache.GetOrCreate("counter", entry =>
             {
                 return new Counter();
             });

            _counter = counter;
            _config = config;
            _logger = logger;
        }

        public IActionResult Index()
        {
            ViewBag.AppName = _config["AppName"];
            return View();
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
