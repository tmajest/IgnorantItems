using System.Collections.Generic;
using CoffeeCat.RiotCommon.Settings;
using CoffeeCat.RiotCommon.Utils;
using CoffeeCat.RiotFrontend.Models;
using IDtoConverter = CoffeeCat.RiotFrontend.BusinessLogic.Converters.IDtoConverter;

namespace CoffeeCat.RiotFrontend.Providers
{
    public class MatchProvider : IMatchProvider
    {
        private static readonly int DefaultMatchCount = 15;

        private ICloudManager cloudManager;
        private ICommonSettings settings;
        private IDtoConverter dtoConverter;

        public MatchProvider(
            ICloudManager cloudManager, 
            IDtoConverter dtoConverter,
            ICommonSettings settings)
        {
            this.cloudManager = cloudManager;
            this.dtoConverter = dtoConverter;
            this.settings = settings;
        }

        public Match GetMatch(string matchId)
        {
            Validation.ValidateNotNullOrWhitespace(matchId, nameof(matchId));

            /*
            var filter = TableQuery.GenerateFilterCondition(RowKeyColumn, QueryComparisons.Equal, matchId);
            var matchEntity = this.cloudManager.GetRows<MatchEntity>(settings.MatchListTableName, filter)

            if (matchEntity == null)
            {
                return null;
            }

            var matchInfo = JsonConvert.DeserializeObject<MatchInfo>(matchEntity.Match);
            return dtoConverter.GetMatchContract(matchInfo, FormatType.Detailed);
            */
            return null;
        }

        public Match GetMatch(string matchId, string summonerName)
        {
            Validation.ValidateNotNullOrWhitespace(matchId, nameof(matchId));
            Validation.ValidateNotNullOrWhitespace(summonerName, nameof(summonerName));

            /*
            var rowKeyFilter = TableQuery.GenerateFilterCondition(RowKeyColumn, QueryComparisons.Equal, matchId);
            var partitionKeyFilter = TableQuery.GenerateFilterCondition(PartitionKeyColumn, QueryComparisons.Equal, summonerName.ToLowerInvariant());
            var finalFilter = TableQuery.CombineFilters(rowKeyFilter, TableOperators.And, partitionKeyFilter);

            var matchEntity = this.cloudManager.GetRows<MatchEntity>(settings.MatchListTableName, finalFilter)
                .FirstOrDefault();

            if (matchEntity == null)
            {
                return null;
            }

            var matchInfo = JsonConvert.DeserializeObject<MatchInfo>(matchEntity.Match);
            return dtoConverter.GetMatchContract(matchInfo, FormatType.Detailed);
            */
            return null;
        }

        public List<Match> GetMatches()
        {
            return this.GetMatches(DefaultMatchCount);
        }

        public List<Match> GetMatches(int count)
        {
            /*
            var filter = TableQuery.GenerateFilterConditionForDate(
                MatchCreationTimeColumn,
                QueryComparisons.GreaterThan,
                DateTimeOffset.UtcNow.Subtract(TimeSpan.FromHours(12)));

            var matches = this.cloudManager.GetRows<MatchEntity>(settings.MatchListTableName, filter)
                .OrderByDescending(match => match.MatchCreationTime)
                .Take(count);

            var matchesInfo = matches.Select(m => JsonConvert.DeserializeObject<MatchInfo>(m.Match));
            return matchesInfo.Select(m => dtoConverter.GetMatchContract(m, FormatType.Simple)).ToList();
            */
            return null;
        }

        public List<Match> GetMatches(string championId)
        {
            return this.GetMatches(championId, DefaultMatchCount);
        }

        public List<Match> GetMatches(string championId, int count)
        {
            Validation.ValidateNotNullOrWhitespace(championId, nameof(championId));

            /*
            var championFilter = TableQuery.GenerateFilterCondition(
                ChampionIdColumn,
                QueryComparisons.Equal,
                championId);

            var matches = this.cloudManager.GetRows<MatchEntity>(settings.MatchListTableName, championFilter)
                .OrderByDescending(match => match.MatchCreationTime)
                .Take(count);

            var matchesInfo = matches.Select(m => JsonConvert.DeserializeObject<MatchInfo>(m.Match));
            return matchesInfo.Select(m => dtoConverter.GetMatchContract(m, FormatType.Simple)).ToList();
            */
            return null;
        }
    }
}