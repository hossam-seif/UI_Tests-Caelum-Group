using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using TestFramework;
using Web_Tests;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace UI_Tests

{
    [TestClass]
    public class Login_TCs : LoginPOM
    {
        public TestContext TestContext { get; set; }
        public Login_TCs()
        {

        }
        [TestInitialize]
        public void TestInitialize()
        {
            InitiateWebBrowser(TestContext);
            
        }

        public void Login (string username = "", string password = "")
        {

            if (string.IsNullOrWhiteSpace(username))
                username = WebGlobalUsername;

            if (string.IsNullOrWhiteSpace(password))
                password = WebGlobalPassword;
            
            try
            {
                usernamefield.SetText(username);
                passwordfield.SetText(password);
                loginbutton.Clicks();

            }
            catch (Exception ex)
            {
                FrameworkBase._logger?.Print("[Login] Unexpected behavior occurred : " + ex.Message);
            }
        }

    

    [DataTestMethod]
    [DataRow("", "")]
    public void Register (string username, string password,string tenant)
    {
            System.Threading.Thread.Sleep(2000);
            tenantcontrolbtn.Click();
            System.Threading.Thread.Sleep(3000);
            tenantswichon.Click();
            tenantname.Click();
            tenantname.SendKeys("t5b854a28");
            switchbtn.Click();
            System.Threading.Thread.Sleep(1000);
            Login_TCs logintc = new Login_TCs(); logintc.login(username, password);
            System.Threading.Thread.Sleep(2000);
            


            


            //IWebDriver.Screenshot(MethodBase.GetCurrentMethod().Name);


        }
        [DataTestMethod]
        [DataRow("", "")]
        public void login(string username, string password)
        {
            //Login_TCs logintc = new Login_TCs(); logintc.login(username, password);
            System.Threading.Thread.Sleep(2000);
            tenantcontrolbtn.Click();
            System.Threading.Thread.Sleep(3000);
            tenantswichon.Click();
            tenantname.Click();
            tenantname.SendKeys("t5b854a28");
            switchbtn.Click();
            System.Threading.Thread.Sleep(5000);
            usernamefield.Click();
            usernamefield.Clear();
            usernamefield.SetText(username);
            System.Threading.Thread.Sleep(3000);
            passwordfield.Click();
            passwordfield.Clear();
            passwordfield.SetText(password);
            System.Threading.Thread.Sleep(3000);
            loginbutton.Clicks();
            System.Threading.Thread.Sleep(7000);

            //IWebDriver.Screenshot(MethodBase.GetCurrentMethod().Name);


        }


        [TestCleanup]
        public void Cleanup()
        {
            WebDriverDispose();
        }
    }
}