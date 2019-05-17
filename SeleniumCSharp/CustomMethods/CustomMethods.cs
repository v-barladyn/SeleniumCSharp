using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumCSharp.WrapperFactory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumCSharp
{
    class CustomMethods
    {
        public static void WaitForElement(IWebElement elem)
        {           
            WebDriverWait wait = new WebDriverWait(BrowserFactory.Driver, TimeSpan.FromSeconds(3));
            wait.Until(p => elem.Displayed);
        }

        public static void OpenSite(string url)
        {
            BrowserFactory.Driver.Navigate().GoToUrl(url);
            Assert.AreEqual(url, BrowserFactory.Driver.Url);
        }

        public static void MakeScreenshot(string filePath)
        {
            Screenshot ss = ((ITakesScreenshot)BrowserFactory.Driver).GetScreenshot();
            string title = TestContext.CurrentContext.Test.Name.Replace("\"", "_").Replace(',', '_');        
            string screenshotfilename = filePath + title + title + DateTime.Now.ToString("yyyy-MM-dd-HH_mm_ss") + ".jpg";
            ss.SaveAsFile(screenshotfilename, ScreenshotImageFormat.Jpeg);
        }
       

    }
}
