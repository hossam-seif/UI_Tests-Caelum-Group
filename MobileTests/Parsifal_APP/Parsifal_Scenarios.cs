using Microsoft.VisualStudio.TestTools.UnitTesting;
using Mobile_Tests;
using OpenQA.Selenium.Appium;
using System.Threading;


namespace Mobile_Tests
{

    [TestClass]
    public class Parsifal_scenarios : Parsifal_POM

    {
        public TestContext TestContext { get; set; }
        public Parsifal_scenarios()
        {

        }

        [TestInitialize]
        public void TestInitialize()
        {
            InitiateMobile(TestContext);
        }
        public void Save_Language()
        {
            btn_Save.Click();
        }

        [DataTestMethod]
        [TestCategory("SmokeTesting")]
        public void Save_Language_sc_25211()
        {
            btn_Save.Click();
            Thread.Sleep(2000);
            Mobiledriver.Screenshot();
            Assert.IsTrue((txt_Login_Service_URL).Displayed);

        }

        //[DataTestMethod]
        [DataRow("https://parsifal-test.sab-factory.com:38038/", "https://parsifal-test.sab-factory.com:38041/", "https://parsifal-test.sab-factory.com:38045/")]
        public void Set_config(string login_URL, string Alarms_URL, string Socket_URL)
        {
            txt_Login_Service_URL.Click();
            Mobiledriver.HideKeyboard();
            txt_Login_Service_URL.SendKeys(login_URL);
            Mobiledriver.HideKeyboard();
            txt_Alarms_Service_URL.Click();
            Mobiledriver.HideKeyboard();
            txt_Alarms_Service_URL.SetText(Alarms_URL);
            Mobiledriver.HideKeyboard();
            txt_Socket_Service_URL.Click();
            Mobiledriver.HideKeyboard();
            Thread.Sleep(500);
            txt_Socket_Service_URL.SetText(Socket_URL);
            Mobiledriver.HideKeyboard();
            btn_Save.Click();
            Thread.Sleep(500);
        }

        [DataTestMethod]
        [DataRow("https://parsifal-test.sab-factory.com:38038/", "https://parsifal-test.sab-factory.com:38041/", "https://parsifal-test.sab-factory.com:38045/"), TestCategory("SmokeTesting")]
        public void Check_Set_config_sc_25212(string login_URL, string Alarms_URL, string Socket_URL)
        {
            Save_Language();
            Thread.Sleep(1000);
            txt_Login_Service_URL.Click();
            Mobiledriver.HideKeyboard();
            txt_Login_Service_URL.SendKeys(login_URL);
            txt_Alarms_Service_URL.Click();
            Mobiledriver.HideKeyboard();
            txt_Alarms_Service_URL.SetText(Alarms_URL);
            txt_Socket_Service_URL.Click();
            Mobiledriver.HideKeyboard();
            Thread.Sleep(500);
            txt_Socket_Service_URL.SetText(Socket_URL);
            Mobiledriver.HideKeyboard();
            btn_Save.Click();
            Thread.Sleep(500);
            Mobiledriver.Screenshot();
            Assert.IsTrue((txt_User_Name).Displayed);
        }


        public void login()
        {
            Thread.Sleep(1000);
            txt_User_Name.Click();
            Mobiledriver.HideKeyboard();
            txt_User_Name.SetText(MobileGlobalUsername);
            txt_Password.Click();
            Mobiledriver.HideKeyboard();
            txt_Password.SetText(MobileGlobalPassword);
            Mobiledriver.HideKeyboard();
            btn_login.Click();
        }




        [DataTestMethod]
        [DataRow("https://parsifal-test.sab-factory.com:38038/", "https://parsifal-test.sab-factory.com:38041/", "https://parsifal-test.sab-factory.com:38045/"), TestCategory("SmokeTesting")]
        public void Check_login_sc_22776(string login_URL, string Alarms_URL, string Socket_URL)
        {
            Save_Language();
            Thread.Sleep(2000);
            Set_config(login_URL, Alarms_URL, Socket_URL);
            Thread.Sleep(2000);
            txt_User_Name.Click();
            Mobiledriver.HideKeyboard();
            txt_User_Name.SetText(MobileGlobalUsername);
            txt_Password.Click();
            Thread.Sleep(1000);
            Mobiledriver.HideKeyboard();
            txt_Password.SetText(MobileGlobalPassword);
            Mobiledriver.HideKeyboard();
            btn_login.Click();
            Mobiledriver.Screenshot();
            Assert.IsTrue((btn_Alarms_module).Displayed);
        }



        public void CheckoutAlarm()
        {
            btn_Alarms_module.Click();
            Thread.Sleep(10000);
            btn_Alarm_Card.Click();
            btn_Yes.Click();
        }


        [DataTestMethod]
        [DataRow("https://parsifal-test.sab-factory.com:38038/", "https://parsifal-test.sab-factory.com:38041/", "https://parsifal-test.sab-factory.com:38045/"), TestCategory("SmokeTesting")]

