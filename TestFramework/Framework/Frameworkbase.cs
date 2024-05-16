using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Android;
using System;
using System.Threading;

namespace TestFramework
{
    [TestClass]
    public partial class FrameworkBase : FrameworkExtendMethods
    {
        public static ILogger _logger = null;

        public struct WebLoginPOM
        {
            public static IWebElement Usernamefield;
            public static IWebElement Passwordfield;
            public static IWebElement Loginbutton;
            
        };

        //public struct MobLoginPOM
        //{

          //  public static IWebElement Usernamefield;
            //public static IWebElement Passwordfield;
            //public static IWebElement Loginbutton;
        //};

        /// <summary>
        /// Static driver object
        /// </summary>
        public static IWebDriver IWebDriver { get; set; }
        /// <summary>
        /// Appuim Android Driver
        /// </summary>
        //public static AndroidDriver<AndroidElement> Mobiledriver = null;
        /// <summary>
        /// Appuim Options
        /// </summary>
        //public static AppiumOptions Capabilities { get; set; }

        private static IWebElement element { get; set; }

        //private static ChromeOptions _chromeoptions = new ChromeOptions();
        private static void Recreateddriver()
        {
            IWebDriver = WebDriverInfra.Create_Browser(BrowserType.Chrome, System.TimeSpan.FromMinutes(40));
            IWebDriver.Navigate().GoToUrl("https://demo.aspnetzero.com/account/login");
            IWebDriver.Manage().Window.Maximize();
            IWebDriver.Manage().Timeouts().ImplicitWait = System.TimeSpan.FromSeconds(20);
            IWebDriver.Manage().Timeouts().PageLoad.Add(System.TimeSpan.FromSeconds(20));

            if (FrameworkBase._logger != null) _logger.Print("[base] [Information] [Recreatedriver] driver initalized.");
        }

        static FrameworkBase()
        {
            _logger = new ConsoleLogger();
        }

        /// <summary>
        /// FUN() to Initiate browser
        /// </summary>
        public static void InitiateWebBrowser(TestContext _testcontext, string url = "")
        {
            try
            {
                _TestContext = _testcontext;
                ReadConfigVariable(ref _testcontext);

                if (IWebDriver == null)
                {
                    Recreateddriver();
                }

                if (IWebDriver?.Url != "data:,")
                {
                    IJavaScriptExecutor js = (IJavaScriptExecutor)IWebDriver;
                    js?.ExecuteScript("window.localStorage.clear();");
                    if (FrameworkBase._logger != null) _logger.Print("[base] [Information] [Initiatebrowser] : driver local storage is cleared ");
                }
                IWebDriver?.Navigate().Refresh();
                if (!string.IsNullOrWhiteSpace(url))
                {
                    IWebDriver?.Navigate().GoToUrl(url: url);
                    if (FrameworkBase._logger != null) _logger.Print("[base] [Information] [Initiatebrowser] : Connect to " + url);
                }
                else if (string.IsNullOrWhiteSpace(url))
                {
                    IWebDriver?.Navigate().GoToUrl(WebBaseUrl);
                    if (FrameworkBase._logger != null) _logger.Print("[base] [Config] [Information] [Initiatebrowser] : Connect to " + url);
                }

                IWebDriver?.Manage().Timeouts().ImplicitWait.Add(System.TimeSpan.FromSeconds(30));
                IWebDriver?.Manage().Timeouts().PageLoad.Add(System.TimeSpan.FromSeconds(30));

            }

            catch (System.Exception ex)
            {
                if (FrameworkBase._logger != null) FrameworkBase._logger.Print("[Exception] [Initiatebrowser]: " + ex.Message);
                //Microsoft.VisualStudio.TestTools.UnitTesting.Assert.Fail("!exception (InitiatenewLogin): " + ex.Message);
            }

        }
        /// <summary>
        /// Initiate mobile Appuim Driver (Android)
        /// </summary>
        /// <param name="_mudid">Mobile UDID</param>
        /// <param name="_appPackage">Mobile app package</param>
        /// <param name="_appActivity">Mobile app activity</param>
        /// <param name="_serverurl">Appuim Server url</param>
        /// <param name="_noReset">Don't clear application data before the test</param>
         //<returns></returns>
        public virtual void InitiateMobile(TestContext _testxContext, string _mudid = "", string _appPackage = "", string _appActivity = "", string _serverurl = "", bool _noReset = false)
        {
            //  _TestContext = _testxContext;
            ReadConfigVariable(ref _testxContext);
            //Mobiledriver = WebDriverInfra.Create_AppuimDriver(string.IsNullOrWhiteSpace(_mudid) ? MobileUdid : _mudid, string.IsNullOrWhiteSpace(_appPackage) ? AndroidAppPackage : _appPackage, string.IsNullOrWhiteSpace(_appActivity) ? AndroidAppActivity : _appActivity, string.IsNullOrWhiteSpace(_serverurl) ? AppuimServer : _serverurl, _noReset);
            //Mobiledriver.ConfiguratorSetWaitForSelectorTimeout(10000);
            //Mobiledriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(70);
            //Mobiledriver.Unlock();
        }

