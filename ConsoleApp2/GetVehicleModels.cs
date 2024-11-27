using ATConnection;
using MDBInsertDocument;
using MongoDB.Bson;
using MDBFindData;
using System.Text.Json;
using MongoDB.Bson.Serialization;
using ATToken;

namespace ATTaxonomyVehicleModels
{
    public class GetVehicleModels
    {
        public static void Main()
        {
            GetVehicleModel();
        }

        public static void GetVehicleModel()
        {
            var vehiclemake = MDBGetData.Find(CollectionName: GlobalVariables.Variables.GetVehicleModelsReq.collection, 
                                              Filter: GlobalVariables.Variables.GetVehicleModelsReq.filter, 
                                              Project: GlobalVariables.Variables.GetVehicleModelsReq.project);                                                                              

            string? vehmake = vehiclemake.Select(v => BsonSerializer.Deserialize<GetVehicleMakes>(v)).ToJson();

            vehmake = "{\"makeId\":" + vehmake + "}";

            GetMakeID? vm = JsonSerializer.Deserialize<GetMakeID?>(
                                json: vehmake,
                                options: new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });

            foreach (var makeId in vm.makeId)
            {
                string? APIVehModelUrl = GlobalVariables.Variables.GetVehicleModelsReq.APIVehModelUrl1 +
                                         makeId.makeId +
                                         GlobalVariables.Variables.GetVehicleModelsReq.APIVehModelUrl2;

                AccessToken? ATToken = GetToken.Token(ATTokenURL: GlobalVariables.Variables.ATTokenCred.ATTokenURL,
                                                      key: GlobalVariables.Variables.ATTokenCred.key,
                                                      secret: GlobalVariables.Variables.ATTokenCred.secret);

                string? vehicleModel = ATConnect.ATApiData(ATApiUrl: APIVehModelUrl, Token: ATToken.access_token);

                VehicleModels? vehmod = JsonSerializer.Deserialize<VehicleModels?>(
                    json: vehicleModel,
                    options: new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });

                foreach(var modelId in vehmod.models)
                {
                    var document = new BsonDocument
                    {
                        {"modelId", modelId.modelId},
                        {"name", modelId.name}
                    };

                    MDBInsert.InsertOne("VehicleModels", document);
                }
            }
        }
    }
}