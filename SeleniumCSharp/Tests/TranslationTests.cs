using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;
using System.Collections.ObjectModel;
using System.Linq;

namespace SeleniumCSharp.Tests
{
    class TranslationTests
    { 
       

            [OneTimeSetUp]
            public void Before()
            {
                InstanceOfDriver.driver = new ChromeDriver();
                InstanceOfDriver.driver.Manage().Window.Maximize();


            }
            [SetUp]
            public void BeforeEachTests()
            {

            }

          

            [TestCase("cat", ExpectedResult = "Katze")]
            [TestCase("dog", ExpectedResult = "Hund")]
            public string TranslateEnToGerTest(string text)
            {
                Translation translation = new Translation();
                return translation.Translate(text, translation.enToDeURL);
            }



            [TestCase("Katze", ExpectedResult = "chat")]
            [TestCase("Hund", ExpectedResult = "chien")]
            public string TranslateDeToFRTest(string text)
            {
                Translation translation = new Translation();
                return translation.Translate(text, translation.deToFrURL);
            }


            [TestCase("cat", ExpectedResult = "chatte(feminine)")]
            [TestCase("dog", ExpectedResult = "chienne(feminine)")]
            public string TranslateEnToFRTest(string text)
            {
                Translation translation = new Translation();
                return translation.Translate(text, translation.enToFrURL);
            }

            [TearDown]
            public void AfterTest()
            {

            }

            [OneTimeTearDown]
            public void AfterTests()
            {
                InstanceOfDriver.driver.Quit();
            }

        }


    }





