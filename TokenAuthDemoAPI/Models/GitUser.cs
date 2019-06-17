using Newtonsoft.Json;

namespace TokenAuthDemoAPI.Models
{
    public class GitUser
    {
        [JsonProperty("login")]
        public string login { get; set; }

        [JsonProperty("id")]
        public int id { get; set; }

        [JsonProperty("node_id")]
        public string node_id { get; set; }

        [JsonProperty("avatar_url")]
        public string avatar_url { get; set; }

        [JsonProperty("gravatar_id")]
        public string gravatar_id { get; set; }

        [JsonProperty("url")]
        public string url { get; set; }

        [JsonProperty("html_url")]
        public string html_url { get; set; }

        [JsonProperty("followers_url")]
        public string followers_url { get; set; }

        [JsonProperty("following_url")]
        public string following_url { get; set; }

        [JsonProperty("gists_url")]
        public string gists_url { get; set; }

        [JsonProperty("starred_url")]
        public string starred_url { get; set; }

        [JsonProperty("subscriptions_url")]
        public string subscriptions_url { get; set; }

        [JsonProperty("organizations_url")]
        public string organizations_url { get; set; }

        [JsonProperty("repos_url")]
        public string repos_url { get; set; }

        [JsonProperty("events_url")]
        public string events_url { get; set; }

        [JsonProperty("received_events_url")]
        public string received_events_url { get; set; }

        [JsonProperty("type")]
        public string type { get; set; }

        [JsonProperty("site_admin")]
        public bool site_admin { get; set; }
    }
}