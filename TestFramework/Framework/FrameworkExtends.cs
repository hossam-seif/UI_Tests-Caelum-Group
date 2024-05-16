using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Windows.Forms;

namespace TestFramework
{
    public partial class FrameworkExtendMethods
    {
        internal static TestContext _TestContext { get; set; }
        public static object ScreenshotImageFormat { get; private set; }

        /// <summary>
        ///  Fun() for elements to send data not null. 
        /// </summary>
        /// <param name="_element">this * iwebelement to extend.</param>
        /// <param name="value"> value that will set to element.</param>
        /// <param name="clear">bool to clear item before use.</param>
        public static void SendText(IWebElement _element, string value, bool clear = false)
        {
            try
            {
                if (_element != null)
                {
                    if (string.IsNullOrEmpty(value))
                    { if (FrameworkBase._logger != null) FrameworkBase._logger.Print("[Warning] [SetText Method] : value is Null or Empty "); }//Frameworkbase._logger.Print("! Warning: value is Null in SetText Methods."); }
                    else
                    {
                        if (clear == true)
                        {
                            _element.Clear();
                            if (FrameworkBase._logger != null) FrameworkBase._logger.Print("[Information] [SetText Method] : element Text " + nameof(_element) + " is cleared. ");
                        }
                        _element.SendKeys(value);
                        if (FrameworkBase._logger != null) FrameworkBase._logger.Print("[Information] [SetText Method] : value is (" + value + ") , element is " + nameof(_element) + " . ");
                    }
                }
                else
                {
                    if (FrameworkBase._logger != null) FrameworkBase._logger.Print("[Error] [SetText Method] : " + nameof(_element) + " is Null and value is (" + value + ") .");
                }
            }
            catch (Exception ex)
            {
                if (FrameworkBase._logger != null) FrameworkBase._logger.Print("[Exception] [SetText Method] : Message:\n" + ex.Message);
                Microsoft.VisualStudio.TestTools.UnitTesting.Assert.Fail("[SetText] Unexpected behavior occurred : " + ex.Message);

            }
        }

