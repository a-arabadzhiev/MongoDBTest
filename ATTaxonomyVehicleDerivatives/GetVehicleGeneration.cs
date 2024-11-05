using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace ATTaxonomyVehicleDerivatives
{
    public class GetVehicleGeneration
    {
        [BsonElement("generationId"), BsonRepresentation(BsonType.String)]
        public string? generationId { get; set; }
    }
}
