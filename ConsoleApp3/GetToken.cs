
using System.Text.Json;

namespace ATToken
{
    public class GetToken
    {
        public class AccessToken
        {
            public string? access_token { get; set; }
            public DateTime? expires_at { get; set; }
        }

        public static async Task<AccessToken?> Main()
        {
            var key = "eDynamix-StockMGT-Parkway-SB-05-09-24";
            var secret = "JUwLAeG8zzlnJE2jyKizp0mzeEcBD65Q";

            //Get Auto Trader Sandbox token
            var ATclient = new HttpClient();
            var ATrequest = new HttpRequestMessage(HttpMethod.Post, "https://api-sandbox.autotrader.co.uk/authenticate");
            ATrequest.Headers.Add("Cookie", "__cf_bm=ib4fWOcQI.p0UonnDcf.YP7U6plrQs2VcxbjSBmUdT4-1718029262-1.0.1.1-SKsHzyviga_1FAwZjDxtUNz3qhex6_tCZh06hQrhqkbtdCSuaaz7PfpSVk34TAQapXxSeKMuWFrAgxcQ7GeQsA");
            var collection = new List<KeyValuePair<string, string>>();
            collection.Add(new("key", key));
            collection.Add(new("secret", secret));
            var content = new FormUrlEncodedContent(collection);
            ATrequest.Content = content;
            var ATresponse = await ATclient.SendAsync(ATrequest);
            ATresponse.EnsureSuccessStatusCode();

            string AccessTokenRes = await ATresponse.Content.ReadAsStringAsync();
            AccessToken? accesstoken = JsonSerializer.Deserialize<AccessToken>(AccessTokenRes);

            return accesstoken;
        }
    }
}