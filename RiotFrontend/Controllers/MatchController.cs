using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RiotFrontend.Controllers
{
    public class MatchController : Controller
    {
        // GET: Match
        public ActionResult Index(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                return RedirectToAction("Home", "Index");
            }

            this.ViewBag.MatchId = id;
            return View();
        }
    }
}