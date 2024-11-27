using ATConnection;
using MDBInsertDocument;
using MongoDB.Bson;
using MDBFindData;
using System.Text.Json;
using MongoDB.Bson.Serialization;
using ATToken;

namespace ATTaxonomyVehicleMakes
{
    public class GetVehicleMakes
    {
        public static void Main() 
        {
            GetVehicleMake();
        }

        public static void GetVehicleMake()
        {
            var vehicletype = MDBGetData.Find(CollectionName: GlobalVariables.Variables.GetVehicleMakesReq.collection, 
                                              Filter: GlobalVariables.Variables.GetVehicleMakesReq.filter, 
                                              Project: GlobalVariables.Variables.GetVehicleMakesReq.project);

            string? vehtyp = vehicletype.Select(v => BsonSerializer.Deserialize<GetVehicleType>(v)).ToJson()
                                                                                                   .Replace("[", "")
                                                                                                   .Replace("]", "");

            VehicleType? vt = JsonSerializer.Deserialize<VehicleType?>(
                                json: vehtyp,
                                options: new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });

            string? APIVehMakeUrl = GlobalVariables.Variables.GetVehicleMakesReq.ATVehMakeURL1 + 
                             vt.name + 
                             GlobalVariables.Variables.GetVehicleMakesReq.ATVehMakeURL2;

            AccessToken? ATToken = GetToken.Token(ATTokenURL: GlobalVariables.Variables.ATTokenCred.ATTokenURL,
                                                      key: GlobalVariables.Variables.ATTokenCred.key,
                                                      secret: GlobalVariables.Variables.ATTokenCred.secret);

            string? vehicleMake = ATConnect.ATApiData(ATApiUrl: APIVehMakeUrl, Token: ATToken.access_token);

            VehicleMake? vehiclemakes = JsonSerializer.Deserialize<VehicleMake?>(
                json: vehicleMake,
                options: new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });

            foreach (var make in vehiclemakes.makes)
            {
                var document = new BsonDocument
                {
                    {"makeId", make.makeId},
                    {"name", make.name}
                };

                MDBInsert.InsertOne("VehicleMakes", document);
            }
        }
    }
}