using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using DrApi.Converters;

namespace DRApi.Http {
    public class HttpRequestMethod {
        public Version Version { get; set; }
        public HttpContent Content { get; set; }
        public HttpMethod Method { get; set; }
        [Newtonsoft.Json.JsonConverterAttribute(typeof(UriConverter))]
        public Uri URI { get; set; }
        public ICollection<Object> Headers { get; set; }
        public IDictionary<string, object> Properties { get; set; }

    }
}
