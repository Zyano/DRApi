using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DRApi.Manifest {
    public class ManifestResponse {
        public MediaLink Links { get; set; }
        public Subtitle SubtitlesList { get; set; }

    }
}
