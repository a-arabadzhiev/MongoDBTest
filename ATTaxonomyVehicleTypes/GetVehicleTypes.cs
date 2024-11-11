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
            GetVehicleType(WebSite: GlobalVariables.Variables.GetVehicleTypesReq.WebSiteType);
        }

        public static async void GetVehicleType(string? WebSite)
        {
            Console.WriteLine(WebSite);
            Console.ReadLine();

            //AccessToken? ATToken = await GetToken.Conn(website: GlobalVariables.Variables.ATTokenCred.website,
            //                                           key: GlobalVariables.Variables.ATTokenCred.key,
            //                                           secret: GlobalVariables.Variables.ATTokenCred.secret);

            //Console.WriteLine(ATToken.access_token);
            //Console.ReadLine();

            string? vehtyp = await ATConnection.ATConnect.Connect(WebSite: WebSite, Token: ATToken.access_token);

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
    }
}