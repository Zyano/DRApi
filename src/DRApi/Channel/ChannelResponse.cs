using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using DRApi.StreamingServer;

namespace DRApi.Channel {
    public class ChannelResponse {
        // TODO: Enum
        public string Type { get; set; }        
        public IList<StreamingServer.StreamingServer> StreamingServers { get; set; }
        // TODO: Change to URI
        public string Url { get; set; }
        // TODO: Change to URI
        public string SourceUrl { get; set; }
        public bool WebChannel { get; set; }
        public string Slug { get; set; }
        public string Urn { get; set; }
        // TODO: Change to URI
        public string PrimaryImageUri { get; set; }
        public string Title { get; set; }
        public string Subtitle { get; set; }
    }
}
