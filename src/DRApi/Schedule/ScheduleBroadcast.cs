using System;
using DrApi.Converters;

namespace DRApi.Schedule {
    public class ScheduleBroadcast {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Subtitle { get; set; }
        // Exact time, may differ from Announced
        [Newtonsoft.Json.JsonConverterAttribute(typeof(DateTimeConverter))]
        public DateTime StartTime { get; set; }
        // Exact time, may differ from Announced
        [Newtonsoft.Json.JsonConverterAttribute(typeof(DateTimeConverter))]
        public DateTime EndTime { get; set; }
        // Is only included if there is a primary asset
        public Programcard.Programcard ProgramCard { get; set; }
        public string ProductionNumber { get; set; }
        public bool ProgramCardHasPrimaryAsset { get; set; }
        public bool SeriesHasProgramCardWithPrimaryAsset { get; set; }
        [Newtonsoft.Json.JsonConverterAttribute(typeof(DateTimeConverter))]
        public DateTime BroadcastDate { get; set; }
        [Newtonsoft.Json.JsonConverterAttribute(typeof(DateTimeConverter))]
        public DateTime AnnouncedStartTime { get; set; }
        [Newtonsoft.Json.JsonConverterAttribute(typeof(DateTimeConverter))]
        public DateTime AnnouncedEndTime { get; set; }
        public string ProductionCountry { get; set; }
        public int ProductionYear { get; set; }
        public bool VideWidescreen { get; set; }
        public bool SubtitlesTTV { get; set; }
        public bool VideoHD { get; set; }
        // TODO: Change to URI
        public string WhatsOnUri { get; set; }
        public string Channel { get; set; }
        public string ChannelSlug { get; set; }

    }
}
