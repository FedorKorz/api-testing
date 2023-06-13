using JsonPlaceholderTask.utils;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace JsonPlaceholderTask.models
{
    public class TestDataModel
    {
        public static string EmptyResponse()
        {
            return UtilsReadJson.ReadJsonFile("emptyResponse", "testData");
        }

        public static string Address()
        {
            return UtilsReadJson.ReadJsonFile("address", "testData");
        }

        public static string Company()
        {
            return UtilsReadJson.ReadJsonFile("company", "testData");
        }

        public static JObject User()
        {
            var user = UtilsReadJson.ReadJsonFile("user", "testData");
            return JsonConvert.DeserializeObject<JObject>(user!)!;
        }
    }
}
