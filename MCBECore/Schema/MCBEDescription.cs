using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Newtonsoft.Json;

namespace MCBECore.Schema
{
    [JsonObject("description")]
    public class MCBEDescription
    {
        public MCBEDescription() {}

        /// <summary>
        /// コピーコンストラクタ
        /// </summary>
        public MCBEDescription(MCBEDescription source)
        {
            this.id = source.id;
            this.isInternal = source.isInternal;
            this.comment = source.comment;
            this.text = source.text;
            this.image = source.image;
        }

        [JsonProperty("_id")]
        public string id;

        [JsonProperty("is_internal")]
        [DefaultValue(false)]
        public bool isInternal;

        [JsonProperty("comment")]
        [DefaultValue(null)]
        public string comment;

        [JsonProperty("text")]
        public string text;

        [JsonProperty("image")]
        [DefaultValue(null)]
        public string image;
    }
}
