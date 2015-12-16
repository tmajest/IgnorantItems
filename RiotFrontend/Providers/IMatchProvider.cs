using CoffeeCat.RiotCommon.Contracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Web;
using CoffeeCat.RiotCommon.Contracts.Frontend;

namespace RiotFrontend.Providers
{
    [InheritedExport(typeof(IMatchProvider))]
    public interface IMatchProvider
    {
        List<Match> GetMatches();

        Match GetMatch(string matchId);
    }
}