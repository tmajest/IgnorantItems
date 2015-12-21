using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CoffeeCat.RiotCommon.Contracts;
using CoffeeCat.RiotCommon.Contracts.Frontend;
using CoffeeCat.RiotCommon.Contracts.Uploader;
using Microsoft.WindowsAzure.Storage.Table;
using CoffeeCat.RiotCommon.Dto.StaticData.Champion;
using CoffeeCat.RiotCommon.Dto.StaticData.Item;
using CoffeeCat.RiotCommon.Dto.StaticData.Mastery;
using CoffeeCat.RiotCommon.Dto.StaticData.Rune;
using CoffeeCat.RiotCommon.Settings;
using CoffeeCat.RiotCommon.Utils;
using MatchContracts = CoffeeCat.RiotCommon.Dto.Match;

namespace RiotFrontend.Providers
{
    public class MatchProvider : IMatchProvider
    {
        private static readonly int DefaultMatchCount = 15;
        private static readonly string MatchCreationTimeColumn = "MatchCreationTime";
        private static readonly string ChampionIdColumn = "ChampionId";
        private static readonly string RowKeyColumn = "RowKey";

        private ICloudManager cloudManager;
        private IUploaderSettings settings;
        private IDtoConverter dtoConverter;

        public MatchProvider(
            ICloudManager cloudManager, 
            IDtoConverter dtoConverter,
            IUploaderSettings settings)
        {
            this.cloudManager = cloudManager;
            this.dtoConverter = dtoConverter;
            this.settings = settings;
        }

        public Match GetMatch(string matchId)
        {
            Validation.ValidateNotNullOrWhitespace(matchId, nameof(matchId));

            var filter = TableQuery.GenerateFilterCondition(RowKeyColumn, QueryComparisons.Equal, matchId);
            var matchEntity = this.cloudManager.GetRows<MatchEntity>(settings.MatchListTableName, filter)
                .FirstOrDefault();

            if (matchEntity == null)
            {
                return null;
            }

            var matchInfo = JsonConvert.DeserializeObject<MatchInfo>(matchEntity.Match);
            return dtoConverter.GetMatchContract(matchInfo, FormatType.Detailed);
        }

        public List<Match> GetMatches()
        {
            return this.GetMatches(DefaultMatchCount);
        }

        public List<Match> GetMatches(int count)
        {
            var filter = TableQuery.GenerateFilterConditionForDate(
                MatchCreationTimeColumn,
                QueryComparisons.GreaterThan,
                DateTimeOffset.UtcNow.Subtract(TimeSpan.FromHours(12)));

            var matches = this.cloudManager.GetRows<MatchEntity>(settings.MatchListTableName, filter)
                .OrderByDescending(match => match.MatchCreationTime)
                .Take(count);

            var matchesInfo = matches.Select(m => JsonConvert.DeserializeObject<MatchInfo>(m.Match));
            return matchesInfo.Select(m => dtoConverter.GetMatchContract(m, FormatType.Simple)).ToList();
        }

        public List<Match> GetMatches(string championId)
        {
            return this.GetMatches(championId, DefaultMatchCount);
        }

        public List<Match> GetMatches(string championId, int count)
        {
            Validation.ValidateNotNullOrWhitespace(championId, nameof(championId));

            var championFilter = TableQuery.GenerateFilterCondition(
                ChampionIdColumn,
                QueryComparisons.Equal,
                championId);

            var matches = this.cloudManager.GetRows<MatchEntity>(settings.MatchListTableName, championFilter)
                .OrderByDescending(match => match.MatchCreationTime)
                .Take(count);

            var matchesInfo = matches.Select(m => JsonConvert.DeserializeObject<MatchInfo>(m.Match));
            return matchesInfo.Select(m => dtoConverter.GetMatchContract(m, FormatType.Simple)).ToList();
        }
    }
}