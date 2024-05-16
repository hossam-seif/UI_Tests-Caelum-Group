using OpenQA.Selenium;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using TestFramework;

namespace UI_Tests
{

    public class LoginPOM : FrameworkBase
    {
        public LoginPOM() { }

        #region POM login file
        public IWebElement registerbutton => IWebDriver.FindElements(By.XPath("//a[normalize-space()='Register']")).FirstOrDefault();
        public IWebElement usernamefield => IWebDriver.FindElements(By.Name("userNameOrEmailAddress")).FirstOrDefault();
        public IWebElement passwordfield => IWebDriver.FindElements(By.Name("password")).FirstOrDefault();
        public IWebElement loginbutton => IWebDriver.FindElements(By.XPath("//*[@id=\"kt_body\"]/app-root/ng-component/div/div/div[1]/div/ng-component/div[1]/form/div[6]/button")).FirstOrDefault();
        //public IWebElement Verifybutton => IWebDriver.FindElements(By.ClassName("ctp-checkbox-label")).FirstOrDefault();
        public IWebElement tenantcontrolbtn => IWebDriver.FindElements(By.XPath("//*[@id=\"kt_body\"]/app-root/ng-component/div/div/div[1]/div/div/tenant-change/span/a")).FirstOrDefault();
        public IWebElement tenantswichon => IWebDriver.FindElements(By.Name("SwitchToTenant")).FirstOrDefault();
        public IWebElement tenantname => IWebDriver.FindElements(By.Name("tenancyNameInput")).FirstOrDefault();
        public IWebElement switchbtn => IWebDriver.FindElements(By.XPath("//*[@id=\"kt_body\"]/app-root/ng-component/div/div/div[1]/div/div/tenant-change/span/tenantchangemodal/div/div/div/form/div[3]/button[2]/span")).FirstOrDefault();




        #endregion



    }
}
