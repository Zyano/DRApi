using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using DrApi;
using DRApi.Bar;
using DRApi.Requester;

namespace DRApiDemo {
  public class Program {
    public static void Main(string[] args) {
      Program p=new Program();
      bool run=true;
      while(run) {
        Console.WriteLine();
        Console.WriteLine("New search term");
        string s=Console.ReadLine();
        if(s == "exit") {
          run=false;
        } else {
          p.GetRes(s).GetAwaiter().GetResult();
        }
      }
      Console.ReadLine();
    }

    public async Task GetRes(string search) {
      DrRequester dr=new DrRequester();
      var list=await dr.ListQuickSearchAsync(search);
      if(list != null) {
        if(list.Programs != null) {
          foreach(var el in list.Programs) {
            Console.WriteLine(el.SeriesTitle+" - "+el.ProgramcardTitle);
            var pcard=dr.GetProgramcard(el.ProgramcardSlug).Result;
            string uri=pcard.PrimaryAsset.Uri;
            Console.WriteLine(uri);
            var split=uri.Split('/');
            string barId=split[split.Length-1];
            BarResponse br=await dr.BarAsync(barId);
            Console.WriteLine(br.Links.First(l => l.Target == "HLS").Uri);
            Console.WriteLine(pcard.Hostname);
          }
        }
      }
    }
  }
}