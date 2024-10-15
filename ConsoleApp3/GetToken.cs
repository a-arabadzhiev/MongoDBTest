using System.Text.Json;

namespace ATToken
{
    public class GetToken
    {
        public string? access_token;
        public static async Task<AccessToken?> Main()
        {
            //Variables //AutoTrader Sandbox
            string? key = "eDynamix-StockMGT-Parkway-SB-05-09-24";
            string? secret = "JUwLAeG8zzlnJE2jyKizp0mzeEcBD65Q";
            string? website = "https://api-sandbox.autotrader.co.uk/authenticate";
            string? cookie = "__cf_bm=Rucph7ECriCdynJnhNow.vQ6YTW8hhUz_aHgRq0gJiA-1728326592-1.0.1.1-ka7pDua0XBYxhLQhFZxc8f_L4Zj99inX1wnAo56YeXzQ22oFjZb9XE7nwPt2jIGHSFPFJxBdbyLzkc10K_LN2Q";

            //Get Token //Auto Trader Sandbox token
            var ATclient = new HttpClient();
            var ATrequest = new HttpRequestMessage(HttpMethod.Post, website);
            ATrequest.Headers.Add("Cookie", cookie);
            var collection = new List<KeyValuePair<string, string>>();
            collection.Add(new("key", key));
            collection.Add(new("secret", secret));
            var content = new FormUrlEncodedContent(collection);
            ATrequest.Content = content;
            var ATresponse = await ATclient.SendAsync(ATrequest);
            ATresponse.EnsureSuccessStatusCode();

            string AccessTokenRes = await ATresponse.Content.ReadAsStringAsync();
            AccessToken? accesstoken = JsonSerializer.Deserialize<AccessToken?>(AccessTokenRes);

            return accesstoken;
        }
    }
}