        public void Check_out_Alarm_SC_13926(string login_URL, string Alarms_URL, string Socket_URL)
        {
            Save_Language();
            Thread.Sleep(2000);
            Set_config(login_URL, Alarms_URL, Socket_URL);
            Thread.Sleep(2000);
            login();
            Thread.Sleep(3000);
            CheckoutAlarm();
            Thread.Sleep(1000);
            Mobiledriver.Screenshot();
            Assert.IsTrue((btn_Escalate).Displayed);

        }
        [DataTestMethod]
        [DataRow("https://parsifal-test.sab-factory.com:38038/", "https://parsifal-test.sab-factory.com:38041/", "https://parsifal-test.sab-factory.com:38045/")]
        public void Acknoweledge_Alarm_30099(string login_URL, string Alarms_URL, string Socket_URL)
        {
            Save_Language();
            Thread.Sleep(2000);
            Set_config(login_URL, Alarms_URL, Socket_URL);
            Thread.Sleep(2000);
            login();
            Thread.Sleep(3000);
            CheckoutAlarm();
            btn_Acknowelege.Click();
            Thread.Sleep(1000);
            btn_Save.Click();
            Thread.Sleep(1000);
            btn_Save.Click();
            Mobiledriver.Screenshot();
            Assert.IsTrue((Show_all_card).Displayed);
        }

        [TestMethod]
        [DataRow("https://parsifal-test.sab-factory.com:38038/", "https://parsifal-test.sab-factory.com:38041/", "https://parsifal-test.sab-factory.com:38045/"), TestCategory("SmokeTesting")]
        public void False_Alarm_30103(string login_URL, string Alarms_URL, string Socket_URL)
        {
            Save_Language();
            Thread.Sleep(2000);
            Set_config(login_URL, Alarms_URL, Socket_URL);
            Thread.Sleep(2000);
            login();
            Thread.Sleep(3000);
            CheckoutAlarm();
            btn_False.Click();
            Thread.Sleep(1000);
            btn_Save.Click();
            Thread.Sleep(1000);
            btn_Save.Click();
            Mobiledriver.Screenshot();
            Assert.IsTrue((Show_all_card).Displayed);
        }

        [DataTestMethod]
        [DataRow("https://parsifal-test.sab-factory.com:38038/", "https://parsifal-test.sab-factory.com:38041/", "https://parsifal-test.sab-factory.com:38045/"), TestCategory("SmokeTesting")]
        public void Ignore_Alarm_30106(string login_URL, string Alarms_URL, string Socket_URL)
        {
            Save_Language();
            Thread.Sleep(2000);
            Set_config(login_URL, Alarms_URL, Socket_URL);
            Thread.Sleep(2000);
            login();
            Thread.Sleep(3000);
            CheckoutAlarm();
            btn_Ignore.Click();
            //btn_Ignore_reason.Click();
            Thread.Sleep(1000);
            btn_Save.Click();
            Thread.Sleep(1000);
            btn_Save.Click();
            Mobiledriver.Screenshot();
            Assert.IsTrue((Show_all_card).Displayed);

        }

        [DataTestMethod]
        [DataRow("https://parsifal-test.sab-factory.com:38038/", "https://parsifal-test.sab-factory.com:38041/", "https://parsifal-test.sab-factory.com:38045/"), TestCategory("SmokeTesting")]

        public void Escalate_Alarm_26351(string login_URL, string Alarms_URL, string Socket_URL)
        {
            Save_Language();
            Thread.Sleep(2000);
            Set_config(login_URL, Alarms_URL, Socket_URL);
            Thread.Sleep(2000);
            login();
            Thread.Sleep(3000);
            CheckoutAlarm();
            btn_Escalate.Click();
            Thread.Sleep(1000);
            btn_select_group.Click();
            Thread.Sleep(1000);
            btn_Escalate.Click();
            Thread.Sleep(1000);
            btn_Yes.Click();
            Thread.Sleep(1000);
            Mobiledriver.Screenshot();
            Assert.IsTrue((Escalated_to_others_card).Displayed);
        }


        [DataTestMethod]
        [DataRow("https://parsifal-test.sab-factory.com:38038/", "https://parsifal-test.sab-factory.com:38041/", "https://parsifal-test.sab-factory.com:38045/"), TestCategory("SmokeTesting")]
        public void Delegate_Alarm_26382(string login_URL, string Alarms_URL, string Socket_URL)
        {
            Save_Language();
            Thread.Sleep(2000);
            Set_config(login_URL, Alarms_URL, Socket_URL);
            Thread.Sleep(2000);
            login();
            Thread.Sleep(3000);
            CheckoutAlarm();
            btn_Delegate.Click();
            Thread.Sleep(1000);
            btn_select_group_delegate.Click();
            Thread.Sleep(1000);
            btn_Delegate.Click();
            Thread.Sleep(1000);
            btn_Yes.Click();
            Thread.Sleep(1000);
            Mobiledriver.Screenshot();
            Assert.IsTrue((Delegated_to_others_card).Displayed);
        }

        [TestMethod]
        [DataRow("https://parsifal-test.sab-factory.com:38038/", "https://parsifal-test.sab-factory.com:38041/", "https://parsifal-test.sab-factory.com:38045/"), TestCategory("SmokeTesting")]
        public void Add_note_30101(string login_URL, string Alarms_URL, string Socket_URL)
        {
            Save_Language();
            Thread.Sleep(2000);
            Set_config(login_URL, Alarms_URL, Socket_URL);
            Thread.Sleep(2000);
            login();
            Thread.Sleep(3000);
            CheckoutAlarm();
            Thread.Sleep(2000);
            btn_Add_Note.Click();
            Thread.Sleep(1000);
            btn_Add_comment.Click();
            btn_Add_comment.SendKeys("Add comment");
            Thread.Sleep(1000);
            btn_Save.Click();
            Mobiledriver.Screenshot();
            Assert.IsTrue((Alarm_details_title).Displayed);
        }

        [TestCleanup]
        public void Cleanup()
        {
            MobileDriverDispose(MobileCloseDriver);

        }
    }
}
