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
        public RuneListDto RuneList { get; }
        public MasteryListDto MasteryList { get; }
        public ChampionListDto ChampionList { get; }
        public ItemListDto ItemList { get; }
        public SummonerSpellListDto SummonerSpellList { get; }

        public StaticData(ICloudManager cloudManager, IUploaderSettings settings)
        {
            /*
            var runeTask = cloudManager.DownloadTextAsync(
                settings.DataContainerName,
                settings.RunesBlobPath);

            var masteryTask = cloudManager.DownloadTextAsync(
                settings.DataContainerName,
                settings.MasteriesBlobPath);

            var championTask = cloudManager.DownloadTextAsync(
                settings.DataContainerName,
                settings.ChampionsBlobPath);

            var itemTask = cloudManager.DownloadTextAsync(
                settings.DataContainerName,
                settings.ItemsBlobPath);

            var summonerSpellsTask = cloudManager.DownloadTextAsync(
                settings.DataContainerName,
                settings.SummonerSpellsBlobPath);

            Task.WaitAll(runeTask, masteryTask, championTask, itemTask, summonerSpellsTask);

            this.RuneList = GetList<RuneListDto>(runeTask);
            this.MasteryList = GetList<MasteryListDto>(masteryTask);
            this.ChampionList = GetList<ChampionListDto>(championTask);
            this.ItemList = GetList<ItemListDto>(itemTask);
            this.SummonerSpellList = GetList<SummonerSpellListDto>(summonerSpellsTask);
            */
        }

        private static T GetList<T>(Task<string> downloadTask)
        {
            var json = downloadTask.Result;
            return JsonConvert.DeserializeObject<T>(json);
        }
    }
}