        ///// <summary>
        ///// Fun() for elements to Click when element not null. 
        ///// </summary>
        ///// <param name="_element">this * iwebelement to extend </param>
        ///// <param name="count">count of number of clicks by default 1</param>
        //public static void ClickAction(IWebElement _element, int count = 1)
        //{
        //    try
        //    {
        //        if (_element != null && _element.Displayed)
        //        {
        //            for (int _count = 1; _count <= count; _count++)
        //            {
        //                // _element.ScrollTo(false);
        //                _element.Click();
        //                if (FrameworkBase._logger != null) FrameworkBase._logger.Print("[Information] [Clicks Method] : " + nameof(_element) + " is Displayed and Clicked .");
        //            }
        //        }
        //        else if (_element == null)
        //            if (FrameworkBase._logger != null) FrameworkBase._logger.Print("[Warning] [Clicks Method] : " + nameof(_element) + " is Null .");
        //    }
        //    catch (Exception ex)
        //    {
        //        if (FrameworkBase._logger != null) FrameworkBase._logger.Print("[Exception] [Clicks Method] : Message:\n" + ex.Message);
        //        Assert.Fail("[Clicks] Unexpected behavior occurred : " + ex.Message);
        //    }
        //    finally { System.Threading.Thread.Sleep(500); }
        //}
        /// <summary>
        /// Fun() for elements to Click when element not null. 
        /// </summary>
        /// <param name="_element">this * iwebelement to extend </param>
        /// <param name="count">count of number of clicks by default 1</param>
        public static void ClickAction(IWebElement _element, int count = 1)
        {

            try
            {
                if (_element != null && _element.Displayed)
                {
                    for (int _count = 1; _count <= count; _count++)
                    {
                        // _element.ScrollTo(false);
                        _element.Click();
                        if (FrameworkBase._logger != null) FrameworkBase._logger.Print("[Information] [Clicks Method] : " + nameof(_element) + " is Displayed and Clicked .");
                    }
                }
                else if (_element == null)
                    if (FrameworkBase._logger != null) FrameworkBase._logger.Print("[Warning] [Clicks Method] : " + nameof(_element) + " is Null .");
            }
            catch (Exception ex)
            {
                if (FrameworkBase._logger != null) FrameworkBase._logger.Print("[Exception] [Clicks Method] : Message:\n" + ex.Message);
                Assert.Fail("[Clicks] Unexpected behavior occurred : " + ex.Message);
            }
            finally { System.Threading.Thread.Sleep(500); }
        }
        public static void ClickAction(IReadOnlyCollection<IWebElement> _element, string _value, int _count = 1)
        {
            try
            {
                if (_element != null)
                {
                    if (FrameworkBase._logger != null) FrameworkBase._logger.Print("[Information] [Clicks Method] : Value is " + nameof(_value) + " .");
                    var itemlist = _element.FirstOrDefault(x => x.FindElements(By.XPath("./child::*")).Where(y => y.Text == _value).Count() > 0);
                    var item = itemlist.FindElements(By.XPath("./child::*")).Where(xx => xx.Text == string.Empty).FirstOrDefault();
                    ClickAction(item, _count);
                }
            }
            catch (Exception ex)
            {
                if (FrameworkBase._logger != null) FrameworkBase._logger.Print("[Exception] [Clicks Method] : Message: \n" + ex.Message);
                Assert.Fail("[Clicks] Unexpected behavior occurred : " + ex.Message);
            }
            finally { System.Threading.Thread.Sleep(500); }
        }
        /// <summary>
        /// FUN () to Scroll to element In page
        /// </summary>
        /// <param name="_driver">* this driver have elements</param>
        /// <param name="_element">element that scroll to it.</param>
        /// <param name="click">bool to click on item after scroll to it ( false = not click , true = click )</param>
        public static void ScrollinTo(IWebElement _element, bool click = false)
        {

            if (_element != null && FrameworkBase.IWebDriver != null)
            {
                IJavaScriptExecutor js = (IJavaScriptExecutor)FrameworkBase.IWebDriver;
                js.ExecuteScript("arguments[0].scrollIntoView(false);", _element);
                if (click == true)
                    ClickAction(_element);
                if (FrameworkBase._logger != null) FrameworkBase._logger.Print("[Information] [ScrollTo Method] : " + nameof(_element) + " is exist.");
            }
            else
            {
                if (FrameworkBase._logger != null) FrameworkBase._logger.Print("[Warning] [ScrollTo Method] : " + nameof(_element) + " is Null.");
            }

        }

        /// <summary>
        /// FUN () to take a Screenshot of browser page in png extention 
        /// </summary>
        /// <param name="_driver">* driver </param>
        /// <param name="_filename"> file name of screenshot by default 'Screenshot' </param>
        /// <param name="_path"> set path of to save screenshot, by default value get from Envrionment file </param>
       // public static void DriverScreenshot(IWebDriver _driver, string _path, string _filename = "Screenshot")
       // {
            //try
           // {
             //   if (_driver != null)
               // {

                 //   Screenshot screenResult = null;
                   // screenResult = ((ITakesScreenshot)_driver).GetScreenshot();
                    //screenResult.SaveAsFile(_path + _filename + System.DateTime.UtcNow.ToString(" yyyy-MM-dd HH-mm-ssfff",
                      //                  System.Globalization.CultureInfo.InvariantCulture) + ".png", ScreenshotImageFormat); ;
                    //if (FrameworkBase._logger != null) FrameworkBase._logger.Print("[Information] [ScrollTo Method] : " + nameof(_driver) + " is exist, and screenshot path is " + _path + " .");
                //}
                //else
                //{
                  //  if (FrameworkBase._logger != null) FrameworkBase._logger.Print("[Warning] [Screenshot Method] : " + nameof(_driver) + " is Null.");
                //}
            //}
            //catch (Exception ex)
            //{
              //  if (FrameworkBase._logger != null) FrameworkBase._logger.Print("[Screenshot] Unexpected behavior occurred : " + ex.Message);
          //  }
        //}

