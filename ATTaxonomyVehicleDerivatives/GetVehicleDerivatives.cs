
using ATConnection;
using ATToken;
using MDBFindData;
using MDBInsertDocument;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using System.Text.Json;

namespace ATTaxonomyVehicleDerivatives
{
    public class GetVehicleGenerations
    {
        public static async Task Main()
        {
            string? collection = "VehicleGenerations";
            string? project = "{generationId: 1, _id: 0 }";
            string? filter = "{}";

            List<BsonDocument>? vehiclegeneration = MDBGetData.Find(collection, filter, project);

            string? vehgen = vehiclegeneration.Select(v => BsonSerializer.Deserialize<GetVehicleGeneration?>(v)).ToJson();

            vehgen = "{\"generationId\":" + vehgen + "}";

            GetGenerationID? vg = JsonSerializer.Deserialize<GetGenerationID?>(
                                json: vehgen,
                                options: new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });

            AccessToken? token = await GetToken.Conn();

            foreach (var generationId in vg.generationId)
            {
                string? webext = "derivatives?generationId=" + generationId.generationId;
                string? cookie = "__cf_bm=B6mel2RAr2Y8bJ_YC12yGM72Fz992ZOgK4NdAQIY3qQ-1718109215-1.0.1.1-UBKCntQDCf.gtz4TRb93MxGrFR.aGSkdL8P4mtAD16PxCY1ZzAzjuMOEV3gmMVnclxTq_BvbH7gTIH7Bz6k2BA";

                if (token.expires_at <= DateTime.Now.AddMinutes(2))
                {
                    token = await GetToken.Conn();
                }

                string? vehicleDerivatives = await ATConnect.Connect(webext, cookie, token.access_token);

                VehicleDerivative? vehder = JsonSerializer.Deserialize<VehicleDerivative?>(
                    json: vehicleDerivatives,
                    options: new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });

                foreach (var derivativeId in vehder.derivatives)
                {
                    var document = new BsonDocument
                    {
                        {"derivativeId", derivativeId.derivativeId},
                        {"name", derivativeId.name},
                        {"introduced", derivativeId.introduced},
                        {"discontinued", derivativeId.discontinued}
                    };

                    MDBInsert.InsertOne("VehicleDerivatives", document);
                }
            }
        }
    }
}