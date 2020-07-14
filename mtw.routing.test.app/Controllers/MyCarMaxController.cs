using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;

namespace mtw.routing.test.app.Controllers
{
    [Route("mycarmax/sign-in")]
    public class MyCarMaxController : Controller
    {
        private Counter _counter;
        IConfiguration _config;

        public MyCarMaxController(IConfiguration config, IMemoryCache cache)
        {
            var counter = cache.GetOrCreate("counter", entry =>
            {
                return new Counter();
            });

            _counter = counter;
            _config = config;
        }

        // GET: MyCarMaxController
        public ActionResult Index()
        {
            ViewBag.AppName = _config["AppName"];
            ViewBag.Count = _counter.GetCount();
            ViewBag.Color = _config["Color"];
            ViewBag.EncodedUrl = HttpContext.Request.GetEncodedUrl();
            ViewBag.DisplayUrl = HttpContext.Request.GetDisplayUrl();
            return View();
        }
    }
}
