using Newtonsoft.Json;

namespace Tester.WebApi.Service.PushNotification
{
    public partial class GoogleNotification
    {

        [JsonProperty("priority")]
        public string Priority { get; set; } = "high";
        [JsonProperty("data")]
        public DataPayload Data { get; set; }
        [JsonProperty("notification")]
        public DataPayload Notification { get; set; }
    }
}
