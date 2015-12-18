using System.Threading.Tasks;
using CoffeeCat.RiotCommon.Dto.StaticData.Champion;
using CoffeeCat.RiotCommon.Dto.StaticData.Item;
using CoffeeCat.RiotCommon.Dto.StaticData.Mastery;
using CoffeeCat.RiotCommon.Dto.StaticData.Rune;
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

        public StaticData(ICloudManager cloudManager, IUploaderSettings settings)
        {
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

            Task.WaitAll(runeTask, masteryTask, championTask, itemTask);

            this.RuneList = GetList<RuneListDto>(runeTask);
            this.MasteryList = GetList<MasteryListDto>(masteryTask);
            this.ChampionList = GetList<ChampionListDto>(championTask);
            this.ItemList = GetList<ItemListDto>(itemTask);
        }

        private static T GetList<T>(Task<string> downloadTask)
        {
            var json = downloadTask.Result;
            return JsonConvert.DeserializeObject<T>(json);
        }
    }
}