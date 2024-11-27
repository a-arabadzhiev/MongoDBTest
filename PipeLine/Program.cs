using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
using PipeLine.ATToken;
using System.Text.Json;

namespace PipeLine
{
    public class AccessToken
    {
        public string? access_token { get; set; }
        public DateTime? expires_at { get; set; }
    }
    
    public class VehicleTypes
    {
        public List<Types>? vehicleTypes { get; set; }
    }
    public class Types
    {
        public string? name { get; set; }
    }
    
    public class VehicleMake
    {
        public List<Make>? makes { get; set; }
    }
    public class Make
    {
        public string? makeId { get; set; }
        public string? name { get; set; }
    }
    public class VehicleType
    {
        public string? name { get; set; }
    }
    public class GetVehicleType
    {
        [BsonElement("name"), BsonRepresentation(BsonType.String)]
        public string? name { get; set; }
    }
    
    public class VehicleModels
    {
        public List<Model>? models { get; set; }
    }
    public class Model
    {
        public string? modelId { get; set; }
        public string? name { get; set; }
    }
    public class GetMakeID
    {
        public List<MakeID>? makeId { get; set; }
    }
    public class MakeID
    {
        public string? makeId { get; set; }
    }
    public class GetVehicleMakes
    {
        [BsonElement("makeId"), BsonRepresentation(BsonType.String)]
        public string? makeId { get; set; }
    }
    
    public class VehicleGenerations
    {
        public List<Generation>? generations { get; set; }
    }
    public class Generation
    {
        public string? generationId { get; set; }
        public string? name { get; set; }
    }
    public class GetModelID
    {
        public List<Modelid>? modelId { get; set; }
    }
    public class Modelid
    {
        public string? modelId { get; set; }
    }
    public class GetVehicleModel
    {
        [BsonElement("modelId"), BsonRepresentation(BsonType.String)]
        public string? modelId { get; set; }
    }
    
    public class VehicleDerivative
    {
        public List<Derivative>? derivatives { get; set; }
    }
    public class Derivative
    {
        public string? derivativeId { get; set; }
        public string? name { get; set; }
        public DateTime? introduced { get; set; }
        public DateTime? discontinued { get; set; }
    }
    public class GetGenerationID
    {
        public List<GenerationID>? generationId { get; set; }
    }
    public class GenerationID
    {
        public string? generationId { get; set; }
    }
    public class GetVehicleGeneration
    {
        [BsonElement("generationId"), BsonRepresentation(BsonType.String)]
        public string? generationId { get; set; }
    }
    
    public class GetDerivativeID
    {
        public List<Derivativeid>? derivativeId { get; set; }
    }
    public class Derivativeid
    {
        public string? derivativeId { get; set; }
    }
    public class GetVehicleDerivative
    {
        [BsonElement("derivativeId"), BsonRepresentation(BsonType.String)]
        public string? derivativeId { get; set; }
    }

    namespace GlobalVariables
    {
        public class Variables
        {
            public class MDBCred
            {
                //MDB Variables
                public static string? client = "mongodb+srv://aarabadzhiev:#Zabrav1h@cluster0.urc9udb.mongodb.net/?retryWrites=true&w=majority&appName=Cluster0";
                public static string? database = "C#Test";
            }

            public class ATTokenCred
            {
                //AT Token Variables
                public static string? key = "eDynamix-StockMGT-Parkway-SB-05-09-24";
                public static string? secret = "JUwLAeG8zzlnJE2jyKizp0mzeEcBD65Q";
                public static string? ATTokenURL = "https://api-sandbox.autotrader.co.uk/authenticate";
            }

            public class ATTaxonomyReq
            {
                //AT Taxonomy Variables
                public static string? advertiserid = "66945";
                public static string? cookie = "__cf_bm=Rucph7ECriCdynJnhNow.vQ6YTW8hhUz_aHgRq0gJiA-1728326592-1.0.1.1-ka7pDua0XBYxhLQhFZxc8f_L4Zj99inX1wnAo56YeXzQ22oFjZb9XE7nwPt2jIGHSFPFJxBdbyLzkc10K_LN2Q";
                public static string? requesturl = "https://api-sandbox.autotrader.co.uk/taxonomy/";
            }

