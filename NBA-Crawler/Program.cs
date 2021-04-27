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

            string url = "https://www.basketball-reference.com/players/";
            string initial = "a/";
            string newurl = url + initial;

            var responseMessage = await httpClient.GetAsync(newurl); //發送請求

            //檢查回應的伺服器狀態StatusCode是否是200 OK
            if (responseMessage.StatusCode == System.Net.HttpStatusCode.OK)
            {
                // .Result return string without Task
                string response = responseMessage.Content.ReadAsStringAsync().Result;//取得內容

                Console.WriteLine(response);

                // 使用AngleSharp時的前置設定
                var config = Configuration.Default;
                var context = BrowsingContext.New(config);

                //將我們用httpclient拿到的資料放入res.Content中())
                var document = await context.OpenAsync(res => res.Content(response));

                //QuerySelector("head")找出<head></head>元素
                //var head = document.QuerySelector("#players > tbody");
                //Console.WriteLine(head.ToHtml());

                //QuerySelector(".entry-content")找出class="entry-content"的所有元素
                //var matches = document.QuerySelectorAll("#players > tbody > tr")

                //foreach (var c in matches)
                //{
                //    //取得每個元素的TextContent
                //    var test = c.QuerySelector("a").GetAttribute("href");
                //    Console.WriteLine(test);
                //}
                var matches = document.QuerySelectorAll("#players > tbody > tr").Select(m => m.QuerySelector("a").GetAttribute("href"));

            }

            Console.ReadKey();
        }
    }
}
