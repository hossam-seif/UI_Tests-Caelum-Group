
namespace TestFramework
{
    public partial class FrameworkBase
    {
        /// <summary>
        /// BaseApi base url
        /// </summary>
        public static string BaseApiUrl = "";

        /// <summary>
        /// Default username have all authority
        /// </summary>
        public static string WebGlobalusername = "";

        /// <summary>
        /// Password of default account
        /// </summary>
        public static string Globalpassword = "";

        /// <summary>
        /// Flag to close driver after finishing run test cases
        /// </summary>
        public static bool Closedriver = true;


        public static string MobileUdid = "";

        public static string AndroidAppPackage = "";

        public static string AndroidAppActivity = "";

        public static bool noReset = false;

        public static string AppuimServer = "";

        /// <summary>
        /// Flag to close driver after finishing run test cases
        /// </summary>
        public static bool MobileCloseDriver = true;

        public static string MobileGlobalUsername = "";

        public static string MobileGlobalPassword = "";

        public static string WebGlobalUsername = "";

        public static string WebGlobalPassword = "";

        public static string WebGlobaltenant { get; private set; }

        public static string WebBaseUrl = "";
        /// <summary>
        /// Flag to close driver after finishing run test cases
        /// </summary>
        public static bool WebCloseDriver = false;

        public static string ApiBaseUrl = "";

        public static string Globalscreenshootpath = @"";
        /// <summary>
        /// Export file Path on VM
        /// </summary>
        public static string Globalexportpath = @"";
    }
}
