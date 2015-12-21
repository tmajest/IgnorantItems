using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RiotFrontend.Controllers
{
    public class ChampionInfoController : Controller
    {
        // GET: Champion
        public ActionResult Index(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                return RedirectToAction("Home", "Index");
            }

            this.ViewBag.ChampionId = id;
            return View();
        }
    }
}