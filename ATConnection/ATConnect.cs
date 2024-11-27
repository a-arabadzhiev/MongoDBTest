
using ATToken;

namespace ATConnection
{
    public class ATConnect(string? ATApiUrl, string? Token)
    {
        public class VehicleTypes
        {
            public List<Types>? vehicleTypes { get; set; }
        }

        public class Types
        {
            public string? name { get; set; }
        }
        public static string? ATApiData(string? ATApiUrl, string? Token)
        {
            try
            {
                var client = new HttpClient();
                var request = new HttpRequestMessage(HttpMethod.Get, ATApiUrl);
                request.Headers.Add("Authorization", "Bearer " + Token);
                request.Headers.Add("cpntent-type", "application/json");
                request.Headers.Add("Cookie", "__cf_bm=ASn2f57BcwPZTa7Xou6ebNAST3K8p2O2ZjeBfYxpsvk-1731578777-1.0.1.1-CJ6ha8lTpfDzvrsFVX264Qc5qiP2RfUQDpIzZvt6WAw15bBMWBP.X2hB5lpL.ZXiyxz8v4WG4YZclF84AU.x4g");
                var response = client.Send(request);
                response.EnsureSuccessStatusCode();

                var VehData = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();

                return VehData.ToString();
            }
            catch(Exception ex) 
            { 
                Console.WriteLine(ex.Message);
            }

            return null;
        }
        public static void Main()
        {
            //AccessToken? ATToken = GetToken.Token(ATTokenURL: GlobalVariables.Variables.ATTokenCred.ATTokenURL,
            //                                      key: GlobalVariables.Variables.ATTokenCred.key,
            //                                      secret: GlobalVariables.Variables.ATTokenCred.secret);
 
            //ATApiData(GlobalVariables.Variables.GetVehicleTypesReq.ATVehTypURL, ATToken.access_token);
        }
    }
}