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
using Nito.AsyncEx;

namespace CoffeeCat.RiotCommon.Utils
{
    public class StaticData : IStaticData
    {
        private readonly ICloudManager cloudManager;
        private readonly ICommonSettings settings;
        private readonly Timer UpdateTimer;
        private AsyncReaderWriterLock asyncLock;

        private RuneListDto runeList;
        private MasteryListDto masteryList;
        private ChampionListDto championList;
        private ItemListDto itemList;
        private SummonerSpellListDto summonerSpellList;

        public RuneListDto RuneList
        {
            get
            {
                using (this.asyncLock.ReaderLock())
                {
                    return this.runeList;
                }
            }
        }

        public MasteryListDto MasteryList
        {
            get
            {
                using (this.asyncLock.ReaderLock())
                {
                    return this.masteryList;
                }
            }
        }
        
        public ChampionListDto ChampionList
        {
            get
            {
                using (this.asyncLock.ReaderLock())
                {
                    return this.championList;
                }
            }
        }

        public ItemListDto ItemList
        {
            get
            {
                using (this.asyncLock.ReaderLock())
                {
                    return this.itemList;
                }
            }
        }

        public SummonerSpellListDto SummonerSpellList
        {
            get
            {
                using (this.asyncLock.ReaderLock())
                {
                    return this.summonerSpellList;
                }
            }
        }

        public StaticData(ICloudManager cloudManager, ICommonSettings settings)
        {
            this.cloudManager = cloudManager;
            this.settings = settings;
            this.UpdateTimer = new Timer(
                UpdateStaticData, 
                null, 
                this.settings.StaticDataRefreshRate, 
                this.settings.StaticDataRefreshRate);

            this.asyncLock = new AsyncReaderWriterLock();

            this.UpdateStaticData(null);
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

            using (this.asyncLock.WriterLock())
            {
                this.runeList = GetList<RuneListDto>(runeTask);
                this.masteryList = GetList<MasteryListDto>(masteryTask);
                this.championList = GetList<ChampionListDto>(championTask);
                this.itemList = GetList<ItemListDto>(itemTask);
                this.summonerSpellList = GetList<SummonerSpellListDto>(summonerSpellsTask);
            }
        }

        private static T GetList<T>(Task<string> downloadTask)
        {
            var json = downloadTask.Result;
            return JsonConvert.DeserializeObject<T>(json);
        }
    }
}