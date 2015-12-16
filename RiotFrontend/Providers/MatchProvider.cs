using Newtonsoft.Json;
using System.ComponentModel.Composition;
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
        private ICloudManager cloudManager;
        private IUploaderSettings settings;
        private IDtoConverter dtoConverter;

        [ImportingConstructor]
        public MatchProvider(
            ICloudManager cloudManager, 
            IDtoConverter dtoConverter,
            [Import("Settings")] IUploaderSettings settings)
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

            return matchEntity == null 
                ? null 
                : dtoConverter.GetMatchContract(JsonConvert.DeserializeObject<MatchInfo>(matchEntity.Match));
        }

        public List<Match> GetMatches()
        {
            var matchTable = this.cloudManager.GetCloudTable(settings.MatchListTableName);
            var filter = TableQuery.GenerateFilterConditionForDate(
                "MatchCreationTime",
                QueryComparisons.GreaterThan,
                DateTimeOffset.UtcNow.Subtract(TimeSpan.FromDays(1)));

            var query = new TableQuery<MatchEntity>().Where(filter);
            var matches = matchTable.ExecuteQuery(query).OrderByDescending(match => match.MatchCreationTime).Take(40);
            var matchesInfo = matches.Select(m => JsonConvert.DeserializeObject<MatchInfo>(m.Match));
            return matchesInfo.Select(dtoConverter.GetMatchContract).ToList();
        }
    }
}