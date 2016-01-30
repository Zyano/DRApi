using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using DrApi.Converters;
using DRApi.StreamingServer;
using Newtonsoft.Json;

namespace DRApi.Channel {
    public class ChannelResponse {
        // TODO: Enum
        public string Type { get; set; }        
        public IList<StreamingServer.StreamingServer> StreamingServers { get; set; }
        [JsonConverter(typeof(UriConverter))]
        public Uri Url { get; set; }
        [JsonConverter(typeof(UriConverter))]
        public Uri SourceUrl { get; set; }
        public bool WebChannel { get; set; }
        public string Slug { get; set; }
        public string Urn { get; set; }
        [JsonConverter(typeof(UriConverter))]
        public Uri PrimaryImageUri { get; set; }
        public string Title { get; set; }
        public string Subtitle { get; set; }
    }
}
