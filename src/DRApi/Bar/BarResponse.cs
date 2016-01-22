using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using DRApi.Http;
using DRApi.Manifest;
using Newtonsoft.Json.Converters;


namespace DRApi.Bar {
    public class BarResponse {
        public ICollection<Link> Links { get; set; }

        public ICollection<Subtitle> SubtitlesList { get; set; }

    }
}