            public class GetVehicleTypesReq
            {
                //GetVehicleTypes
                public static string? ATVehTypURL = ATTaxonomyReq.requesturl +
                                                    "vehicleTypes?advertiserId=" +
                                                    ATTaxonomyReq.advertiserid;
            }

            public class GetVehicleMakesReq
            {
                //GetVehicleMakes
                public static string? type = "Car";
                public static string? collection = "VehicleTypes";
                public static string? project = "{ _id : 0 }";
                public static string? filter = "{name: \"" + type + "\" }";
                public static string? ATVehMakeURL1 = ATTaxonomyReq.requesturl + "makes?vehicleType=";
                public static string? ATVehMakeURL2 = "&advertiserId=" + ATTaxonomyReq.advertiserid;
            }

            public class GetVehicleModelsReq
            {
                //GetVehicleModels
                public static string? collection = "VehicleMakes";
                public static string? project = "{makeId: 1, _id: 0}";
                public static string? filter = "{}";
                public static string? APIVehModelUrl1 = ATTaxonomyReq.requesturl + "models?makeId=";
                public static string? APIVehModelUrl2 = "&advertiserId=" + ATTaxonomyReq.advertiserid;
            }

            public class GetVehicleGenerationsReq
            {
                //GetVehicleGenerations
                public static string? collection = "VehicleModels";
                public static string? project = "{modelId: 1, _id: 0 }";
                public static string? filter = "{}";
                public static string? APIVehGenUrl = ATTaxonomyReq.requesturl + "generations?modelId=";
            }

            public class GetVehicleDerivativesReq
            {
                //GetVehicleDerivatives
                public static string? collection = "VehicleGenerations";
                public static string? project = "{generationId: 1, _id: 0 }";
                public static string? filter = "{}";
                public static string? APIVehDerUrl = ATTaxonomyReq.requesturl + "derivatives?generationId=";
            }

            public class GetVehicleTechDataReq
            {
                //GetVehicleTechnicalData
                public static string? collection = "VehicleDerivatives";
                public static string? project = "{derivativeId: 1, _id: 0 }";
                public static string? filter = "{}";
                public static string? APIVehTechDataUrl1 = ATTaxonomyReq.requesturl + "derivatives/";
                public static string? APIVehTechDataUrl2 = "?advertiserId=" + ATTaxonomyReq.advertiserid;
            }

            public static void Main() { }
        }
    }

    namespace ATToken
    {
        public class GetToken
        {
            public static AccessToken? Token(string? ATTokenURL, string? key, string? secret)
            {
                try
                {
                    //Get Token //Auto Trader Sandbox token
                    var ATclient = new HttpClient();
                    var ATrequest = new HttpRequestMessage(HttpMethod.Post, ATTokenURL);
                    ATrequest.Headers.Add("Cookie", "__cf_bm=5W2rudDPaI0qejVjtFPlctGFc3fsJehaHGXigl8Tdgo-1731061275-1.0.1.1-zriKztazmXluJf2SJdphY5KuIuWbyASfBr7a7LRR_pjuYEy3luqmbuEyTC6MdsSj5z_HZb341Bq6FJSGJI56UQ");
                    var collection = new List<KeyValuePair<string, string>>();
                    collection.Add(new("key", key));
                    collection.Add(new("secret", secret));
                    var content = new FormUrlEncodedContent(collection);
                    ATrequest.Content = content;
                    var ATresponse = ATclient.Send(ATrequest);
                    ATresponse.EnsureSuccessStatusCode();
    
                    var AccessTokenRes = ATresponse.Content.ReadAsStream();
                    AccessToken? accesstoken = JsonSerializer.Deserialize<AccessToken?>(AccessTokenRes);
    
                    return accesstoken;
                }

                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
    
                return null;
            }
            public static void Main()
            {
                Token(ATTokenURL: GlobalVariables.Variables.ATTokenCred.ATTokenURL,
                      key: GlobalVariables.Variables.ATTokenCred.key,
                      secret: GlobalVariables.Variables.ATTokenCred.secret);
            }
        }
    }
    
