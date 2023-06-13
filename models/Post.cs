using System.Net;

namespace JsonPlaceholderTask.models
{
    public class Post
    {
        public int userId { get; set; }
        public int id { get; set; }
        public string title { get; set; }
        public string body { get; set; }
        public HttpStatusCode HTTPResponseCode { get; set; }
    }
}
