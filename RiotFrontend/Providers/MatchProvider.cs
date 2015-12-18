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

            var matchTable = this.cloudManager.GetCloudTable(settings.MatchListTableName);
            var query = new TableQuery<MatchEntity>().Where(TableQuery.GenerateFilterCondition("RowKey", QueryComparisons.Equal, matchId));
            var matchEntity = matchTable.ExecuteQuery(query).FirstOrDefault();

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
            var matchTable = this.cloudManager.GetCloudTable(settings.MatchListTableName);
            var filter = TableQuery.GenerateFilterConditionForDate(
                "MatchCreationTime",
                QueryComparisons.GreaterThan,
                DateTimeOffset.UtcNow.Subtract(TimeSpan.FromHours(12)));

            var query = new TableQuery<MatchEntity>().Where(filter);
            var matches = matchTable.ExecuteQuery(query).OrderByDescending(match => match.MatchCreationTime).Take(count);
            var matchesInfo = matches.Select(m => JsonConvert.DeserializeObject<MatchInfo>(m.Match));
            return matchesInfo.Select(m => dtoConverter.GetMatchContract(m, FormatType.Simple)).ToList();
        }
    }
}