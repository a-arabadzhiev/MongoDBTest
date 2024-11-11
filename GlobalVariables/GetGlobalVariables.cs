
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
            public static string? website = "https://api-sandbox.autotrader.co.uk/authenticate";
            //public static string? tkn_cookie = /*""__cf_bm=5W2rudDPaI0qejVjtFPlctGFc3fsJehaHGXigl8Tdgo-1731061275-1.0.1.1-zriKztazmXluJf2SJdphY5KuIuWbyASfBr7a7LRR_pjuYEy3luqmbuEyTC6MdsSj5z_HZb341Bq6FJSGJI56UQ"*/;
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
            public static string? WebSiteType = ATTaxonomyReq.requesturl + 
                                                "vehicleTypes?advertiserId=" + 
                                                ATTaxonomyReq.advertiserid;
        }

        public static void Main() { }
    }
}