        /// Virtual FUN() to Check Validation Message 
        /// case return null   : There is no message at function argument or element is null
        /// case return true   : message displayed was equal to message argument
        /// case return false  : message is not null and message not equal to message displayed 
        /// </summary>
        /// <param name = "element" > Element that will use to check validation</param>
        /// <param name = "message" > Syntax of Validation Message</param>
        /// <returns>Function return Boolean? value</returns>
        public static bool? CheckStyleValidation(IWebElement _element, string message)
        {
            try
            {
                //DefaultWait<IWebDriver> fluentWait = new DefaultWait<IWebDriver>(Frameworkbase.driver)
                //{
                //    Timeout = TimeSpan.FromSeconds(30),
                //    PollingInterval = TimeSpan.FromMilliseconds(250)
                //};
                ///* Ignore the exception - NoSuchElementException that indicates that the element is not present */
                //fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
                //fluentWait.Message = "Element to be searched not found";
                //IWebElement searchResult = fluentWait.Until(x=>_element);

                if (_element != null)
                {
                    if (message == null)
                    {
                        if (FrameworkBase._logger != null) FrameworkBase._logger.Print("[Information] [CheckValidation Method] : message " + nameof(_element) + " is Null.");
                        return null;
                    }
                    else if (message == _element.Text)
                    {
                        if (FrameworkBase._logger != null) FrameworkBase._logger.Print("[Information] [CheckValidation Method] : message is (" + message + ") and matching element text (" + _element.Text + ").");
                        return true;
                    }
                    else if (message != _element.Text && message != null)
                    {
                        if (FrameworkBase._logger != null) FrameworkBase._logger.Print("[Information] [CheckValidation Method] : message is (" + message + ") is not matching element text(" + _element.Text + ").");
                        return false;
                    }
                    return null;
                }
                else
                {
                    if (FrameworkBase._logger != null) FrameworkBase._logger.Print("[Warning] [CheckValidation Method] : _element is Null");
                    return false;
                }
            }
            catch (NoSuchElementException ex)
            {
                if (FrameworkBase._logger != null) FrameworkBase._logger.Print("[CheckValidation] [NoSuchElementException] Unexpected behavior occurred : " + ex.Message);
                return false;
            }
            catch (StaleElementReferenceException ex)
            {
                if (FrameworkBase._logger != null) FrameworkBase._logger.Print("[CheckValidation] [StaleElementReferenceException] Unexpected behavior occurred : " + ex.Message);
                return false;
            }
        }


        /// <summary>
        /// check if value is exist in a grid table
        /// </summary>
        /// <param name="_element">Iwebelement of element</param>
        /// <param name="_tagname"> Xpath that contain element value in table </param>
        /// <param name="_value"> Value that need to search in table</param>
        static public bool? CheckValueinTable(IWebElement _element, string _tagname, string _value)
        {
            try
            {
                if (_element != null)
                {
                    //Get all the colums from the table by Xpath
                    var columns = _element.FindElements(By.XPath(_tagname)); //      //div[contains(@class,'TableCell_valueName__')]||$x("//div[@class='TableCell_valueName__3iiOM']")
                    bool? _check = null;

                    var _res = columns.FirstOrDefault(x => (bool)((x != null) && x.Text == _value ? _check = true : _check = false));
                    if (FrameworkBase._logger != null) FrameworkBase._logger.Print("[Information] [Checkvalueontable Method] : value is (" + _value + ") , container (" + _tagname + ").");
                    return _check;
                }
                if (FrameworkBase._logger != null) FrameworkBase._logger.Print("[Warning] [Checkvalueontable Method] : element is null and value is (" + _value + ") , container (" + _tagname + ").");
                return null;
            }
            catch (Exception ex)
            {
                if (FrameworkBase._logger != null) FrameworkBase._logger.Print("[Checkvalueontable] Unexpected behavior occurred : " + ex.Message);
                return null;
            }
        }

