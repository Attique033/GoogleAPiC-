using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json.Linq;

namespace apidemo
{
    class Program
    {
        String response, result;
        String apiKey="Your_API_KEY;
        static void Main(string[] args)
        {
            getdata("HD1 4DN");
            Console.ReadLine();
        }
        static async public  void getdata(String code)
        {
            using (var client = new HttpClient())
            {
                var response = await client.GetStringAsync(String.Format("https://maps.googleapis.com/maps/api/place/findplacefromtext/json?input={0}&inputtype=textquery&&fields=photos,formatted_address,name,opening_hours,rating&key=AIzaSyA9aqOhINn43CeS1jgNmgYFd-gDlCPRj8c", code));
                Console.Write(response);
            }
        }

        static void getplacedetails(String response)
        {
            JObject objectContainer = response.Value<JObject>("candidates");
            foreach (KeyValuePair<string, JToken> tag in objectContainer)
            {
                if(tag.key=="formatted_address")
                    Console.Write("Address: "+tag.Value);
                if(tag.key=="name")
                    Console.Write("Place name"+tag.Value);
            }   
        }
    }
}
