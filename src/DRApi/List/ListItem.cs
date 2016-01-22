using System;
using System.Reflection;
using DrApi.Converters;

namespace DRApi.List {
    public class ListItem {        
        public string Title { get; set; }
        public string Subtitle { get; set; }
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
        [Newtonsoft.Json.JsonConverterAttribute(typeof(DateTimeConverter))]
        public DateTime PrimaryBroadcastStartTime { get; set; }
        public string Slug { get; set; }
        public string Urn { get; set; }       
    }
}