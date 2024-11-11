using ATConnection;
using MDBInsertDocument;
using MongoDB.Bson;
using MDBFindData;
using System.Text.Json;
using MongoDB.Bson.Serialization;

namespace ATTaxonomyVehicleMakes
{
    public class GetVehicleMakes
    {
        public static async Task Main()
        {
            string? advertiserid = "66945";
            string? type = "Car";

            string? collection = "VehicleTypes";
            string? project = "{ _id : 0 }";
            string? filter = "{name: \"" + type + "\" }";

            var vehicletype = MDBGetData.Find(collection, filter, project);

            string? vehtyp = vehicletype.Select(v => BsonSerializer.Deserialize<GetVehicleType>(v)).ToJson()
                                                                                                   .Replace("[", "")
                                                                                                   .Replace("]", "");

            VehicleType? vt = JsonSerializer.Deserialize<VehicleType?>(
                                json: vehtyp,
                                options: new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });

            string? webext = "makes?vehicleType=" + vt.name + "&advertiserId=" + advertiserid;
            string? cookie = "__cf_bm=B6mel2RAr2Y8bJ_YC12yGM72Fz992ZOgK4NdAQIY3qQ-1718109215-1.0.1.1-UBKCntQDCf.gtz4TRb93MxGrFR.aGSkdL8P4mtAD16PxCY1ZzAzjuMOEV3gmMVnclxTq_BvbH7gTIH7Bz6k2BA";

            string? vehicleMake = await ATConnect.Connect(WebSite: webext, Token: null);

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