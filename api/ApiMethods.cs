using JsonPlaceholderTask.models;
using JsonPlaceholderTask.utils;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;

namespace JsonPlaceholderTask.api
{
    public class ApiMethods
    {
        RestClient client = new RestClient(UtilsReadJson.ReadJsonFile("url", "config"));

        public ResponseModel GetAllPosts()
        {
            const string endPoint = "/posts";
            var request = new RestRequest(endPoint, Method.Get);
            RestResponse response = client.Execute(request);
            return new()
            {
                HTTPResponseCode = response.StatusCode,
                ContentType = response.ContentType!,
                Posts = JsonConvert.DeserializeObject<List<Post>>(response.Content!)!
            };
        }

        public Post GetSpecificPost(int index)
        {
            string endPoint = $"/posts/{index}";
            var request = new RestRequest(endPoint, Method.Get);
            RestResponse response = client.Execute(request);
            var post = (JObject)JsonConvert.DeserializeObject(response.Content!)!;

            return new()
            {
                title = post["title"]!.Value<string>()!,
                userId = post["userId"]!.Value<int>()!,
                body = post["body"]!.Value<string>()!,
                id = post["id"]!.Value<int>(),
                HTTPResponseCode = response.StatusCode
            };
        }

        public RestResponse Get150thPost(int index)
        {
            string endPoint = $"/posts/{index}";
            var request = new RestRequest(endPoint, Method.Get);
            RestResponse response = client.Execute(request);
            return response;
        }

        public Post MakeAPost()
        {
            string endPoint = "/posts";
            var request = new RestRequest(endPoint, Method.Post);
            request.AddParameter("application/json", UtilsReadJson.ReadJsonFile("newPost", "testData"), ParameterType.RequestBody);
            RestResponse response = client.Execute(request);
            var post101th = (JObject)JsonConvert.DeserializeObject(response.Content!)!;
            return new()
            {
                title = post101th["title"]!.Value<string>()!,
                userId = post101th["userId"]!.Value<int>()!,
                body = post101th["body"]!.Value<string>()!,
                id = post101th["id"]!.Value<int>(),
                HTTPResponseCode = response.StatusCode
            };
        }

        public UserModel GetUser(int index)
        {
            string endPoint = "/users";
            var request = new RestRequest(endPoint, Method.Get);
            RestResponse response = client.Execute(request);
            JArray arrayOfUserts = (JArray)JsonConvert.DeserializeObject(response.Content!)!;
            JObject user5th = (JObject)arrayOfUserts[index - 1];

            return new()
            {
                HTTPResponseCode = response.StatusCode,
                ContentType = response.ContentType!,
                Id = (int)user5th.SelectToken("id")!,
                Name = (string)user5th.SelectToken("name")!,
                Username = (string)user5th.SelectToken("username")!,
                Email = (string)user5th.SelectToken("email")!,
                Address = (JObject)user5th.SelectToken("address")!,
                Phone = (string)user5th.SelectToken("phone")!,
                Website = (string)user5th.SelectToken("website")!,
                Company = (JObject)user5th.SelectToken("company")!
            };
        }

        public RestResponse ExecuteRequest(string endPoint, Method method)
        {
            var request = new RestRequest(endPoint, Method.Get);
            RestResponse response = client.Execute(request);
            return response;
        }

        public UserModel Get5thUser(int index)
        {
            var response = ExecuteRequest($"users/{index}", Method.Post);
            var user5th = (JObject)JsonConvert.DeserializeObject(response.Content!)!;
            return new()
            {
                HTTPResponseCode = response.StatusCode,
                ContentType = response.ContentType!,
                Id = (int)user5th.SelectToken("id")!,
                Name = (string)user5th.SelectToken("name")!,
                Username = (string)user5th.SelectToken("username")!,
                Email = (string)user5th.SelectToken("email")!,
                Address = (JObject)user5th.SelectToken("address")!,
                Phone = (string)user5th.SelectToken("phone")!,
                Website = (string)user5th.SelectToken("website")!,
                Company = (JObject)user5th.SelectToken("company")!
            };
        }
    }
}
