using System.Text.Json;

namespace ATToken
{
    public class GetToken
    {
        public string? access_token;
        public static async Task<AccessToken?> Conn()
        {
            //Variables //AutoTrader Sandbox
            string? key = "eDynamix-StockMGT-Parkway-SB-05-09-24";
            string? secret = "JUwLAeG8zzlnJE2jyKizp0mzeEcBD65Q";
            string? website = "https://api-sandbox.autotrader.co.uk/authenticate";
            string? cookie = "__cf_bm=x8woAz68itsh7F0jtAb4HW13pX5WwxNxX8kUjOnD2zc-1728975303-1.0.1.1-YCMyEGbqoXvoowdekqeIIcg5LaeL4xNoH7SceJvKAQ8DF8wSO29G5pOTGJ9.TXzJjPmrhHk8.vze5uQT2qDHTQ";

            //Get Token //Auto Trader Sandbox token
            var ATclient = new HttpClient();
            var ATrequest = new HttpRequestMessage(HttpMethod.Post, website);
            ATrequest.Headers.Add("Cookie", cookie);
            var collection = new List<KeyValuePair<string, string>>
            {
                new("key", key),
                new("secret", secret)
            };
            var content = new FormUrlEncodedContent(collection);
            ATrequest.Content = content;
            var ATresponse = await ATclient.SendAsync(ATrequest);
            ATresponse.EnsureSuccessStatusCode();

            string? AccessTokenRes = await ATresponse.Content.ReadAsStringAsync();
            AccessToken? accesstoken = JsonSerializer.Deserialize<AccessToken?>(AccessTokenRes);

            return accesstoken;
        }
        public static void Main() { }
    }
}