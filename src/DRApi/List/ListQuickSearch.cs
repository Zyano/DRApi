using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DRApi.List {
    public class ListQuickSearchResponse {
        public IList<QuickSearchItem> Programs { get; set; }
        public IList<QuickSearchItem> Episodes { get; set; }
        public IList<QuickSearchItem> Generes { get; set; }
        public IList<QuickSearchItem> Channels { get; set; }
    }
}
