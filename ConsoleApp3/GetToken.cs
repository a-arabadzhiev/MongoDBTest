using System.Text.Json;

namespace ATToken
{
    public class GetToken
    {
        //public string? access_token;
        public static async Task<AccessToken?> Conn(string? website, string? key, string? secret)
        {
            Console.WriteLine(website + "\n" + key + "\n"+ secret + "\n");
            Console.ReadLine();

            //Get Token //Auto Trader Sandbox token
            var ATclient = new HttpClient();
            var ATrequest = new HttpRequestMessage(HttpMethod.Post, "https://api-sandbox.autotrader.co.uk/authenticate");
                ATrequest.Headers.Add("Cookie", "__cf_bm=5W2rudDPaI0qejVjtFPlctGFc3fsJehaHGXigl8Tdgo-1731061275-1.0.1.1-zriKztazmXluJf2SJdphY5KuIuWbyASfBr7a7LRR_pjuYEy3luqmbuEyTC6MdsSj5z_HZb341Bq6FJSGJI56UQ");
            var collection = new List<KeyValuePair<string, string>>();
                collection.Add(new("key", "eDynamix-StockMGT-Parkway-SB-05-09-24"));
                collection.Add(new("secret", "JUwLAeG8zzlnJE2jyKizp0mzeEcBD65Q"));
            var content = new FormUrlEncodedContent(collection);
                ATrequest.Content = content;

            Console.WriteLine(ATrequest);            
            Console.ReadLine();

            Console.WriteLine(await ATclient.SendAsync(ATrequest));
            Console.ReadLine();

            var ATresponse = await ATclient.SendAsync(ATrequest);

            Console.WriteLine(ATresponse);
            Console.ReadLine();

            ATresponse.EnsureSuccessStatusCode();

            Console.WriteLine(await ATresponse.Content.ReadAsStringAsync());
            Console.ReadLine();

            string? AccessTokenRes = await ATresponse.Content.ReadAsStringAsync();
            AccessToken? accesstoken = JsonSerializer.Deserialize<AccessToken?>(AccessTokenRes);

            Console.WriteLine(accesstoken.access_token);
            Console.ReadLine();

            return accesstoken;
        }
        public static async Task Main() 
        { 
            await Conn(website: GlobalVariables.Variables.ATTokenCred.website, 
                       key: GlobalVariables.Variables.ATTokenCred.key, 
                       secret: GlobalVariables.Variables.ATTokenCred.secret);
        }
    }
}