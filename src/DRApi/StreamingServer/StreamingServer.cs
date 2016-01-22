using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DRApi.StreamingServer {
    public class StreamingServer {
        public string Server { get; set; }
        // TODO: Change to enum!
        public string LinkType { get; set; }
        public IList<Quality> Qualitieses { get; set; }
        public bool DynamicUserQualityChange { get; set; }
    }
}
