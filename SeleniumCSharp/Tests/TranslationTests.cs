using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;
using System.Collections.ObjectModel;
using System.Linq;
using SeleniumCSharp.WrapperFactory;
using System.Configuration;
using NUnit.Framework.Interfaces;
using System.Text.RegularExpressions;

namespace SeleniumCSharp.Tests
{
    class TranslationTests
    {
     
        [OneTimeSetUp]
            public void Before()
            {
                BrowserFactory.InitBrowser(ConfigurationManager.AppSettings["browser"]);
                BrowserFactory.Driver.Manage().Window.Maximize();


        }
            [SetUp]
            public void BeforeEachTests()
            {

            }

        [TestCase("cat", "en", "de",  ExpectedResult = "Katz")]
        [TestCase("dog", "en", "de", ExpectedResult = "Hund")]
        [TestCase("Katze", "de", "fr", ExpectedResult = "chat")]
        [TestCase("Hund", "de", "fr", ExpectedResult = "chien")]
        [TestCase("cat", "en", "fr", ExpectedResult = "chatte(feminine)")]
        [TestCase("dog", "en", "fr", ExpectedResult = "chienne(feminine)")]
        public string Translation(string text, string from, string to)
        {
            Translation translation = new Translation();
            return translation.Translate(text, from, to);
        }      

      
            [TearDown]
            public void AfterTest( )
            {
               if (TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Failed)
               {
                    CustomMethods.MakeScreenshot(ConfigurationManager.AppSettings["filePath"]);                  
               }
            }

            [OneTimeTearDown]
            public void AfterTests()
            {

            BrowserFactory.Driver.Quit();

            }

        }


    }





