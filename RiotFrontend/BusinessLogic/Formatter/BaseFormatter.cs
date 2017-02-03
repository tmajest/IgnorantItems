using CoffeeCat.RiotCommon.Utils;
using Newtonsoft.Json;

namespace CoffeeCat.RiotFrontend.BusinessLogic.Formatter
{
    internal class BaseFormatter
    {
        protected readonly IStaticData staticData;

        public BaseFormatter(IStaticData staticData)
        {
            this.staticData = staticData;
        }

        protected static T CloneDto<T>(T obj)
        {
            return JsonConvert.DeserializeObject<T>(JsonConvert.SerializeObject(obj));
        }
    }
}
