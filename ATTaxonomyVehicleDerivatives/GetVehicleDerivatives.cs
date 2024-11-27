
using ATConnection;
using ATToken;
using MDBFindData;
using MDBInsertDocument;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using System.Text.Json;

namespace ATTaxonomyVehicleDerivatives
{
    public class GetVehicleDerivatives
    {
        public static void Main()
        {
            GetVehicleDerivative();
        }

        public static void GetVehicleDerivative()
        {
            List<BsonDocument>? vehiclegeneration = MDBGetData.Find(CollectionName: GlobalVariables.Variables.GetVehicleDerivativesReq.collection, 
                                                                    Filter: GlobalVariables.Variables.GetVehicleDerivativesReq.filter, 
                                                                    Project: GlobalVariables.Variables.GetVehicleDerivativesReq.project);

            string? vehgen = vehiclegeneration.Select(v => BsonSerializer.Deserialize<GetVehicleGeneration?>(v)).ToJson();

            vehgen = "{\"generationId\":" + vehgen + "}";

            GetGenerationID? vg = JsonSerializer.Deserialize<GetGenerationID?>(
                                      json: vehgen,
                                      options: new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });

            AccessToken? token = GetToken.Token(ATTokenURL: GlobalVariables.Variables.ATTokenCred.ATTokenURL,
                                                key: GlobalVariables.Variables.ATTokenCred.key,
                                                secret: GlobalVariables.Variables.ATTokenCred.secret);

            foreach (var generationId in vg.generationId)
            {
                string? APIVehDerUrl = GlobalVariables.Variables.GetVehicleDerivativesReq.APIVehDerUrl + generationId.generationId;

                if (token.expires_at <= DateTime.Now.AddMinutes(2))
                {
                    token = GetToken.Token(ATTokenURL: GlobalVariables.Variables.ATTokenCred.ATTokenURL,
                                           key: GlobalVariables.Variables.ATTokenCred.key,
                                           secret: GlobalVariables.Variables.ATTokenCred.secret);
                }

                string? vehicleDerivatives = ATConnect.ATApiData(ATApiUrl: APIVehDerUrl, Token: token.access_token);

                VehicleDerivative? vehder = JsonSerializer.Deserialize<VehicleDerivative?>(
                    json: vehicleDerivatives,
                    options: new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });

                foreach (var derivativeId in vehder.derivatives)
                {
                    var document = new BsonDocument
                    {
                        {"derivativeId", derivativeId.derivativeId},
                        {"name", derivativeId.name},
                        {"introduced", derivativeId.introduced},
                        {"discontinued", derivativeId.discontinued}
                    };

                    MDBInsert.InsertOne("VehicleDerivatives", document);
                }
            }
        }
    }
}