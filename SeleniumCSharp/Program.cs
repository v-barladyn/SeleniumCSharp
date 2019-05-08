using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic; 
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;
using System.Collections.ObjectModel;
using System.Linq;

namespace SeleniumCSharp
{
    class Program
    {
        static void Main(string[] args)
        {

        }    
              
    }
    class Tests
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

        [Test]
        public void CreateNewEmail()
        {
            CustomMethods.OpenSite("https://www.i.ua/");
            LoginPage loginPage = new LoginPage();
            EmailManagePage emailManagePage = loginPage.Login(loginPage.myLogin, loginPage.myPassword);
            emailManagePage.CheckTitleOnThePage(emailManagePage.title);
            emailManagePage.CreateNewLetter(emailManagePage.sendTo, emailManagePage.subject, emailManagePage.emailText);
        }

        [Test]
        public void VerifySubjectAfterEdit()
        {

        }

        public void VerifyBodyAfterEdit()
        {

        }


        [Test]
        public void EditEmailAllFields()
        {
            CustomMethods.OpenSite("https://www.i.ua/");
            LoginPage loginPage = new LoginPage();
            EmailManagePage emailManagePage = loginPage.Login(loginPage.myLogin, loginPage.myPassword);
            emailManagePage.EditDraftdEmail(emailManagePage.editText);
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


