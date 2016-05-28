using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DRApi.List;

namespace DRApi.Search {
    public class Search {
        public string Title { get; set; }
        public bool IsRepremiere { get; set; }
        public ICollection<Programcard.Programcard> Items { get; set; }
        public Paging Paging { get; set; }
        public int TotalSize { get; set; }
    }
}
