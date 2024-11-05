
using ATConnection;
using ATToken;
using MDBFindData;
using MDBInsertDocument;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using System.Text.Json;

namespace ATTaxonomyVehicleTechnicalData
{
    public class GetVehicleTechnicalData
    {
        public static async Task Main()
        {
            string? collection = "VehicleDerivatives";
            string? project = "{derivativeId: 1, _id: 0 }";
            string? filter = "{}";

            List<BsonDocument>? vehiclegeneration = MDBGetData.Find(collection, filter, project);

            string? vehder = vehiclegeneration.Select(v => BsonSerializer.Deserialize<GetVehicleDerivative?>(v)).ToJson();

            vehder = "{\"derivativeId\":" + vehder + "}";

            GetDerivativeID? vg = JsonSerializer.Deserialize<GetDerivativeID?>(
                                json: vehder,
                                options: new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });

            AccessToken? token = await GetToken.Conn();

            foreach (var derivativeId in vg.derivativeId)
            {
                string? advertiserid = "66945";

                string? webext = "derivatives/" + derivativeId.derivativeId + "?advertiserId=" + advertiserid;
                string? cookie = "__cf_bm=B6mel2RAr2Y8bJ_YC12yGM72Fz992ZOgK4NdAQIY3qQ-1718109215-1.0.1.1-UBKCntQDCf.gtz4TRb93MxGrFR.aGSkdL8P4mtAD16PxCY1ZzAzjuMOEV3gmMVnclxTq_BvbH7gTIH7Bz6k2BA";

                if (token.expires_at <= DateTime.Now.AddMinutes(2))
                {
                    token = await GetToken.Conn();
                }

                string? vehicleTechnicalData = await ATConnect.Connect(webext, cookie, token.access_token);

                var document = BsonDocument.Parse(vehicleTechnicalData);

                MDBInsert.InsertOne("VehicleTechnicalData", document);
            }
        }
    }
}