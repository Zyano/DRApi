using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DrApi.Converters;

namespace DRApi.Schedule {
    public class Schedule {
        public ICollection<ScheduleBroadcast> Broadcasts { get; set; }
        [Newtonsoft.Json.JsonConverterAttribute(typeof(DateTimeConverter))]
        public DateTime BroadcastDate { get; set; }
        public string ChannelSlug { get; set; }
        public string Channel { get; set; }

    }
}
