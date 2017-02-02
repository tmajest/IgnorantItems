using System.Collections.Generic;
using System.Threading.Tasks;
using CoffeeCat.RiotFrontend.Models;

namespace CoffeeCat.RiotFrontend.Providers
{
    public interface IMatchProvider
    {
        Task<List<Match>> GetMatches();

        Task<List<Match>> GetMatches(int count);

        Task<List<Match>> GetMatchesByChampion(int championId);

        Task<List<Match>> GetMatchesByChampion(int championId, int count);

        Task<Match> GetMatch(string summonerName, long matchId);
    }
}