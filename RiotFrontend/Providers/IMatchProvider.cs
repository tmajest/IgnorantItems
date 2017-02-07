using System.Collections.Generic;
using System.Threading.Tasks;
using CoffeeCat.RiotFrontend.Models;

namespace CoffeeCat.RiotFrontend.Providers
{
    public interface IMatchProvider
    {
        Task<MatchList> GetMatches(int skip, int count);

        Task<MatchList> GetMatchesByChampion(int championId, int skip, int count);

        Task<Match> GetMatch(string summonerName, long matchId);
    }
}