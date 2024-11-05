using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace ATTaxonomyVehicleMakes
{
    public class GetVehicleType
    {
        [BsonElement("name"), BsonRepresentation(BsonType.String)]
        public string? name { get; set; }
    }
}
