using ATToken;

namespace ATConnection
{
    public class ATConnect(string? webext, string? cookie, string? token)
    {
        public static async Task<string?> Connect(string? webext, string? cookie, string? token)
        {
            string? requesturl = "https://api-sandbox.autotrader.co.uk/taxonomy/" + webext;

            if (token == null)
            {
                AccessToken? tkn = await GetToken.Conn();

                var client = new HttpClient();
                var request = new HttpRequestMessage(HttpMethod.Get, requesturl);
                request.Headers.Add("Authorization", "Bearer " + tkn.access_token);
                request.Headers.Add("cpntent-type", "application/json");
                request.Headers.Add("Cookie", cookie);
                var response = await client.SendAsync(request);
                response.EnsureSuccessStatusCode();

                string? VehData = await response.Content.ReadAsStringAsync();

                return VehData;
            }
            else 
            { 
                string? tkn1 = token;

                var client = new HttpClient();
                var request = new HttpRequestMessage(HttpMethod.Get, requesturl);
                request.Headers.Add("Authorization", "Bearer " + tkn1);
                request.Headers.Add("cpntent-type", "application/json");
                request.Headers.Add("Cookie", cookie);
                var response = await client.SendAsync(request);
                response.EnsureSuccessStatusCode();

                string? VehData = await response.Content.ReadAsStringAsync();

                return VehData;
            }
        }
        public static void Main() { }
    }
}