        public virtual void InitiateApi(TestContext _testxContext)
        {
            _TestContext = _testxContext;
            ReadConfigVariable(ref _testxContext);
        }

        public static void ReadConfigVariable(ref TestContext _testxContext)
        {
            //MobileUdid = (string)_testxContext.Properties["MobileUdid"];
            //AndroidAppPackage = (string)_testxContext.Properties["AndroidAppPackage"];
            //AndroidAppActivity = (string)_testxContext.Properties["AndroidAppActivity"];
            //noReset = bool.Parse(_testxContext.Properties["noReset"].ToString());
            //AppuimServer = (string)_testxContext.Properties["AppuimServer"];
            //MobileGlobalUsername = (string)_testxContext.Properties["MobileGlobalUsername"];
            //MobileGlobalPassword = (string)_testxContext.Properties["MobileGlobalPassword"];
            WebBaseUrl = (string)_testxContext.Properties["WebBaseUrl"];
            WebGlobalUsername = (string)_testxContext.Properties["WebGlobalUsername"];
            WebGlobalPassword = (string)_testxContext.Properties["WebGlobalPassword"];
            WebGlobaltenant= (string)_testxContext.Properties["WebGlobaltenant"];
            //WebCloseDriver = bool.Parse(_testxContext.Properties["WebCloseDriver"].ToString());
            //MobileCloseDriver = bool.Parse(_testxContext.Properties["MobileCloseDriver"].ToString());
            ApiBaseUrl = (string)_testxContext.Properties["ApiBaseUrl"];
            Globalscreenshootpath = (string)_testxContext.Properties["Globalscreenshootpath"];
            Globalexportpath = (string)_testxContext.Properties["Globalexportpath"];
        }

        public virtual void Logininto(string Username, string Password)
        {
            try
            {
                WebLoginPOM.Usernamefield.Click();
                WebLoginPOM.Usernamefield.SendKeys(Username);
                WebLoginPOM.Passwordfield.Click();
                WebLoginPOM.Passwordfield.SendKeys(Password);
                // Mobiledriver.HideKeyboard();
                WebLoginPOM.Loginbutton.Click();

                Thread.Sleep(3990);
                // bool? _res = _loginpom.validationsuceessmessage.CheckValidation("System Modes");
                // Assert.AreEqual(_res, true);
            }
            catch (System.Exception ex)
            {
                if (FrameworkBase._logger != null) FrameworkBase._logger.Print("[Exception] [Logininto] : " + ex.Message);
                Assert.Fail("[Exception] [Logininto] : " + ex.Message);
                throw (ex);
            }
        }

        /// <summary>
        /// FUN() to dispose driver
        /// </summary>
        /// <param name="dispose"> true: to close driver , false: to skip close driver</param>
        public static void WebDriverDispose(bool dispose = true)
        {
            if (dispose)
            {
                if (IWebDriver != null)
                {
                    try
                    {
                        IWebDriver.Quit();
                        IWebDriver = null;
                        if (FrameworkBase._logger != null) FrameworkBase._logger.Print("[Information] [DriverDispose] : Driver Closed");
                    }
                    catch (System.Exception ex)
                    {
                        if (FrameworkBase._logger != null) FrameworkBase._logger.Print("[Exception] [DriverDispose] : " + ex.Message);
                    }
                }
            }
            else
            {
                if (FrameworkBase._logger != null) FrameworkBase._logger.Print("[Information] [DriverDispose] : Skip Driver Closed");
            }
        }

        /// <summary>
        /// FUN() to dispose mobiledriver
        /// </summary>
        /// <param name="dispose"> true: to close driver , false: to skip close driver</param>
        //public static void MobileDriverDispose(bool dispose = true)
        // {
        // if (dispose)
        // {
        //  if (Mobiledriver != null)
        //{
        //   try
        // {
        //Mobiledriver.Quit();
        //Mobiledriver = null;
        //if (FrameworkBase._logger != null) FrameworkBase._logger.Print("[Information] [MobileDriverDispose] : Driver Closed");
        // }
        //catch (System.Exception ex)
        //{
        //if (FrameworkBase._logger != null) FrameworkBase._logger.Print("[Exception] [MobileDriverDispose] : " + ex.Message);
        //}
        // }
        //}
        //else
        //{
        // if (FrameworkBase._logger != null) FrameworkBase._logger.Print("[Information] [MobileDriverDispose] : Skip Driver Closed");
        //}
        // }
        //}

    }
}
