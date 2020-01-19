using System.Collections.Generic;
using System.ComponentModel;
using Newtonsoft.Json;

namespace MCBECore.Schema
{
    [JsonObject("rule")]
    public class MCBERule
    {
        public MCBERule() { }

        public MCBERule(MCBERule source)
        {
            this.id = source.id;
            this.comment = source.comment;
            this.priority = source.priority;

            this.antecedents = new Dictionary<string, bool>(source.antecedents);
            this.consequents = new Dictionary<string, bool>(source.consequents);
        }

        [JsonProperty("_id")]
        public string id;

        [JsonProperty("comment")]
        [DefaultValue(null)]
        public string comment;

        [JsonProperty("priority")]
        public int priority;

        [JsonProperty("antecedents")]
        public Dictionary<string, bool> antecedents;

        [JsonProperty("consequents")]
        public Dictionary<string, bool> consequents;
    }
}
