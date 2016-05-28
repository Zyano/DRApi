using System.Collections.Generic;

namespace DRApi.List {
    public class ListResponse {
        public string Title { get; set; }
        public bool IsRepremiere { get; set; }
        public ICollection<Programcard.Programcard> Items { get; set; }
        public Paging Paging { get; set; }
        public int TotalSize { get; set; }
    }
}
