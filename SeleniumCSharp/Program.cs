using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumCSharp
{
    class Program
    {
        static void Main(string[] args)
        {
           
        }

        [Test]
        public void CompareTitle()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.i.ua/");

            string title = "І.UA - твоя пошта";


            Assert.AreEqual(title, driver.Title.Trim());
            driver.Close();
        }
    }
}
