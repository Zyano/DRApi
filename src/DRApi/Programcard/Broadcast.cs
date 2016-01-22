using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DRApi.Programcard {
    public class Broadcast {
        public DateTime BroadcastDate { get; set; }
        public DateTime AnnouncedStartTime { get; set; }
        public DateTime AnnouncedEndTime { get; set; }
        public string ProductionCountry { get; set; }
        public int ProductionYear { get; set; }
        public bool VideoWidescreen { get; set; }
        public bool SubtitlesTTV { get; set; }
        public bool VideoHD { get; set; }
        public string WhatsOnUri { get; set; }
        public string Channel { get; set; }
        public string ChannelSlug { get; set; }
    }
}
