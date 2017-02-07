using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CoffeeCat.RiotFrontend.Models
{
    public class MatchList
    {
        public int Total { get; set; }

        public List<Match> Matches { get; set; }
    }
}