    namespace ATConnection
    {
        public class ATConnect(string? ATApiUrl, string? Token)
        {
            public static void Main() { }

            public static string? ATApiData(string? ATApiUrl, string? Token)
            {
                try
                {
                    var client = new HttpClient();
                    var request = new HttpRequestMessage(HttpMethod.Get, ATApiUrl);
                    request.Headers.Add("Authorization", "Bearer " + Token);
                    request.Headers.Add("cpntent-type", "application/json");
                    request.Headers.Add("Cookie", "__cf_bm=ASn2f57BcwPZTa7Xou6ebNAST3K8p2O2ZjeBfYxpsvk-1731578777-1.0.1.1-CJ6ha8lTpfDzvrsFVX264Qc5qiP2RfUQDpIzZvt6WAw15bBMWBP.X2hB5lpL.ZXiyxz8v4WG4YZclF84AU.x4g");
                    var response = client.Send(request);
                    response.EnsureSuccessStatusCode();
    
                    var VehData = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
    
                    return VehData.ToString();
                }

                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
    
                return null;
            }
        }
    }

    namespace MDBFindData
    {
        public class MDBGetData(string? CollectionName, string? Filter, string? Project)
        {
            public static void Main() { }

            public static List<BsonDocument>? Find(string? CollectionName, string? Filter, string? Project)
            {
                try
                {
                    var MDBclient = new MongoClient(GlobalVariables.Variables.MDBCred.client);
                    var MDBdatabase = MDBclient.GetDatabase(GlobalVariables.Variables.MDBCred.database);
                    var MDBcollection = MDBdatabase.GetCollection<BsonDocument>(CollectionName);

                    var FindData = MDBcollection.Find(Filter)
                                                .Project(Project)
                                                .ToList();

                    return FindData;
                }

                catch (Exception ex) 
                {
                    Console.WriteLine(ex.Message);
                }

                return null;
            }
        }
    }

    namespace MDBInsertDocument
    {
        public class MDBInsert(string? CollectionName, BsonDocument? Document)
        {
            public static void Main() { }

            public static void InsertOne(string? CollectionName, BsonDocument? Document)
            {
                try
                {
                    var MDBclient = new MongoClient(GlobalVariables.Variables.MDBCred.client);
                    var MDBdatabase = MDBclient.GetDatabase(GlobalVariables.Variables.MDBCred.database);
                    var MDBcollection = MDBdatabase.GetCollection<BsonDocument>(CollectionName);

                    MDBcollection.InsertOne(Document);
                }

                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }

    namespace ATTaxonomyVehicleTypes
    {
        public class GetVehicleTypes
        {
            public static void Main()
            {
                GetVehicleType(ATVehTypURL: GlobalVariables.Variables.GetVehicleTypesReq.ATVehTypURL);
            }

