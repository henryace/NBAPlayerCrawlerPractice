using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using AngleSharp;

namespace NBA_Crawler
{
    class Program
    {

        static async Task Main(string[] args)
        {
            HttpClient httpClient = new HttpClient();

            string homeUrl = "https://www.basketball-reference.com";
            string url = homeUrl + "/players/";
            string initial = "a/";
            string newurl = url + initial;

            // 使用AngleSharp時的前置設定
            var config = Configuration.Default;
            var context = BrowsingContext.New(config);

            var responseMessage = await httpClient.GetAsync(newurl); //發送請求

            //檢查回應的伺服器狀態StatusCode是否是200 OK
            if (responseMessage.StatusCode == System.Net.HttpStatusCode.OK)
            {
                string response = responseMessage.Content.ReadAsStringAsync().Result;//取得內容

                var document = await context.OpenAsync(res => res.Content(response));
                var matches = document.QuerySelectorAll("#players > tbody > tr").Select(m => m.QuerySelector("a").GetAttribute("href")).ToList();


                var responseMessage2 = await httpClient.GetAsync(homeUrl + "/" + matches[0]); //發送請求

                //檢查回應的伺服器狀態StatusCode是否是200 OK
                if (responseMessage2.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    string response2 = responseMessage2.Content.ReadAsStringAsync().Result;//取得內容

                    var document2 = await context.OpenAsync(res => res.Content(response2));

                    var name = document2.DocumentElement.OuterHtml;

                    var matches3 = document2.QuerySelectorAll("#info > div.stats_pullout");
                    //var matches4 = matches3.QuerySelectorAll("h4");


                    //var matches3 = document.QuerySelectorAll("#info > div.stats_pullout").Select(m => m.QuerySelector("h4")).ToList();
                    Console.WriteLine("test");
                }

            }


            

            Console.ReadKey();
        }
    }
}
