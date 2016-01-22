using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DRApi.Programcard {
    public class Chapter {
        public string Title { get; set; }
        public string Description { get; set; }
        public int OffsetInMiliseconds { get; set; }
        public string PrimaryImageUri { get; set; }
    }
}
