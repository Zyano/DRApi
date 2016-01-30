using System;
using DrApi.Converters;
using Newtonsoft.Json;

namespace DRApi.List {
    public class Paging {
        public string Title { get; set; }
        [JsonConverter(typeof(UriConverter))]
        public Uri Source { get; set; }
        [JsonConverter(typeof(UriConverter))]
        public Uri Next { get; set; }
        [JsonConverter(typeof(UriConverter))]
        public Uri Previous { get; set; }
        public int TotalSize { get; set; }
    }
}