using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumCSharp
{
    class CustomMethods
    {
        public static void WaitForElement(string xpath)
        {
            WebDriverWait wait = new WebDriverWait(InstanceOfDriver.driver, TimeSpan.FromMilliseconds(2000));
            wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(xpath)));
            
        }

        public static void OpenSite(string url)
        {
            InstanceOfDriver.driver.Navigate().GoToUrl(url);
            Assert.AreEqual(url, InstanceOfDriver.driver.Url);
        }

    }
}
