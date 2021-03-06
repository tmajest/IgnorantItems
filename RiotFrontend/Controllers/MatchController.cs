﻿using System.Web.Mvc;

namespace CoffeeCat.RiotFrontend.Controllers
{
    public class MatchController : Controller
    {
        // GET: Match
#if (!DEBUG)
        [OutputCache(Duration=86000, VaryByParam="id")]
#endif
        public ActionResult Index(string summonerName, string matchId)
        {
            if (string.IsNullOrWhiteSpace(matchId) || string.IsNullOrWhiteSpace(summonerName))
            {
                return RedirectToAction("Home", "Index");
            }

            this.ViewBag.MatchId = matchId;
            this.ViewBag.SummonerName = summonerName;
            return View();
        }
    }
}