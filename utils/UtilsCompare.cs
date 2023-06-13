using Newtonsoft.Json.Linq;

namespace JsonPlaceholderTask.utils
{
    public static class UtilsCompare
    {
        public static bool SearchInJSONArray(JArray arrayOfUsersActual, string key)
        {
            bool flag = false;
            var arrayUsersJson = UtilsReadJson.ReadJsonFile(key, "testData");
            JArray arrayOfUsersExpected = UtilsGenArray.FromJson(arrayUsersJson);


            for (int i = 0; i < arrayOfUsersExpected.Count; i++)
            {
                if (JToken.DeepEquals(arrayOfUsersExpected[i].ToString(), arrayOfUsersActual[i].ToString()))
                {
                    flag = true;
                }
                else
                {
                    return false;
                }
            }
            return flag;
        }

        public static bool CompareJSONObjects(JToken jToken, JToken node)
        {
            return JToken.DeepEquals(jToken.ToString(), node.ToString());
        }
    }
}
