using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;

namespace mtw.routing.test.app.Controllers
{
    [Route("login")]
    public class LoginController : Controller
    {
        private Counter _counter;
        IConfiguration _config;

        public LoginController(IConfiguration config, IMemoryCache cache)
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
            string parsedParams = string.Empty;

            foreach (var key in HttpContext.Request.Query.Keys)
            {
                parsedParams += key + ":" + HttpContext.Request.Query[key] + ",";
            }

            ViewBag.Count = _counter.GetCount();
            ViewBag.EncodedUrl = HttpContext.Request.GetEncodedUrl();
            ViewBag.DisplayUrl = HttpContext.Request.GetDisplayUrl();
            ViewBag.Query = HttpContext.Request.QueryString;
            ViewBag.QueryParams = parsedParams;
            ViewBag.AppName = _config["AppName"];
            ViewBag.Color = _config["Color"];
            return View();
        }
    }
}
