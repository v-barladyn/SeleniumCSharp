using System;
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
       
        [FindsBy(How = How.Name, Using ="pass")]
        IWebElement passwordInput { get; set; }

        [FindsBy(How = How.Name, Using = "login")]
        IWebElement loginInput { get; set; }
        
        [FindsBy(How = How.CssSelector, Using = @"input[value='Увійти']")]
        IWebElement loginButton { get; set; }

        public string myLogin = "Vasillsa@email.ua";
        public string myPassword = "qwerty123!";


        public EmailManagePage Login(string login,string password)
        {
            loginInput.SendKeys(login);
            passwordInput.SendKeys(password);
            loginButton.Click();

            return new EmailManagePage();

        }
           
            

           
    }
}
