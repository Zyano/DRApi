using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using DRApi.List;
using Newtonsoft.Json;

namespace DRApi.Helper {
    public class DownloadClient<T> where T : new() {
        public HttpClient HttpClient { get; set; }       

        public DownloadClient() {
            HttpClient=new HttpClient();
        }

        public async Task<T> DownloadAndConvert(string url) {
            string jsonResponse = "";
            using(HttpClient client = new HttpClient()) {
                try {
                    jsonResponse=await client.GetStringAsync(url);
                } catch(ArgumentException ae) {
                    Debug.WriteLine("Caught an exception during web request: " + ae.Message);
                    throw;
                }
            }
            T obj = new T();
            if(!string.IsNullOrEmpty(jsonResponse)) {
                obj = await Task.Factory.StartNew(() => JsonConvert.DeserializeObject<T>(jsonResponse));
            }

            return obj;
        }

        public async Task<string> Download(string url) {
            string jsonResponse = "";
            using(HttpClient client = new HttpClient()) {
                try {
                    jsonResponse = await client.GetStringAsync(url);
                } catch(ArgumentException ae) {
                    Debug.WriteLine("Caught an exception during web request: " + ae.Message);
                    throw;
                }
            }
            return jsonResponse;
        }
    }
}
