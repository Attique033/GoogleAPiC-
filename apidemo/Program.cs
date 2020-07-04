using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;

namespace apidemo
{
    class Program
    {
        String response, result;
        static const String apiKey="Your_API_KEY";
        static void Main(string[] args)
        {
            getdata("HD1 4DN");
            Console.ReadLine();
        }
        static async public  void getdata(String code)
        {
            using (var client = new HttpClient())
            {
                var response = await client.GetStringAsync(String.Format("https://maps.googleapis.com/maps/api/place/findplacefromtext/json?input={0}&inputtype=textquery&&fields=photos,formatted_address,name,opening_hours,rating&key={1}", code,apiKey));
                Console.Write(response);

            }
        }
    }
}
