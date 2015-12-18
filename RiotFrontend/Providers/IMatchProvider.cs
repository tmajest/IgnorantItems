using CoffeeCat.RiotCommon.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CoffeeCat.RiotCommon.Contracts.Frontend;

namespace RiotFrontend.Providers
{
    public interface IMatchProvider
    {
        List<Match> GetMatches();

        List<Match> GetMatches(int count);

        Match GetMatch(string matchId);
    }
}