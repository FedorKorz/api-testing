using System.Net;

namespace JsonPlaceholderTask.models
{
    public class ResponseModel
    {
        public HttpStatusCode HTTPResponseCode { get; set; }
        public string ContentType { get; set; }
        public List<Post> Posts { get; set; }
    }
}
