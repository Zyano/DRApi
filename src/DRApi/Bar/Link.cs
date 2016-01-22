using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DrApi.Converters;
using Newtonsoft.Json;

namespace DRApi.Bar {
    public class Link {
        public String HardSubtitlesType { get; set; }
        [JsonConverter(typeof(UriConverter))]
        public Uri Uri { get; set; }
        public string EncryptedUri { get; set; }
        public string FileFormat { get; set; }
        public string Target { get; set; }
        public int Bitrate { get; set; }

    }
}
