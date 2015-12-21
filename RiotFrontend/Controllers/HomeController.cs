using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace RiotFrontend.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
#if (!DEBUG)
        [OutputCache(Duration=3600)]
#endif
        public ActionResult Index()
        {
            return View();
        }
    }
}