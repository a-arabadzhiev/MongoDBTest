using ATConnection;
using MDBInsertDocument;
using MongoDB.Bson;
using System.Text.Json;

namespace ATTaxonomyVehicleTypes
{
    public class GetVehicleTypes
    {
        public static async Task Main()
        {
            string? advertiserid = "66945";
            string? webext = "vehicleTypes?advertiserId=" + advertiserid;
            string? cookie = "__cf_bm=Rucph7ECriCdynJnhNow.vQ6YTW8hhUz_aHgRq0gJiA-1728326592-1.0.1.1-ka7pDua0XBYxhLQhFZxc8f_L4Zj99inX1wnAo56YeXzQ22oFjZb9XE7nwPt2jIGHSFPFJxBdbyLzkc10K_LN2Q";

            string? vehtyp = await ATConnect.Connect(webext, cookie, null);

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