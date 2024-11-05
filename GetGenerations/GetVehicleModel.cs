
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ATTaxonomyVehicleGenerations
{
    public class GetVehicleModel
    {
        [BsonElement("modelId"), BsonRepresentation(BsonType.String)]
        public string? modelId { get; set; }
    }
}
