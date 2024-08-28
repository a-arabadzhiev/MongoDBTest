using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ATTaxonomyVehicleTypes
{
    public class BSON
    {
        [BsonId, BsonElement("_id"), BsonRepresentation(BsonType.ObjectId)]
        public string ID { get; set; }

        [BsonElement("access_token"), BsonRepresentation(BsonType.String)]
        public string acces_token { get; set; }

        [BsonElement("expires"), BsonRepresentation(BsonType.DateTime)]
        public DateTime expires { get; set; }

    }

}