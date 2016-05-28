using System;
using DrApi.Converters;
using Newtonsoft.Json;

namespace DRApi {
    public class Asset {
        // TODO: Change to Enum
        public string Kind { get; set; }
        [JsonConverter(typeof(UriConverter))]
        public Uri Uri { get; set; }
        public int DurationInMilliSeconds { get; set; }
        public bool RestrictedToDenmark { get; set; }
        [JsonConverter(typeof(DateTimeConverter))]
        public DateTime StartPublish { get; set; }
        [JsonConverter(typeof(DateTimeConverter))]
        public DateTime EndPublish { get; set; }
        public string Target { get; set; }
        public bool Encrypted { get; set; }
    }
}
