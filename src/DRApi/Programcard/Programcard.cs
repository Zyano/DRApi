using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DrApi.Converters;

namespace DRApi.Programcard {
    public class Programcard {
        public string Description { get; set; }
        public string ProductionNumber { get; set; }
        // TODO: Change to URI
        public string SeriesSiteUrl { get; set; }
        public Broadcast PrimaryBroadcast { get; set; }
        public ICollection<Chapter> Chapters { get; set; }

        // Optional list of secondary assets. A secondary asset can be a sign language version, or hard of hearing version etc.
        public Asset Asset { get; set; }
        public string Type { get; set; }
        public string SeriesTitle { get; set; }
        public string SeriesSlug { get; set; }
        public string SeriesUrn { get; set; }
        public string IsNewSeries { get; set; }
        public string SeriesHostName { get; set; }
        public string PrimaryChannel { get; set; }
        public string PrimaryChannelSlug { get; set; }
        public bool PrePremiere { get; set; }
        public bool ExpiresSoon { get; set; }
        public int DurationInMilliseconds { get; set; }
        public int ProgressSeconds { get; set; }
        public string OnlineGenereText { get; set; }
        public bool Repremiere { get; set; }
        public string Hostname { get; set; }
        public string RectificationStatus { get; set; }
        public bool RectificationAuto { get; set; }
        public string RectificationText { get; set; }
        public string RectificationLink { get; set; }
        public string RectificationLinkText { get; set; }
        public Asset PrimaryAsset { get; set; }
        [Newtonsoft.Json.JsonConverterAttribute(typeof(DateTimeConverter))]
        public DateTime PrimaryBroadcastDay { get; set; }
        public string Slug { get; set; }
        public string Urn { get; set; }
        // TODO: Change to URI
        public string PrimaryImageUri { get; set; }
        public string Title { get; set; }
        public string SubTitle { get; set; }
    }
}