            public static void GetVehicleType(string? ATVehTypURL)
            {
                try
                {
                    AccessToken? ATToken = GetToken.Token(ATTokenURL: GlobalVariables.Variables.ATTokenCred.ATTokenURL,
                                                          key: GlobalVariables.Variables.ATTokenCred.key,
                                                          secret: GlobalVariables.Variables.ATTokenCred.secret);

                    string? vehtyp = ATConnection.ATConnect.ATApiData(ATApiUrl: ATVehTypURL, Token: ATToken.access_token);

                    Console.WriteLine(vehtyp);
                    Console.ReadLine();

                    VehicleTypes? vehicletype = JsonSerializer.Deserialize<VehicleTypes?>(
                        json: vehtyp,
                        options: new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });

                    foreach (var name in vehicletype.vehicleTypes)
                    {
                        var document = new BsonDocument
                        {
                            {"name", name.name}
                        };

                        MDBInsertDocument.MDBInsert.InsertOne("VehicleTypes", document);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }

    namespace ATTaxonomyVehicleMakes
    {
        public class GetVehicleMakes
        {
            public static void Main()
            {
                GetVehicleMake();
            }

            public static void GetVehicleMake()
            {
                try
                {
                    var vehicletype = MDBFindData.MDBGetData.Find(CollectionName: GlobalVariables.Variables.GetVehicleMakesReq.collection,
                                                      Filter: GlobalVariables.Variables.GetVehicleMakesReq.filter,
                                                      Project: GlobalVariables.Variables.GetVehicleMakesReq.project);

                    string? vehtyp = vehicletype.Select(v => BsonSerializer.Deserialize<GetVehicleType>(v)).ToJson()
                                                                                                           .Replace("[", "")
                                                                                                           .Replace("]", "");

                    VehicleType? vt = JsonSerializer.Deserialize<VehicleType?>(
                                        json: vehtyp,
                                        options: new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });

                    string? APIVehMakeUrl = GlobalVariables.Variables.GetVehicleMakesReq.ATVehMakeURL1 +
                                     vt.name +
                                     GlobalVariables.Variables.GetVehicleMakesReq.ATVehMakeURL2;

                    AccessToken? ATToken = GetToken.Token(ATTokenURL: GlobalVariables.Variables.ATTokenCred.ATTokenURL,
                                                              key: GlobalVariables.Variables.ATTokenCred.key,
                                                              secret: GlobalVariables.Variables.ATTokenCred.secret);

                    string? vehicleMake = ATConnection.ATConnect.ATApiData(ATApiUrl: APIVehMakeUrl, Token: ATToken.access_token);

                    VehicleMake? vehiclemakes = JsonSerializer.Deserialize<VehicleMake?>(
                        json: vehicleMake,
                        options: new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });

                    foreach (var make in vehiclemakes.makes)
                    {
                        var document = new BsonDocument
                        {
                            {"makeId", make.makeId},
                            {"name", make.name}
                        };

                        MDBInsertDocument.MDBInsert.InsertOne("VehicleMakes", document);
                    }
                }

                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }

    namespace ATTaxonomyVehicleModels
    {
        public class GetVehicleModels
        {
            public static void Main()
            {
                GetVehicleModel();
            }

            public static void GetVehicleModel()
            {
                try
                {
                    var vehiclemake = MDBFindData.MDBGetData.Find(CollectionName: GlobalVariables.Variables.GetVehicleModelsReq.collection,
                                                      Filter: GlobalVariables.Variables.GetVehicleModelsReq.filter,
                                                      Project: GlobalVariables.Variables.GetVehicleModelsReq.project);

                    string? vehmake = vehiclemake.Select(v => BsonSerializer.Deserialize<ATTaxonomyVehicleMakes.GetVehicleMakes>(v)).ToJson();

                    vehmake = "{\"makeId\":" + vehmake + "}";

                    GetMakeID? vm = JsonSerializer.Deserialize<GetMakeID?>(
                                        json: vehmake,
                                        options: new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });

                    foreach (var makeId in vm.makeId)
                    {
                        string? APIVehModelUrl = GlobalVariables.Variables.GetVehicleModelsReq.APIVehModelUrl1 +
                                                 makeId.makeId +
                                                 GlobalVariables.Variables.GetVehicleModelsReq.APIVehModelUrl2;

                        AccessToken? ATToken = GetToken.Token(ATTokenURL: GlobalVariables.Variables.ATTokenCred.ATTokenURL,
                                                              key: GlobalVariables.Variables.ATTokenCred.key,
                                                              secret: GlobalVariables.Variables.ATTokenCred.secret);

                        string? vehicleModel = ATConnection.ATConnect.ATApiData(ATApiUrl: APIVehModelUrl, Token: ATToken.access_token);

                        VehicleModels? vehmod = JsonSerializer.Deserialize<VehicleModels?>(
                            json: vehicleModel,
                            options: new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });

                        foreach (var modelId in vehmod.models)
                        {
                            var document = new BsonDocument
                            {
                                {"modelId", modelId.modelId},
                                {"name", modelId.name}
                            };

                            MDBInsertDocument.MDBInsert.InsertOne("VehicleModels", document);
                        }
                    }
                }

                catch (Exception ex) 
                { 
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }

    namespace ATTaxonomyVehicleGenerations
    {
        public class GetVehicleGenerations
        {
            public static void Main()
            {
                GetVehicleGeneration();
            }

            public static void GetVehicleGeneration()
            {
                try
                {
                    List<BsonDocument>? vehiclemodel = MDBFindData.MDBGetData.Find(CollectionName: GlobalVariables.Variables.GetVehicleGenerationsReq.collection,
                                                                       Filter: GlobalVariables.Variables.GetVehicleGenerationsReq.filter,
                                                                       Project: GlobalVariables.Variables.GetVehicleGenerationsReq.project);

                    string? vehmod = vehiclemodel.Select(v => BsonSerializer.Deserialize<GetVehicleModel?>(v)).ToJson();

                    vehmod = "{\"modelId\":" + vehmod + "}";

                    GetModelID? vm = JsonSerializer.Deserialize<GetModelID?>(
                                        json: vehmod,
                                        options: new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });

                    DateTime? expires = DateTime.Now;
                    AccessToken? token = GetToken.Token(ATTokenURL: GlobalVariables.Variables.ATTokenCred.ATTokenURL,
                                                   key: GlobalVariables.Variables.ATTokenCred.key,
                                                   secret: GlobalVariables.Variables.ATTokenCred.secret);

                    foreach (var modelId in vm.modelId)
                    {
                        string? APIVehGenUrl = GlobalVariables.Variables.GetVehicleGenerationsReq.APIVehGenUrl + modelId.modelId;

                        if (token.expires_at <= expires)
                        {
                            expires = DateTime.Now;
                            token = GetToken.Token(ATTokenURL: GlobalVariables.Variables.ATTokenCred.ATTokenURL,
                                                   key: GlobalVariables.Variables.ATTokenCred.key,
                                                   secret: GlobalVariables.Variables.ATTokenCred.secret);
                        }

                        string? vehicleGeneration = ATConnection.ATConnect.ATApiData(ATApiUrl: APIVehGenUrl, Token: token.access_token);

                        VehicleGenerations? vehgen = JsonSerializer.Deserialize<VehicleGenerations?>(
                            json: vehicleGeneration,
                            options: new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });

                        foreach (var generationId in vehgen.generations)
                        {
                            var document = new BsonDocument
                            {
                                {"generationId", generationId.generationId},
                                {"name", generationId.name}
                            };

                            MDBInsertDocument.MDBInsert.InsertOne("VehicleGenerations", document);
                        }
                    }
                }

                catch (Exception ex) 
                { 
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }

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
                try
                {
                    List<BsonDocument>? vehiclegeneration = MDBFindData.MDBGetData.Find(CollectionName: GlobalVariables.Variables.GetVehicleDerivativesReq.collection,
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

                        string? vehicleDerivatives = ATConnection.ATConnect.ATApiData(ATApiUrl: APIVehDerUrl, Token: token.access_token);

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

                            MDBInsertDocument.MDBInsert.InsertOne("VehicleDerivatives", document);
                        }
                    }
                }

                catch (Exception ex) 
                { 
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }

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
                try
                {
                    List<BsonDocument>? vehiclegeneration = MDBFindData.MDBGetData.Find(CollectionName: GlobalVariables.Variables.GetVehicleTechDataReq.collection,
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

                        string? vehicleTechnicalData = ATConnection.ATConnect.ATApiData(ATApiUrl: APITechDataUrl, Token: token.access_token);

                        var document = BsonDocument.Parse(vehicleTechnicalData);

                        MDBInsertDocument.MDBInsert.InsertOne("VehicleTechnicalData", document);
                    }
                }

                catch (Exception ex) 
                { 
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }

    public class PipeLine
    {
        public static void Main()
        {
            ATTaxonomyVehicleTypes.GetVehicleTypes.GetVehicleType(GlobalVariables.Variables.GetVehicleTypesReq.ATVehTypURL);
            ATTaxonomyVehicleMakes.GetVehicleMakes.GetVehicleMake();
            ATTaxonomyVehicleModels.GetVehicleModels.GetVehicleModel();
            ATTaxonomyVehicleGenerations.GetVehicleGenerations.GetVehicleGeneration();
            ATTaxonomyVehicleDerivatives.GetVehicleDerivatives.GetVehicleDerivative();
            ATTaxonomyVehicleTechnicalData.GetVehicleTechnicalData.GetVehicleTechData();
        }
    }
}