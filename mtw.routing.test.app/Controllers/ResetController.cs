using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;

namespace mtw.routing.test.app.Controllers
{
    [Route("reset")]
    public class ResetController : Controller
    {
        private Counter _counter;
        IConfiguration _config;

        public ResetController(IConfiguration config, IMemoryCache cache)
        {
            var counter = cache.GetOrCreate("counter", entry =>
            {
                return new Counter();
            });

            _counter = counter;
            _config = config;
        }

        public IActionResult Index()
        {
            _counter.Reset();
            return View();
        }
    }
}
