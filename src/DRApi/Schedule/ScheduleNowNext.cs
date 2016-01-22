using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DRApi.Schedule {
    public class ScheduleNowNext {                
        public string ChannelSlug { get; set; }
        public string Channel { get; set; }
        public ScheduleBroadcast Now { get; set; }
        public ICollection<ScheduleBroadcast> Next{ get; set; }

    }
}
