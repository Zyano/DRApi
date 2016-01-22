using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DRApi.StreamingServer {
    public class Quality {
        public int Kbps { get; set; }
        public IList<String> Streams { get; set; }
    }
}
