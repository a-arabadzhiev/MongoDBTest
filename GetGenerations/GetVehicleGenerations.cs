
using ATConnection;
using MDBInsertDocument;
using MongoDB.Bson;
using MDBFindData;
using System.Text.Json;
using MongoDB.Bson.Serialization;
using ATToken;

namespace ATTaxonomyVehicleGenerations
{
    public class GetVehicleGenerations
    {
        public static void Main()
        {
            GetVehicleGeneration();
        }

        public static void GetVehicleGeneration()
        {
            List<BsonDocument>? vehiclemodel = MDBGetData.Find(CollectionName: GlobalVariables.Variables.GetVehicleGenerationsReq.collection, 
                                                               Filter: GlobalVariables.Variables.GetVehicleGenerationsReq.filter, 
                                                               Project: GlobalVariables.Variables.GetVehicleGenerationsReq.project);

            string? vehmod = vehiclemodel.Select(v => BsonSerializer.Deserialize<GetVehicleModel?>(v)).ToJson();

            vehmod = "{\"modelId\":" + vehmod + "}";

            GetModelID? vm = JsonSerializer.Deserialize<GetModelID?>(
                                json: vehmod,
                                options: new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
            
            DateTime? expires = DateTime.Now;
            AccessToken? token = GetToken.Token(ATTokenURL: GlobalVariables.Variables.ATTokenCred.ATTokenURL,
                                           key: GlobalVariables.Variables.ATTokenCred.key,
                                           secret: GlobalVariables.Variables.ATTokenCred.secret);

            foreach (var modelId in vm.modelId)
            {
                string? APIVehGenUrl = GlobalVariables.Variables.GetVehicleGenerationsReq.APIVehGenUrl + modelId.modelId;

                if (token.expires_at <= expires)
                {
                    expires = DateTime.Now;
                    token = GetToken.Token(ATTokenURL: GlobalVariables.Variables.ATTokenCred.ATTokenURL,
                                           key: GlobalVariables.Variables.ATTokenCred.key,
                                           secret: GlobalVariables.Variables.ATTokenCred.secret);
                }

                string? vehicleGeneration = ATConnect.ATApiData(ATApiUrl: APIVehGenUrl, Token: token.access_token);

                VehicleGenerations? vehgen = JsonSerializer.Deserialize<VehicleGenerations?>(
                    json: vehicleGeneration,
                    options: new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });

                foreach (var generationId in vehgen.generations)
                {
                    var document = new BsonDocument
                    {
                        {"generationId", generationId.generationId},
                        {"name", generationId.name}
                    };

                    MDBInsert.InsertOne("VehicleGenerations", document);
                }
            }
        }
    }
}