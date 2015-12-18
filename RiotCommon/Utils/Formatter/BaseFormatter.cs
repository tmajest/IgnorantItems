using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace CoffeeCat.RiotCommon.Utils.Formatter
{
    internal class BaseFormatter
    {
        protected IStaticData staticData;

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
