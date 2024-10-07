using ATConn;
using MDBConnection;
using MongoDB.Bson;

namespace ATTaxonomyVehicleTypes
{
    public class GetVehicleTypes
    {
        public static void Main()
        {
            string? webext = "vehicleTypes?advertiserId=66945";
            string? cookie = "__cf_bm=ib4fWOcQI.p0UonnDcf.YP7U6plrQs2VcxbjSBmUdT4-1718029262-1.0.1.1-SKsHzyviga_1FAwZjDxtUNz3qhex6_tCZh06hQrhqkbtdCSuaaz7PfpSVk34TAQapXxSeKMuWFrAgxcQ7GeQsA";

            string? collection = "VehicleTypes";

            string? vehtyp = new ATConnect(webext, cookie).ToString();

            var MDBCollection = new MDBConn(collection, vehtyp);

            var document = BsonDocument.Parse(vehtyp);

            MDBCollection.InsertOne(document);
        }
    }
}