        /// <summary>
        /// extensions Fun() for elements to Submit when element not null. 
        /// </summary>
        /// <param name="_element">this * iwebelement to extend  </param>
        public static void SubmitAction(IWebElement _element)
        {
            if (_element != null)
            {
                _element.Submit();
                if (FrameworkBase._logger != null) FrameworkBase._logger.Print("[Information] [Submits Method] : element is exist .");
            }
            else if (_element == null)
                if (FrameworkBase._logger != null) FrameworkBase._logger.Print("[Warning] [Submits Method] : element is Null .");
        }

        /// <summary>
        /// extensions FUN() for item will select in element type select by text value.
        /// </summary>
        /// <param name="_element">Element That have Drop down list </param>
        /// <param name="value">value that will be use to select item is case sensitive</param>
        /// <param name ="partialMatch">Default value is false. If true a partial match on the Options list will be performed,otherwise exact match.</param>
        public static void SelectfromDDLbyText(IWebElement _element, string value, bool _partialMatch = false, SelectorType _selectorType = SelectorType.select, string _classname = "", string _tagname = "a")
        {
            //******************************************
            // Here wount to check value first in list
            //******************************************
            if (_selectorType == SelectorType.select)
            {
                if (_element != null && value != null)
                {
                    new SelectElement(_element).SelectByText(value, _partialMatch);
                    if (FrameworkBase._logger != null) FrameworkBase._logger.Print("[Information] [DDLbyText Method] : \n " + value + " is selected and clicked, partial value match option is " + _partialMatch);
                }
                else
               if (FrameworkBase._logger != null) FrameworkBase._logger.Print("[Warning] [DDLbyText Method] : element is Null .");
            }
            else if (_selectorType == SelectorType.div)
            {
                try
                {
                    if (_element != null)
                    {
                        //Get all the colums from the table by Xpath
                        var columns = _element.FindElements(By.XPath(_classname)); //      //div[contains(@class,'TableCell_valueName__')] || $x("//div[@class='TableCell_valueName__3iiOM']")

                        if (_partialMatch == false)
                        {
                            var _res = columns.FirstOrDefault(x => (bool)((x != null) && x.TagName == _tagname && x.Text == value));
                            ClickAction(_res);
                        }
                        else if (_partialMatch == true)
                        {
                            var _res = columns.FirstOrDefault(x => (bool)((x != null) && x.TagName == _tagname && x.Text.Contains(value)));
                            ClickAction(_res);
                        }

                        if (FrameworkBase._logger != null) FrameworkBase._logger.Print("[Information] [DDLbyText Method] : \n " + value + " is selected and clicked, partial value match option is " + _partialMatch);

                    }
                    if (FrameworkBase._logger != null) FrameworkBase._logger.Print("[Warning] [DDLbyText Method] : element is Null .");

                }
                catch (Exception ex)
                {
                    if (FrameworkBase._logger != null) FrameworkBase._logger.Print("[DDLbyText] Unexpected behavior occurred : " + ex.Message);

                }
            }
        }
        /// <summary>
        /// FUN() to upload file 
        /// </summary>
        /// <param name="_path"> absolute file path</param>
        public static void UploadfileStream(IWebElement _element, string _path)
        {
            try
            {
                if (!string.IsNullOrEmpty(_path) || _element == null)
                {

                    ClickAction(_element);
                    System.Threading.Thread.Sleep(2000);
                    SendKeys.SendWait(_path);

                    //Click Enter Key to submit
                    SendKeys.SendWait(@"{Enter}");
                    if (FrameworkBase._logger != null) FrameworkBase._logger.Print("[base] [Information] [Uploadfile Method] : Upload file path" + _path + " .");
                }
                else
                if (FrameworkBase._logger != null) FrameworkBase._logger.Print("[base] [Warning] [Uploadfile Method] : Upload file path " + _path + " or Element " + _element.Location.IsEmpty + " is null");
            }
            catch (Exception ex)
            {
                if (FrameworkBase._logger != null) FrameworkBase._logger.Print("[base] [Uploadfile] Unexpected behavior occurred : " + ex.Message);
            }
        }

