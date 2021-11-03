using Newtonsoft.Json;

namespace Tester.WebApi.Service.PushNotification
{
    public partial class GoogleNotification
    {
        public class DataPayload
        {
            [JsonProperty("title")]
            public string Title { get; set; }
            [JsonProperty("body")]
            public string Body { get; set; }
        }
    }
}
