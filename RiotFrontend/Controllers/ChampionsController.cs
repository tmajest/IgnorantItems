﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RiotFrontend.Controllers
{
    public class ChampionsController : Controller
    {
        // GET: Champion
#if (!DEBUG)
        [OutputCache(Duration=int.86000)]
#endif
        public ActionResult Index()
        {
            return View();
        }
    }
}