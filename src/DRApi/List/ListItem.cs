using System;
using DrApi.Converters;
using Newtonsoft.Json;

namespace DRApi.List {
    /// <summary>
    /// OBESLUTE
    /// </summary>
    [Obsolete]
    public class ListItem {        
        public string Title { get; set; }
        public string Subtitle { get; set; }
        // TODO: URI MAYBE?
        public string PrimaryImageUri { get; set; }
        // TODO: Can this be changed to an enum??
        public string Type { get; set; }
        public string SeriesTitle { get; set; }
        public string SeriesSlug { get; set; }
        public string SeriesUrn { get; set; }
        // TODO: Change to URI
        public string PrimaryChannel { get; set; }
        public string PrimaryChannelSlug { get; set; }
        public bool PrePremiere { get; set; }
        public bool ExpriresSoon { get; set; }
        public string OnlineGenereText { get; set; }
        public Asset PrimaryAsset { get; set; }
        [JsonConverter(typeof(DateTimeConverter))]
        public DateTime PrimaryBroadcastStartTime { get; set; }
        public string Slug { get; set; }
        public string Urn { get; set; }       
    }
}