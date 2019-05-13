﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.PageObjects;

namespace SeleniumCSharp
{
    class LoginPage
    {
        public LoginPage()
        {
            PageFactory.InitElements(InstanceOfDriver.driver, this);
        }

        [FindsBy(How = How.Name, Using = "pass")]
        IWebElement PasswordInput;

        [FindsBy(How = How.Name, Using = "login")]
        IWebElement LoginInput;

        [FindsBy(How = How.CssSelector, Using = @"input[value='Увійти']")]
        IWebElement LoginButton;

        [FindsBy(How = How.XPath, Using = "//a[contains(text(),'Вихід')]")]
        IWebElement ExitButton1;

        [FindsBy(How = How.XPath, Using = "//span[@title='Налаштування']")]
        IWebElement SettingButton;

        [FindsBy(How = How.XPath, Using = "//div/ul/li/a[contains(text(),'Вийти')]")]
        IWebElement ExitButton;

        public string myLogin = "Vasillsa@email.ua";
        public string myPassword = "qwerty123!";              
        string titleOfPageAfterExit = "І.UA - твоя пошта";


        public EmailManagePage Login(string login,string password)
        {
            LoginInput.SendKeys(login);
            PasswordInput.SendKeys(password);
            LoginButton.Click();             

            return new EmailManagePage();

        }

        public void LogOut()
        {            
            this.SettingButton.Click();
            CustomMethods.WaitForElement(this.ExitButton);
            this.ExitButton.Click();

            Assert.AreEqual(this.titleOfPageAfterExit, InstanceOfDriver.driver.Title.Trim());
        }

    }
}