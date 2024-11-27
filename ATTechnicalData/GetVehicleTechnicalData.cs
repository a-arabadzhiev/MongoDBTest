
using ATConnection;
using ATToken;
using MDBFindData;
using MDBInsertDocument;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using System.Text.Json;

namespace ATTaxonomyVehicleTechnicalData
{
    public class GetVehicleTechnicalData
    {
        public static void Main()
        {
            GetVehicleTechData();
        }

        public static void GetVehicleTechData()
        {
            List<BsonDocument>? vehiclegeneration = MDBGetData.Find(CollectionName: GlobalVariables.Variables.GetVehicleTechDataReq.collection, 
                                                                    Filter: GlobalVariables.Variables.GetVehicleTechDataReq.filter, 
                                                                    Project: GlobalVariables.Variables.GetVehicleTechDataReq.project);

            string? vehder = vehiclegeneration.Select(v => BsonSerializer.Deserialize<GetVehicleDerivative?>(v)).ToJson();

            vehder = "{\"derivativeId\":" + vehder + "}";

            GetDerivativeID? vg = JsonSerializer.Deserialize<GetDerivativeID?>(
                                json: vehder,
                                options: new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });

            AccessToken? token = GetToken.Token(ATTokenURL: GlobalVariables.Variables.ATTokenCred.ATTokenURL,
                                                      key: GlobalVariables.Variables.ATTokenCred.key,
                                                      secret: GlobalVariables.Variables.ATTokenCred.secret);

            foreach (var derivativeId in vg.derivativeId)
            {
                string? APITechDataUrl = GlobalVariables.Variables.GetVehicleTechDataReq.APIVehTechDataUrl1 + 
                                         derivativeId.derivativeId + 
                                         GlobalVariables.Variables.GetVehicleTechDataReq.APIVehTechDataUrl2;

                if (token.expires_at <= DateTime.Now.AddMinutes(2))
                {
                    token = GetToken.Token(ATTokenURL: GlobalVariables.Variables.ATTokenCred.ATTokenURL,
                                                      key: GlobalVariables.Variables.ATTokenCred.key,
                                                      secret: GlobalVariables.Variables.ATTokenCred.secret);
                }

                string? vehicleTechnicalData = ATConnect.ATApiData(ATApiUrl: APITechDataUrl, Token: token.access_token);

                var document = BsonDocument.Parse(vehicleTechnicalData);

                MDBInsert.InsertOne("VehicleTechnicalData", document);
            }
        }
    }
}