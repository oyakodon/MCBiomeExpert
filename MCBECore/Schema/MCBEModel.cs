using System.Collections.Generic;
using Newtonsoft.Json;

namespace MCBECore.Schema
{
    [JsonObject("model")]
    public class MCBEModel
    {
        [JsonProperty("_id")]
        public string id;

        [JsonProperty("name")]
        public string name;

        [JsonProperty("descriptions")]
        public List<MCBEDescription> descriptions;

        [JsonProperty("rules")]
        public List<MCBERule> rules;
    }
}
