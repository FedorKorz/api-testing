using Newtonsoft.Json.Linq;
using System.Net;

namespace JsonPlaceholderTask.models
{
    public class UserModel
    {
        public HttpStatusCode HTTPResponseCode { get; set; }
        public string ContentType { get; set; }
        public string Name { get; set; }
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public JObject Address { get; set; }
        public string Phone { get; set; }
        public string Website { get; set; }
        public JObject Company { get; set; }

    }
}
