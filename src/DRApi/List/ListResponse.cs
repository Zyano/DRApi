using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DRApi.List {
    public class ListResponse {
        public string Title { get; set; }
        public bool IsRepremiere { get; set; }
        public ICollection<ListItem> Items { get; set; }
        public Paging Paging { get; set; }
        public int TotalSize { get; set; }
    }
}
