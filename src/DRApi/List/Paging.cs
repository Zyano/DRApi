using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DrApi.Converters;

namespace DRApi.List {
    public class Paging {
        public string Title { get; set; }
        [Newtonsoft.Json.JsonConverterAttribute(typeof(UriConverter))]
        public Uri Source { get; set; }
        [Newtonsoft.Json.JsonConverterAttribute(typeof(UriConverter))]
        public Uri Next { get; set; }
        [Newtonsoft.Json.JsonConverterAttribute(typeof(UriConverter))]
        public Uri Previous { get; set; }
        public int TotalSize { get; set; }
    }
}
