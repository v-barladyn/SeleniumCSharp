using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;
using System.Collections.ObjectModel;
using System.Linq;
using System.Configuration;
using SeleniumCSharp.WrapperFactory;
using NUnit.Framework.Interfaces;

namespace SeleniumCSharp.Tests
{
    class EmailsManagingTests
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
            BrowserFactory.LoadApplication(ConfigurationManager.AppSettings["urlForEmail"]);
        }

        [Test]
        public void CreateNewEmail()
        {
            LoginPage loginPage = new LoginPage();
            EmailManagePage emailManagePage = loginPage.Login(ConfigurationManager.AppSettings["login"], ConfigurationManager.AppSettings["password"]);           
            emailManagePage.CreateNewLetter(emailManagePage.sendTo, emailManagePage.subject, emailManagePage.emailText);
            CustomMethods.WaitForElement(emailManagePage.NoticeLetterWasCreated);
            Assert.AreEqual(emailManagePage.emailWasCreated, emailManagePage.NoticeLetterWasCreated.Text.Trim());
            loginPage.LogOut();
        }

        [Test]
        public void EditEmailAllFields()
        {
            LoginPage loginPage = new LoginPage();
            EmailManagePage emailManagePage = loginPage.Login(ConfigurationManager.AppSettings["login"], ConfigurationManager.AppSettings["password"]);
            emailManagePage.EditDraftdEmail(emailManagePage.editText);
            CustomMethods.WaitForElement(emailManagePage.NoticeLetterWasCreated);
            Assert.AreEqual(emailManagePage.emailWasCreated, emailManagePage.NoticeLetterWasCreated.Text.Trim());
            loginPage.LogOut();
        }
       

        [Test]
        public void VerifySendToAfterEdit()
        {
            LoginPage loginPage = new LoginPage();
            EmailManagePage emailManagePage = loginPage.Login(ConfigurationManager.AppSettings["login"], ConfigurationManager.AppSettings["password"]);
            emailManagePage.VerifySendToFieldAfterEdit();
            Assert.AreEqual(emailManagePage.sendTo + emailManagePage.editText, emailManagePage.SendEmailTo.Text.Trim());
            loginPage.LogOut();
        }

        [Test]
        public void VerifySubjectAfterEdit()
        {
            LoginPage loginPage = new LoginPage();
            EmailManagePage emailManagePage = loginPage.Login(ConfigurationManager.AppSettings["login"], ConfigurationManager.AppSettings["password"]);
            emailManagePage.VerifySubjectFieldAfterEdit();
            Assert.AreEqual(emailManagePage.subject + emailManagePage.editText, emailManagePage.SendEmailSubject.GetAttribute("value"));
            loginPage.LogOut();
        }

        [Test]
        public void VerifyBodyAfterEdit()
        {
            LoginPage loginPage = new LoginPage();
            EmailManagePage emailManagePage = loginPage.Login(ConfigurationManager.AppSettings["login"], ConfigurationManager.AppSettings["password"]);
            emailManagePage.VerifyBodyFieldAfterEdit();
            Assert.AreEqual(emailManagePage.emailText + "\r\n" + emailManagePage.editText, emailManagePage.SendEmailBody.Text.Trim());
            loginPage.LogOut();
        }

        [Test]
        public void VerifyFileUploading()
        {
            LoginPage loginPage = new LoginPage();
            EmailManagePage emailManagePage = loginPage.Login(ConfigurationManager.AppSettings["login"], ConfigurationManager.AppSettings["password"]);
            emailManagePage.VerifyFileUploading();
        }

        [Test]
        public void VerifyFileDownloading()
        {
            LoginPage loginPage = new LoginPage();            
            EmailManagePage emailManagePage = loginPage.Login(ConfigurationManager.AppSettings["login"], ConfigurationManager.AppSettings["password"]);
            emailManagePage.VerifyFileDownloading();
        }      

        [TearDown]
        public void AfterTest()
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
