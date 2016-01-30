using System.Collections.Generic;
using DRApi.Manifest;


namespace DRApi.Bar {
    public class BarResponse {
        public ICollection<Link> Links { get; set; }
        public ICollection<Subtitle> SubtitlesList { get; set; }
    }
}