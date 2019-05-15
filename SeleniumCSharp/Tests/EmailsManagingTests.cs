﻿using NUnit.Framework;
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
            loginPage.LogOut();
        }

        [Test]
        public void EditEmailAllFields()
        {
            LoginPage loginPage = new LoginPage();
            EmailManagePage emailManagePage = loginPage.Login(ConfigurationManager.AppSettings["login"], ConfigurationManager.AppSettings["password"]);
            emailManagePage.EditDraftdEmail(emailManagePage.editText);
            loginPage.LogOut();
        }
       

        [Test]
        public void VerifySendToAfterEdit()
        {
            LoginPage loginPage = new LoginPage();
            EmailManagePage emailManagePage = loginPage.Login(ConfigurationManager.AppSettings["login"], ConfigurationManager.AppSettings["password"]);
            emailManagePage.VerifySendToFieldAfterEdit();
            loginPage.LogOut();
        }

        [Test]
        public void VerifySubjectAfterEdit()
        {
            LoginPage loginPage = new LoginPage();
            EmailManagePage emailManagePage = loginPage.Login(ConfigurationManager.AppSettings["login"], ConfigurationManager.AppSettings["password"]);
            emailManagePage.VerifySubjectFieldAfterEdit();
            loginPage.LogOut();
        }

        [Test]
        public void VerifyBodyAfterEdit()
        {
            LoginPage loginPage = new LoginPage();
            EmailManagePage emailManagePage = loginPage.Login(ConfigurationManager.AppSettings["login"], ConfigurationManager.AppSettings["password"]);
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
            BrowserFactory.Driver.Quit();
        }

    }
}
