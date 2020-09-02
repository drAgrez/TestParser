using AngleSharp.Xml.Parser;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using System.Net.Http;

namespace TestParser
{
    class Program
    {
        static async System.Threading.Tasks.Task Main(string[] args)
        {
            using var client = new HttpClient();
            var result = await client.GetStringAsync("https://yastatic.net/market-export/_/partner/help/YML.xml");

            var parser = new XmlParser();
            var offerID = parser
                .ParseDocument(result)
                .QuerySelectorAll("offer[id]");

            using (StreamWriter sw = new StreamWriter("offerID.txt"))
            {
                foreach(var item in offerID)
                {
                    sw.WriteLine(item.GetAttribute("id"));
                }
            }
        }
    }
}
