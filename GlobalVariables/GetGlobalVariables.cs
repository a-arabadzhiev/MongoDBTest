
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