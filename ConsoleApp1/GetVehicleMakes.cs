
using ATConn;
using MDBConnection;
using MongoDB.Bson;

namespace ATTaxonomyVehicleMakes
{
    public class GetVehicleMakes
    {
        public static void Main()
        {
            string? vehtype = "Car";

            string? webext = "makes?vehicleType=" + vehtype + "&advertiserId=66945";

            string? cookie = "__cf_bm=B6mel2RAr2Y8bJ_YC12yGM72Fz992ZOgK4NdAQIY3qQ-1718109215-1.0.1.1-UBKCntQDCf.gtz4TRb93MxGrFR.aGSkdL8P4mtAD16PxCY1ZzAzjuMOEV3gmMVnclxTq_BvbH7gTIH7Bz6k2BA";

            string? vehicleMake = new ATConnect(webext, cookie).ToString();

            string? collection = "VehicleMakes";

            //VehicleMakes? vehmke = JsonSerializer.Deserialize<VehicleMakes>(
            //    json: vehicleMake ,
            //    options: new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });

            var MDBCollection = new MDBConn(collection, vehicleMake);

            //foreach (var Make in vehmke.makes)
            //{

            var document = BsonDocument.Parse(vehicleMake);

            MDBCollection.InsertOne(document);

            //}
        }
    }
}