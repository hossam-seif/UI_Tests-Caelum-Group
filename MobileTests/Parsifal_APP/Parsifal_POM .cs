
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Android;
using System.Linq;
using TestFramework;

namespace Mobile_Tests
{

    public class Parsifal_POM : FrameworkBase


    {
        public Parsifal_POM() { }

        #region POM login file
        public IWebElement btn_Save => Mobiledriver.FindElementsByXPath("//*[@content-desc='Save']").FirstOrDefault();
        public IWebElement txt_Login_Service_URL => Mobiledriver.FindElementsByXPath("(//*[@class='android.view.View' and ./parent::*[@class='android.view.View' and ./parent::*[@class='android.view.View' and ./parent::*[@class='android.view.View' and ./parent::*[@class='android.view.View' and ./parent::*[@class='android.view.View']]]]]]/*[@class='android.widget.EditText'])[1]").FirstOrDefault();
        public IWebElement txt_Alarms_Service_URL => Mobiledriver.FindElementsByXPath("(//*[@class='android.view.View' and ./parent::*[@class='android.view.View' and ./parent::*[@class='android.view.View' and ./parent::*[@class='android.view.View' and ./parent::*[@class='android.view.View' and ./parent::*[@class='android.view.View']]]]]]/*[@class='android.widget.EditText'])[2]").FirstOrDefault();
        public IWebElement txt_Socket_Service_URL => Mobiledriver.FindElementsByXPath("(//*[@class='android.view.View' and ./parent::*[@class='android.view.View' and ./parent::*[@class='android.view.View' and ./parent::*[@class='android.view.View' and ./parent::*[@class='android.view.View' and ./parent::*[@class='android.view.View']]]]]]/*[@class='android.widget.EditText'])[3]").FirstOrDefault();
        public IWebElement btn_Alarms_module => Mobiledriver.FindElementsByXPath("//*[@content-desc='Alarms']").FirstOrDefault();
        public IWebElement btn_Quick_Action => Mobiledriver.FindElementsByXPath("(//*[contains(@content-desc,New)]/*[@class='android.widget.ImageView'])[2]").FirstOrDefault();
        public AndroidElement btn_Alarm_Card => Mobiledriver.FindElementsByXPath("//*[contains(@content-desc, 'New')]").FirstOrDefault();
        public AndroidElement btn_select_group => Mobiledriver.FindElementsByXPath("//*[@class='android.widget.ImageView' and ./parent::*[@content-desc='ManualAlarm']]").FirstOrDefault();
        public AndroidElement btn_select_group_delegate => Mobiledriver.FindElementsByXPath("//*[@class='android.widget.ImageView' and ./parent::*[@content-desc='AllRoles']]").FirstOrDefault();
        public AndroidElement Checked_out_card => Mobiledriver.FindElementsByXPath("//*[contains(@content-desc, 'Checked out by Me')]").FirstOrDefault();
        public AndroidElement Delegated_to_others_card => Mobiledriver.FindElementsByXPath("//*[contains(@content-desc, 'Delegated to Others')]").FirstOrDefault();
        public AndroidElement Escalated_to_others_card => Mobiledriver.FindElementsByXPath("//*[contains(@content-desc, 'Escalated to Others')]").FirstOrDefault();
        public AndroidElement Show_all_card => Mobiledriver.FindElementsByXPath("//*[contains(@content-desc, 'Show All')]").FirstOrDefault();
        public AndroidElement Alarm_details_title => Mobiledriver.FindElementsByXPath("//*[@content-desc='Alarm Details']").FirstOrDefault();



        // Actions button 
        public IWebElement btn_Checkout => Mobiledriver.FindElementsByXPath("//*[@content-desc='Check out']").FirstOrDefault();
        public IWebElement btn_Yes => Mobiledriver.FindElementsByXPath("//*[@content-desc='Yes']").FirstOrDefault();

        public IWebElement btn_Acknowelege => Mobiledriver.FindElementsByXPath("//*[@content-desc='Acknowledge']").FirstOrDefault();
        public IWebElement btn_False => Mobiledriver.FindElementsByXPath("//*[@content-desc='False']").FirstOrDefault();
        public IWebElement btn_Ignore => Mobiledriver.FindElementsByXPath("//*[@content-desc='Ignore']").FirstOrDefault();
        public IWebElement btn_Ignore_reason => Mobiledriver.FindElementsByXPath("//*[Contains(@content-desc, 'handling')]").FirstOrDefault();

        public IWebElement btn_Escalate => Mobiledriver.FindElementsByXPath("//*[@content-desc='Escalate']").FirstOrDefault();
        public IWebElement btn_Delegate => Mobiledriver.FindElementsByXPath("//*[@content-desc='Delegate']").FirstOrDefault();
        public IWebElement btn_Add_Note => Mobiledriver.FindElementsByXPath("//*[@content-desc='Note']").FirstOrDefault();
        public IWebElement btn_Add_comment => Mobiledriver.FindElementsByXPath("//*[@class='android.widget.EditText']").FirstOrDefault();
        
        // login Elements 
        public AndroidElement txt_User_Name => Mobiledriver.FindElementsByXPath("(//*[contains(@content-desc, 'V')]/*/*[@class='android.widget.EditText'])[1]").FirstOrDefault();
        public AndroidElement txt_Password => Mobiledriver.FindElementsByXPath("//*[@class='android.widget.EditText' and ./*[@class='android.view.View']]").FirstOrDefault();
        public AndroidElement btn_login => Mobiledriver.FindElementsByXPath("//*[@content-desc='Login']").FirstOrDefault();
        
        #endregion


    }
}

