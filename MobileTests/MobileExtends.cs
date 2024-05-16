using OpenQA.Selenium;
using System.Collections.Generic;
using TestFramework;

namespace Mobile_Tests
{
    public static partial class ExtensionMethods
    {
        /// <summary>
        /// extensions Fun() for elements to send data not null. 
        /// </summary>
        /// <param name="_element">this * iwebelement to extend.</param>
        /// <param name="value"> value that will set to element.</param>
        /// <param name="clear">bool to clear item before use.</param>
        public static void SetText(this IWebElement _element, string value, bool clear = false)
        {
            FrameworkExtendMethods.SendText(_element, value, clear);
        }

        /// <summary>
        /// extensions Fun() for elements to Click when element not null. 
        /// </summary>
        /// <param name="_element">this * iwebelement to extend </param>
        /// <param name="count">count of number of clicks by default 1</param>
        public static void Clicks(this IWebElement _element, int count = 1)
        {
            FrameworkExtendMethods.ClickAction(_element, count);
        }

        public static void Clicks(this IReadOnlyCollection<IWebElement> _element, string _value, int _count = 1)
        {
            FrameworkExtendMethods.ClickAction(_element, _value, _count);
        }

        /// <summary>
        /// FUN () to Scroll to element In page
        /// </summary>
        /// <param name="_driver">* this driver have elements</param>
        /// <param name="_element">element that scroll to it.</param>
        /// <param name="click">bool to click on item after scroll to it ( false = not click , true = click )</param>
        public static void ScrollTo(this IWebElement _element, bool click = false)
        {
            FrameworkExtendMethods.ScrollinTo(_element, click);
        }

        /// <summary>
        /// FUN () to take a Screenshot of browser page in png extention 
        /// </summary>
        /// <param name="_driver">* driver </param>
        /// <param name="_filename"> file name of screenshot by default 'Screenshot' </param>
        /// <param name="_path"> set path of to save screenshot, by default value get from Envrionment file </param>
        public static void Screenshot(this IWebDriver _driver, string _path = "",
            string _filename = "Screenshot")
        {

            FrameworkExtendMethods.DriverScreenshot(_driver,
                string.IsNullOrWhiteSpace(_path) ? FrameworkBase.Globalscreenshootpath : _path, _filename);
        }

        /// Virtual FUN() to Check Validation Message 
        /// case return null   : There is no message at function argument or element is null
        /// case return true   : message displayed was equal to message argument
        /// case return false  : message is not null and message not equal to message displayed 
        /// </summary>
        /// <param name = "element" > Element that will use to check validation</param>
        /// <param name = "message" > Syntax of Validation Message</param>
        /// <returns>Function return Boolean? value</returns>
        public static bool? CheckValidation(this IWebElement _element, string message)
        {
            return FrameworkExtendMethods.CheckStyleValidation(_element, message);
        }


        /// <summary>
        /// check if value is exist in a grid table
        /// </summary>
        /// <param name="_element">Iwebelement of element</param>
        /// <param name="_tagname"> Xpath that contain element value in table </param>
        /// <param name="_value"> Value that need to search in table</param>
        static public bool? Checkvalueontable(this IWebElement _element, string _tagname, string _value)
        {
            return FrameworkExtendMethods.CheckValueinTable(_element, _tagname, _value);
        }

        /// <summary>
        /// extensions Fun() for elements to Submit when element not null. 
        /// </summary>
        /// <param name="_element">this * iwebelement to extend  </param>
        public static void Submits(this IWebElement _element)
        {
            FrameworkExtendMethods.SubmitAction(_element);
        }

        /// <summary>
        /// extensions FUN() for item will select in element type select by text value.
        /// </summary>
        /// <param name="_element">Element That have Drop down list </param>
        /// <param name="value">value that will be use to select item is case sensitive</param>
        /// <param name ="partialMatch">Default value is false. If true a partial match on the Options list will be performed,otherwise exact match.</param>
        public static void DDLbyText(this IWebElement _element, string value, bool _partialMatch = false,
            FrameworkExtendMethods.SelectorType _selectorType = FrameworkExtendMethods.SelectorType.select,
            string _classname = "", string _tagname = "a")
        {
            FrameworkExtendMethods.SelectfromDDLbyText(_element, value, _partialMatch, _selectorType, _classname,
                _tagname);
        }

        /// <summary>
        /// FUN() to upload file 
        /// </summary>
        /// <param name="_path"> absolute file path</param>
        public static void Uploadfile(this IWebElement _element, string _path = "")
        {
            FrameworkExtendMethods.UploadfileStream(_element,
                string.IsNullOrWhiteSpace(_path) ? FrameworkBase.Globalexportpath : _path);
        }

        /// <summary>
        /// Authenticate users by using their finger print scans on supported emulators.
        /// </summary>
        /// <param name="androidDriver">ref:Android Driver</param>
        /// <param name="finger">finger prints stored in Android Keystore system (from 1 to 10)</param>
        public static void AccessbyFingerPrint(this OpenQA.Selenium.Appium.Android.AndroidDriver<OpenQA.Selenium.Appium.Android.AndroidElement> androidDriver, int finger = 1)
        {
            FrameworkExtendMethods.AndroidFingerPrint(ref androidDriver, finger);
        }
    }

}