        /// <summary>
        /// Authenticate users by using their finger print scans on supported emulators.
        /// </summary>
        /// <param name="androidDriver">ref:Android Driver</param>
        /// <param name="finger">finger prints stored in Android Keystore system (from 1 to 10)</param>
        //public static void AndroidFingerPrint(ref OpenQA.Selenium.Appium.Android.AndroidDriver<OpenQA.Selenium.Appium.Android.AndroidElement> androidDriver, int finger = 1)
        //{
          //  try
           // {
               // ((OpenQA.Selenium.Appium.Android.AndroidDriver<OpenQA.Selenium.Appium.Android.AndroidElement>)androidDriver).FingerPrint(finger);

               // if (FrameworkBase._logger != null) FrameworkBase._logger.Print("[base] [Information] [FingerPrint Method] : Finger Print pass with touch option #(" + finger + ") .");
            //}
            //catch (Exception ex)
           // {
               // if (FrameworkBase._logger != null) FrameworkBase._logger.Print("[base] [FingerPrint Method] Unexpected behavior occurred : " + ex.Message);
            //}

        }

        /// <summary>
        /// Method used for POST data
        /// </summary>
        /// <param name="baseurl">base url</param>
        /// <param name="endpointpath">endpoint base url</param>
        /// <param name="mediatype"> encoding body media type</param>
        /// <param name="Requestbody">string that include request body</param>
        /// <param name="RequestHeaders">string[] that include header pair key,value</param>
        /// <returns></returns>
       // public static JObject POSTRequest(string baseurl, string endpointpath,
                                             //    string mediatype, string Requestbody, params string[] RequestHeaders)
       // {
            //FrameworkBase._logger?.Print("[Information] [POSTAsync] Called by test method name: " + _TestContext.TestName);
           // FrameworkBase._logger?.Print("[Information] [POSTAsync] Base URL: " + baseurl);
          //  FrameworkBase._logger?.Print("[Information] [POSTAsync] Endpoint Path: " + endpointpath);
          //  var client = new HttpClient();
          //  var data = new StringContent(Requestbody, Encoding.UTF8, mediatype);

           // for (int i = 0; i < RequestHeaders.Length; i++)
           // {
            //    if (i % 2 == 0)
                 //   if (RequestHeaders[i] != "Authorization" && RequestHeaders[i + 1] != "" ||
                   //     RequestHeaders[i] == "Authorization" && RequestHeaders[i + 1] != "")
                    //{
                     //   client.DefaultRequestHeaders.Add(RequestHeaders[i], RequestHeaders[i + 1]);
                       // FrameworkBase._logger?.Print("[Information] [POSTAsync] Add header Key: " + RequestHeaders[i] + "\t, value: " + RequestHeaders[i + 1]);
                  //  }
           // }

          //  client.DefaultRequestHeaders.Add("Host", baseurl.Replace("https://", "").ToString());
           // client.DefaultRequestHeaders.TryAddWithoutValidation("Content-Length", data.Headers.ContentLength.ToString());

            //FrameworkBase._logger?.Print("[Information] [POSTAsync] Request Body: \n" + Requestbody);
           // FrameworkBase._logger?.Print("[Information] [POSTAsync] Request Body Media Type : " + mediatype);

          //  var response = client.PostAsync(baseurl + endpointpath, data);
            //var res = response?.Result.Content.ReadAsStringAsync().Result;
            //var res = response.Result.Content;
         // JObject retJObject = JObject.Parse(res);
           // FrameworkBase._logger?.Print("[Information] [POSTAsync] Response Body : " + retJObject);
           // return retJObject;
        }
    

