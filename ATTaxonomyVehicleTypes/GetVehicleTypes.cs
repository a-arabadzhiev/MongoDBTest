using ATToken;
using MDBInsertDocument;
using MongoDB.Bson;
using System.Text.Json;

namespace ATTaxonomyVehicleTypes
{
    public class GetVehicleTypes
    {
        public static void Main()
        {
            GetVehicleType(ATVehTypURL: GlobalVariables.Variables.GetVehicleTypesReq.ATVehTypURL);
        }

        public static void GetVehicleType(string? ATVehTypURL)
        {
            try
            {
                AccessToken? ATToken = GetToken.Token(ATTokenURL: GlobalVariables.Variables.ATTokenCred.ATTokenURL,
                                                      key: GlobalVariables.Variables.ATTokenCred.key,
                                                      secret: GlobalVariables.Variables.ATTokenCred.secret);

                string? vehtyp = ATConnection.ATConnect.ATApiData(ATApiUrl: ATVehTypURL, Token: ATToken.access_token);

                Console.WriteLine(vehtyp);
                Console.ReadLine();

                VehicleTypes? vehicletype = JsonSerializer.Deserialize<VehicleTypes?>(
                    json: vehtyp,
                    options: new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });

                foreach (var name in vehicletype.vehicleTypes)
                {
                    var document = new BsonDocument
                    {
                        {"name", name.name}
                    };

                    MDBInsert.InsertOne("VehicleTypes", document);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}