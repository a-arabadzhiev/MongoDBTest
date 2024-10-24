using ATToken;

namespace ATConnection
{
    public class ATConnect(string? webext, string? cookie)
    {
        public static async Task<string?> Connect(string? webext, string? cookie)
        {
            string? requesturl = "https://api-sandbox.autotrader.co.uk/taxonomy/" + webext;

            AccessToken? token = await GetToken.Conn();

            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Get, requesturl);
                request.Headers.Add("Authorization", "Bearer " + token.access_token);
                request.Headers.Add("cpntent-type", "application/json");
                request.Headers.Add("Cookie", cookie);
            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();

            string? VehData = await response.Content.ReadAsStringAsync();

            return VehData;
        }
        public static void Main() { }
    }
}