using ATConnection;
using MDBInsertDocument;
using MongoDB.Bson;
using MDBFindData;
using System.Text.Json;

namespace ATTaxonomyVehicleMakes
{
    public class GetVehicleMakes
    {
        public class VehicleType
        {
            public string? name { get; set; }
        }
        public class VehicleMake
        {
            public List<Make>? makes { get; set; }
        }
        public class Make
        {
            public string? makeId { get; set; }
            public string? name { get; set; }
        }
        public static async Task Main()
        {
            string? advertiserid = "66945";
            string? type = "Car";

            string? collection = "VehicleTypes";
            string? project = "{ _id : 0, " + "name: 1 }";
            string? filter = "{name: \"" + type + "\" }";

            string? vehicletype = MDBGetData.Find(collection, filter, project).ToString().Replace("[", "").Replace("]", "");

            VehicleType? vehtyp = JsonSerializer.Deserialize<VehicleType?>(
                json: vehicletype,
                options: new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });

            string? webext = "makes?vehicleType=" + vehtyp.name + "&advertiserId=" + advertiserid;
            string? cookie = "__cf_bm=B6mel2RAr2Y8bJ_YC12yGM72Fz992ZOgK4NdAQIY3qQ-1718109215-1.0.1.1-UBKCntQDCf.gtz4TRb93MxGrFR.aGSkdL8P4mtAD16PxCY1ZzAzjuMOEV3gmMVnclxTq_BvbH7gTIH7Bz6k2BA";

            string? vehicleMake = await ATConnect.Connect(webext, cookie);

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