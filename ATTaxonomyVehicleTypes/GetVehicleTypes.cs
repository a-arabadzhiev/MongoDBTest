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
            string? cookie = "__cf_bm=Rucph7ECriCdynJnhNow.vQ6YTW8hhUz_aHgRq0gJiA-1728326592-1.0.1.1-ka7pDua0XBYxhLQhFZxc8f_L4Zj99inX1wnAo56YeXzQ22oFjZb9XE7nwPt2jIGHSFPFJxBdbyLzkc10K_LN2Q";

            string? collection = "VehicleTypes";

            string? vehtyp = new ATConnect(webext, cookie).ToString();

            var MDBCollection = new MDBConn(collection, vehtyp);

            var document = BsonDocument.Parse(vehtyp);

            MDBCollection.InsertOne(document);
        }
    }
}