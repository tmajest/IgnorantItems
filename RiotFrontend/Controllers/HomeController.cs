using Newtonsoft.Json;
using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RiotFrontend.Providers;

namespace RiotFrontend.Controllers
{
    [Export]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class HomeController : Controller
    {
        private IMatchProvider matchProvider;

        [ImportingConstructor]
        public HomeController(IMatchProvider matchProvider)
        {
            this.matchProvider = matchProvider;
        }

        public ActionResult Index()
        {
            ViewBag.matches = matchProvider.GetMatches();

            return View();
        }
    }
}
