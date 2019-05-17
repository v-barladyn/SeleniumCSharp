using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumCSharp.WrapperFactory;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
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

        public static void WaitUntilFileDownloaded(string filePath, string fileName)
        {
            var downloadsPath = filePath + fileName;
            for (var i = 0; i < 30; i++)
            {
                if (File.Exists(downloadsPath)) { break; }
                Thread.Sleep(1000);
            }
            var length = new FileInfo(downloadsPath).Length;
            for (var i = 0; i < 30; i++)
            {
                Thread.Sleep(1000);
                var newLength = new FileInfo(downloadsPath).Length;
                if (newLength == length && length != 0) { break; }
                length = newLength;
            }
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

        public static void UploadFile(IWebElement element, string filePath, string fileName)              
        {            
            element.SendKeys(filePath + fileName);
        }




    }
}
