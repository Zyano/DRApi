using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DrApi.Converters;

namespace DRApi {
    public class Asset {
        // TODO: Change to Enum
        public string Kind { get; set; }
        // TODO: Change to URI
        public string Uri { get; set; }
        public int DurationInMilliSeconds { get; set; }
        public bool RestrictedToDenmark { get; set; }
        [Newtonsoft.Json.JsonConverterAttribute(typeof(DateTimeConverter))]
        public DateTime StartPublish { get; set; }
        [Newtonsoft.Json.JsonConverterAttribute(typeof(DateTimeConverter))]
        public DateTime EndPublish { get; set; }
        public string Target { get; set; }
        public bool Encrypted { get; set; }
    }
}
