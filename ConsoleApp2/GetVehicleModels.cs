using ATConnection;
using MDBInsertDocument;
using MongoDB.Bson;
using MDBFindData;
using System.Text.Json;
using MongoDB.Bson.Serialization;

namespace ATTaxonomyVehicleModels
{
    public class GetVehicleModels
    {
        public static async Task Main()
        {
            string? advertiserid = "66945";

            string? collection = "VehicleMakes";
            string? project = "{makeId: 1, _id: 0}";
            string? filter = "{}";

            var vehiclemake = MDBGetData.Find(collection, filter, project);                                                                              

            string? vehmake = vehiclemake.Select(v => BsonSerializer.Deserialize<GetVehicleMakes>(v)).ToJson();

            vehmake = "{\"makeId\":" + vehmake + "}";

            GetMakeID? vm = JsonSerializer.Deserialize<GetMakeID?>(
                                json: vehmake,
                                options: new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });

            foreach (var makeId in vm.makeId)
            {
                string? webext = "models?makeId=" + makeId.makeId + "&advertiserId=" + advertiserid;
                string? cookie = "__cf_bm=B6mel2RAr2Y8bJ_YC12yGM72Fz992ZOgK4NdAQIY3qQ-1718109215-1.0.1.1-UBKCntQDCf.gtz4TRb93MxGrFR.aGSkdL8P4mtAD16PxCY1ZzAzjuMOEV3gmMVnclxTq_BvbH7gTIH7Bz6k2BA";

                string? vehicleModel = await ATConnect.Connect(webext, cookie, null);

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