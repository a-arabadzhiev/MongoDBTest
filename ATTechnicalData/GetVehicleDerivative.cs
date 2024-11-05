using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace ATTaxonomyVehicleTechnicalData
{
    public class GetVehicleDerivative
    {
        [BsonElement("derivativeId"), BsonRepresentation(BsonType.String)]
        public string? derivativeId { get; set; }
    }
}
