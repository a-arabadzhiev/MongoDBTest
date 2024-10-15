using ATToken;

namespace ATConn
{
    public class ATConnect(string? websitext, string? cookie)
    {
        public static async Task<string?> Connect(string? websitext, string? cookie)
        {
            string? website = "https://api-sandbox.autotrader.co.uk/taxonomy/";

            var token = new GetToken();
            //string? accesstoken = token.access_token;

            //var requestUrl = website + websitext;
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Get, website + websitext);
                request.Headers.Add("Authorization", "Bearer " + token.access_token);
                request.Headers.Add("cpntent-type", "application/json");
                request.Headers.Add("Cookie", cookie);
            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();

            string? VehData = await response.Content.ReadAsStringAsync();

            return VehData;
        }
    }
}
