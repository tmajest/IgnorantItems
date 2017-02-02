using System;
using System.Threading;
using System.Threading.Tasks;
using CoffeeCat.RiotCommon.Contracts.RiotApi.StaticData.Champion;
using CoffeeCat.RiotCommon.Contracts.RiotApi.StaticData.Item;
using CoffeeCat.RiotCommon.Contracts.RiotApi.StaticData.Mastery;
using CoffeeCat.RiotCommon.Contracts.RiotApi.StaticData.Rune;
using CoffeeCat.RiotCommon.Contracts.RiotApi.StaticData.SummonerSpells;
using CoffeeCat.RiotCommon.Settings;
using Microsoft.WindowsAzure.Storage;
using Newtonsoft.Json;

namespace CoffeeCat.RiotCommon.Utils
{
    public class StaticData : IStaticData
    {
        private readonly ICloudManager cloudManager;
        private readonly ICommonSettings settings;
        private readonly Timer UpdateTimer;

        public RuneListDto RuneList { get; private set; }

        public MasteryListDto MasteryList { get; private set; }
        
        public ChampionListDto ChampionList { get; private set; }

        public ItemListDto ItemList { get; private set; }

        public SummonerSpellListDto SummonerSpellList { get; private set; }

        public StaticData(ICloudManager cloudManager, ICommonSettings settings)
        {
            this.cloudManager = cloudManager;
            this.settings = settings;
            this.UpdateTimer = new Timer(UpdateStaticData, null, TimeSpan.Zero, this.settings.StaticDataRefreshRate);
        }

        private void UpdateStaticData(object state)
        {
            var runeTask = cloudManager.DownloadTextAsync(
                settings.StaticDataContainerName,
                settings.RunesBlobPath);

            var masteryTask = cloudManager.DownloadTextAsync(
                settings.StaticDataContainerName,
                settings.MasteriesBlobPath);

            var championTask = cloudManager.DownloadTextAsync(
                settings.StaticDataContainerName,
                settings.ChampionsBlobPath);

            var itemTask = cloudManager.DownloadTextAsync(
                settings.StaticDataContainerName,
                settings.ItemsBlobPath);

            var summonerSpellsTask = cloudManager.DownloadTextAsync(
                settings.StaticDataContainerName,
                settings.SummonerSpellsBlobPath);

            Task.WaitAll(runeTask, masteryTask, championTask, itemTask, summonerSpellsTask);

            this.RuneList = GetList<RuneListDto>(runeTask);
            this.MasteryList = GetList<MasteryListDto>(masteryTask);
            this.ChampionList = GetList<ChampionListDto>(championTask);
            this.ItemList = GetList<ItemListDto>(itemTask);
            this.SummonerSpellList = GetList<SummonerSpellListDto>(summonerSpellsTask);
        }

        private static T GetList<T>(Task<string> downloadTask)
        {
            var json = downloadTask.Result;
            return JsonConvert.DeserializeObject<T>(json);
        }
    }
}