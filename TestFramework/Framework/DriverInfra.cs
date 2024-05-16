using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.Enums;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using System;

namespace TestFramework
{
    internal static class WebDriverInfra
    {
        /// <summary>
        /// Create driver browser 
        /// </summary>
        /// <param name="browserType">Select value from BrowserType enum</param>
        /// <param name="_timeSpan">Set time for command time out</param>
        /// <returns></returns>
        public static OpenQA.Selenium.IWebDriver Create_Browser(BrowserType browserType, TimeSpan _timeSpan)
        {
            switch (browserType)
            {
                case BrowserType.Chrome:
                    ChromeOptions chromeoptions = new ChromeOptions();
                    chromeoptions.AcceptInsecureCertificates = true;
                    chromeoptions.AddArgument("no-sandbox");
                    chromeoptions.AddUserProfilePreference("download.default_directory", FrameworkBase.Globalexportpath);
                    return new ChromeDriver(ChromeDriverService.CreateDefaultService(), chromeoptions, _timeSpan);
                case BrowserType.Firefox:
                    return new FirefoxDriver();
                case BrowserType.Edge:
                    return new EdgeDriver();
                default:
                    throw new ArgumentOutOfRangeException(nameof(browserType), browserType, null);
            }
        }

        /// <summary>
        /// Create Appuim Driver (Android)
        /// </summary>
        /// <param name="_mudid">Mobile UDID</param>
        /// <param name="_appPackage">Mobile app package</param>
        /// <param name="_appActivity">Mobile app activity</param>
        /// <param name="_serverurl">Appuim Server url</param>
        /// <param name="_noReset">Don't clear application data before the test</param>
        /// <returns></returns>
       // public static AndroidDriver<AndroidElement> Create_AppuimDriver(string _mudid, string _appPackage, string _appActivity, string _serverurl, bool _noReset = false)
        //{
         //   AppiumOptions capabilities = new AppiumOptions();
            //capabilities.AddAdditionalCapability(MobileCapabilityType.Udid, _mudid);
            //capabilities.AddAdditionalCapability(AndroidMobileCapabilityType.AppPackage, _appPackage);
           // capabilities.AddAdditionalCapability(AndroidMobileCapabilityType.AppActivity, _appActivity);
           // capabilities.AddAdditionalCapability("noReset", _noReset);
          //  capabilities.AddAdditionalCapability("autoGrantPermissions", true);
          //  capabilities.AddAdditionalCapability("launchTimeout", 40000);
          //  capabilities.AddAdditionalCapability("screenshotWaitTimeout", 10);
          //  capabilities.AddAdditionalCapability("newCommandTimeout", 120);
          //  capabilities.AddAdditionalCapability("appWaitActivity", "*");
         //   capabilities.AddAdditionalCapability("idleTimeout", 70);

            //  capabilities.AddAdditionalCapability("skipUnlock", false);
            // capabilities.AddAdditionalCapability("platformName", "Android");
            //return new AndroidDriver<AndroidElement>(new System.Uri(_serverurl), capabilities);
        }
    }

