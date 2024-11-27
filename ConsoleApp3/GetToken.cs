
using System.Text.Json;

namespace ATToken
{
    public class GetToken
    {
        public static AccessToken? Token(string? ATTokenURL, string? key, string? secret)
        {
            try
            {
                //Get Token //Auto Trader Sandbox token
                var ATclient = new HttpClient();
                var ATrequest = new HttpRequestMessage(HttpMethod.Post, ATTokenURL);
                ATrequest.Headers.Add("Cookie", "__cf_bm=5W2rudDPaI0qejVjtFPlctGFc3fsJehaHGXigl8Tdgo-1731061275-1.0.1.1-zriKztazmXluJf2SJdphY5KuIuWbyASfBr7a7LRR_pjuYEy3luqmbuEyTC6MdsSj5z_HZb341Bq6FJSGJI56UQ");
                var collection = new List<KeyValuePair<string, string>>();
                    collection.Add(new("key", key));
                    collection.Add(new("secret", secret));
                var content = new FormUrlEncodedContent(collection);
                    ATrequest.Content = content;
                var ATresponse = ATclient.Send(ATrequest);
                    ATresponse.EnsureSuccessStatusCode();

                var AccessTokenRes = ATresponse.Content.ReadAsStream();
                AccessToken? accesstoken = JsonSerializer.Deserialize<AccessToken?>(AccessTokenRes);

                return accesstoken;
            }
            catch (Exception ex) 
            {
                Console.WriteLine(ex.Message);            
            }

            return null;
        }
        public static void Main() 
        {
            Token(ATTokenURL: GlobalVariables.Variables.ATTokenCred.ATTokenURL,
                  key: GlobalVariables.Variables.ATTokenCred.key, 
                  secret: GlobalVariables.Variables.ATTokenCred.secret);
        }
    }
}