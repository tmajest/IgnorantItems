using CoffeeCat.RiotCommon.Contracts;
using CoffeeCat.RiotCommon.Dto.StaticData.Item;
using RiotFrontend.Providers;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Web.Mvc;

namespace RiotFrontend.Controllers
{
    [Export]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class MatchController : Controller
    {
        private readonly IMatchProvider matchProvider;

        [ImportingConstructor]
        public MatchController(IMatchProvider matchProvider)
        {
            this.matchProvider = matchProvider;
        }

        public ActionResult Index(string matchId)
        {
            var match = matchProvider.GetMatch(matchId);
            if (match == null)
            {
                RedirectToAction("Home");
            }

            ViewBag.match = match;
            return View();
        }
    }
}
