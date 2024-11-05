
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
        public static async Task Main()
        {
            string? collection = "VehicleModels";
            string? project = "{modelId: 1, _id: 0 }";
            string? filter = "{}";

            List<BsonDocument>? vehiclemodel = MDBGetData.Find(collection, filter, project);

            string? vehmod = vehiclemodel.Select(v => BsonSerializer.Deserialize<GetVehicleModel?>(v)).ToJson();

            vehmod = "{\"modelId\":" + vehmod + "}";

            GetModelID? vm = JsonSerializer.Deserialize<GetModelID?>(
                                json: vehmod,
                                options: new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
            
            DateTime? expires = DateTime.Now;
            AccessToken? token = await GetToken.Conn();

            foreach (var modelId in vm.modelId)
            {
                string? webext = "generations?modelId=" + modelId.modelId;
                string? cookie = "__cf_bm=B6mel2RAr2Y8bJ_YC12yGM72Fz992ZOgK4NdAQIY3qQ-1718109215-1.0.1.1-UBKCntQDCf.gtz4TRb93MxGrFR.aGSkdL8P4mtAD16PxCY1ZzAzjuMOEV3gmMVnclxTq_BvbH7gTIH7Bz6k2BA";

                if (token.expires_at <= expires)
                {
                    expires = DateTime.Now;
                    token = await GetToken.Conn();                    
                }

                string? vehicleGeneration = await ATConnect.Connect(webext, cookie, token.access_token);

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