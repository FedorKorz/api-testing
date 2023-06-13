using Newtonsoft.Json.Linq;

namespace JsonPlaceholderTask.utils
{
    public static class UtilsGenArray
    {
        public static JArray FromJson(dynamic arrayUsersJson)
        {
            return JArray.Parse(arrayUsersJson);
        }
    }
}
