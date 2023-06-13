using Newtonsoft.Json;

namespace JsonPlaceholderTask.utils
{
    public static class UtilsReadJson
    {

        public static string ReadJsonFile(string key, string filename)
        {
            string pathJson = Path.GetFullPath($"Resources\\{filename}.json");
            try
            {
                dynamic file = JsonConvert.DeserializeObject(File.ReadAllText(pathJson));
                return Convert.ToString(file[$"{key}"]);
            }
            catch
            {
                return null;
            }
        }

    }
}

