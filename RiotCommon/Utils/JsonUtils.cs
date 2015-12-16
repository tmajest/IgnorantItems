using Newtonsoft.Json;

namespace CoffeeCat.RiotCommon.Utils
{
    public class JsonUtils
    {
        public static string Serialize<T>(T obj)
        {
            Validation.ValidateNotNull(obj, "obj");
            return JsonConvert.SerializeObject(obj);
        }

        public static T Deserialize<T>(string json) where T : class
        {
            Validation.ValidateNotNullOrWhitespace(json, "json");
            return JsonConvert.DeserializeObject<T>(json);
        }
    }
}
