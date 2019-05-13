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
    class EmailsManagingTests
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
            CustomMethods.OpenSite("https://www.i.ua/");
        }

        [Test]
        public void CreateNewEmail()
        {
            LoginPage loginPage = new LoginPage();
            EmailManagePage emailManagePage = loginPage.Login(loginPage.myLogin, loginPage.myPassword);           
            emailManagePage.CreateNewLetter(emailManagePage.sendTo, emailManagePage.subject, emailManagePage.emailText);
            loginPage.LogOut();
        }

        [Test]
        public void EditEmailAllFields()
        {
            LoginPage loginPage = new LoginPage();
            EmailManagePage emailManagePage = loginPage.Login(loginPage.myLogin, loginPage.myPassword);
            emailManagePage.EditDraftdEmail(emailManagePage.editText);
            loginPage.LogOut();
        }
       

        [Test]
        public void VerifySendToAfterEdit()
        {
            LoginPage loginPage = new LoginPage();
            EmailManagePage emailManagePage = loginPage.Login(loginPage.myLogin, loginPage.myPassword);
            emailManagePage.VerifySendToFieldAfterEdit();
            loginPage.LogOut();
        }

        [Test]
        public void VerifySubjectAfterEdit()
        {
            LoginPage loginPage = new LoginPage();
            EmailManagePage emailManagePage = loginPage.Login(loginPage.myLogin, loginPage.myPassword);
            emailManagePage.VerifySubjectFieldAfterEdit();
            loginPage.LogOut();
        }

        [Test]
        public void VerifyBodyAfterEdit()
        {
            LoginPage loginPage = new LoginPage();
            EmailManagePage emailManagePage = loginPage.Login(loginPage.myLogin, loginPage.myPassword);
            emailManagePage.VerifyBodyFieldAfterEdit();
            loginPage.LogOut();
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
