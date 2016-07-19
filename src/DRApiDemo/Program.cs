using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using DrApi;
using DRApi.Bar;
using DRApi.Programcard;
using DRApi.Requester;

namespace DRApiDemo {
    public class Program {
        public static void Main(string[] args) {
            Program p = new Program();
            bool run = true;
            while(run) {
                Console.WriteLine();
                Console.WriteLine("New search term");
                string s = Console.ReadLine();
                if(s == "exit") {
                    run = false;
                } else {
                    p.GetRes(s).GetAwaiter().GetResult();
                }
            }
            Console.ReadLine();
        }

        public async Task GetRes(string search) {
            DrRequester dr = new DrRequester();
            var list = await dr.SearchProgramcardsWithPublicAssetAsync(search);
            if(list != null) {
                if(list.Items != null) {
                    foreach(var el in list.Items) {
                        Console.WriteLine("Series: "+  el.SeriesTitle);
                        var listOfSeries = dr.ListAsync(el.SeriesUrn).GetAwaiter().GetResult();
                        do
                        {                            
                            var episodes = listOfSeries.Items;
                            foreach(Programcard episode in episodes) {
                                Console.WriteLine();
                                Console.WriteLine(episode.Title);
                                string uri = episode.PrimaryAsset.Uri.ToString();
                                Console.WriteLine(uri);
                                var split = uri.Split('/');
                                string barId = split[split.Length - 1];
                                BarResponse br = await dr.BarAsync(barId);
                                Console.WriteLine(br.Links.First(l => l.Target == "HLS").Uri);
                                ProcessStartInfo psi = new ProcessStartInfo(@"D:\WebSites\youtube.gim.dk\ffmpeg.exe")
                                {
                                    Arguments = $"-i {br.Links.First(l => l.Target == "HLS").Uri} -c copy -bsf:a aac_adtstoasc \"{@"D:\HTPC\TV Series\Ørnen\" + episode.Slug}.mp4\"",
                                    UseShellExecute = false,
                                };
                                Console.WriteLine(psi.FileName+ " " + psi.Arguments);
                                var p = Process.Start(psi);                                
                                p.WaitForExit();
                            }
                        } while ((listOfSeries = dr.ListAsync(el.SeriesUrn,listOfSeries.Limit,listOfSeries.Offset+listOfSeries.Limit).GetAwaiter().GetResult()).Items.Any());
                    }
                }
            }
        }
    }
}