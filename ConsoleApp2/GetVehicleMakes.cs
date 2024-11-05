using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace ATTaxonomyVehicleModels
{
    public class GetVehicleMakes
    {
        [BsonElement("makeId"), BsonRepresentation(BsonType.String)]
        public string? makeId { get; set; }
    }
}
