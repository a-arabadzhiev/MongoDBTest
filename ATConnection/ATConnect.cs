using ATToken;

namespace ATConnection
{
    public class ATConnect(string? WebSite, string? Token)
    {
        public static async Task<string?> Connect(string? WebSite, string? Token)
        {
            if (Token == null)
            {
                AccessToken? ATToken = await GetToken.Conn(website: GlobalVariables.Variables.ATTokenCred.website,
                                                           key: GlobalVariables.Variables.ATTokenCred.key,
                                                           secret: GlobalVariables.Variables.ATTokenCred.secret);

                var client = new HttpClient();
                var request = new HttpRequestMessage(HttpMethod.Get, WebSite);
                request.Headers.Add("Authorization", "Bearer " + ATToken.access_token);
                request.Headers.Add("cpntent-type", "application/json");
                request.Headers.Add("Cookie", GlobalVariables.Variables.ATTaxonomyReq.cookie);
                var response = await client.SendAsync(request);
                response.EnsureSuccessStatusCode();

                string? VehData = await response.Content.ReadAsStringAsync();

                return VehData;
            }
            else
            {
                string? ATToken = Token;

                var client = new HttpClient();
                var request = new HttpRequestMessage(HttpMethod.Get, WebSite);
                request.Headers.Add("Authorization", "Bearer " + ATToken);
                request.Headers.Add("cpntent-type", "application/json");
                request.Headers.Add("Cookie", GlobalVariables.Variables.ATTaxonomyReq.cookie);
                var response = await client.SendAsync(request);
                response.EnsureSuccessStatusCode();

                string? VehData = await response.Content.ReadAsStringAsync();

                return VehData;
            }
        }
        public static async Task Main()
        {
            //AccessToken? ATToken = await GetToken.Conn(website: GlobalVariables.Variables.ATTokenCred.website, 
                                                   //key: GlobalVariables.Variables.ATTokenCred.key, 
                                                   //secret: GlobalVariables.Variables.ATTokenCred.secret);

            //await ATConnect.Connect(WebSite: "https://api-sandbox.autotrader.co.uk/taxonomy/vehicleTypes?advertiserId=66945",
            //                        Token: ATToken.access_token);
        }
    }
}