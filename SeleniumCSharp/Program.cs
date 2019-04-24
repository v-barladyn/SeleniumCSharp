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
        IWebDriver driver = new ChromeDriver();

        [OneTimeSetUp]        
        public void Before()
        {
            
            driver.Manage().Window.Maximize();

        }
        [SetUp]
        public void BeforeEachTests()
        {

        }


        //3.1
        [Test]
        public void InsertGetTextFromForm()
        {
            driver.Navigate().GoToUrl("http://the-internet.herokuapp.com/tinymce");
            string text = "Vasillsa@email.ua";          
            driver.SwitchTo().Frame(driver.FindElement(By.Id("mce_0_ifr")));                

            IWebElement element = driver.FindElement(By.XPath("//body[@id='tinymce']"));
            element.Clear();
            element.SendKeys(text);
            Assert.AreEqual(text, element.Text);

            driver.SwitchTo().ParentFrame();
            IWebElement AllignCenter = driver.FindElement(By.XPath("//div[@id='mceu_6']/button/i"));

            AllignCenter.Click();            
        }

        //3.2
        [Test]
        public void DeleteEmail()
        {
            driver.Navigate().GoToUrl("https://www.i.ua/");

            IWebElement passwordInput = driver.FindElement(By.Name("pass"));
            IWebElement loginInput = driver.FindElement(By.Name("login"));
            IWebElement loginButton = driver.FindElement(By.CssSelector("input[value='Увійти']"));

            string myLogin = "Vasillsa@email.ua";
            string myPassword = "qwerty123!";
            string title = "Вхідні - I.UA ";

            loginInput.SendKeys(myLogin);
            passwordInput.SendKeys(myPassword);
            loginButton.Click();

            Assert.AreEqual(title, driver.Title);

            IWebElement element = driver.FindElement(By.Name("list[]"));
            element.Click();
           

            int numberOfElements = driver.FindElements(By.XPath("//form[@name='aform']/div")).Count;

            IWebElement deleteButton = driver.FindElement(By.XPath("(//span[@buttonname='del'])[first()]"));
            deleteButton.Click();

            IAlert confirmationAlert = driver.SwitchTo().Alert();
            confirmationAlert.Accept();

           
            int countOfEmailsAfterDeliting = driver.FindElements(By.XPath("//form[@name='aform']/div")).Count;

            Assert.AreEqual(numberOfElements - 1 , countOfEmailsAfterDeliting);

        }      

       
        //3.3

        [Test]
        public void HandlingMultipleWindows()
        {
            string url = "https://www.i.ua/";

            driver.Navigate().GoToUrl(url);

            IWebElement passwordInput = driver.FindElement(By.Name("pass"));
            IWebElement loginInput = driver.FindElement(By.Name("login"));
            IWebElement loginButton = driver.FindElement(By.CssSelector("input[value='Увійти']"));

            string myLogin = "Vasillsa@email.ua";
            string myPassword = "qwerty123!";
            string title = "Вхідні - I.UA ";
            string titleOfPageAfterExit = "Пошта - електронна пошта з доменами @i.ua, @ua.fm і @email.ua, створіть собі e-mail адресу на нашому порталі";
            
            loginInput.SendKeys(myLogin);
            passwordInput.SendKeys(myPassword);
            loginButton.Click();

            Assert.AreEqual(title, driver.Title);

            ((IJavaScriptExecutor)driver).ExecuteScript("window.open();");
            driver.SwitchTo().Window(driver.WindowHandles.Last());
            driver.Navigate().GoToUrl(url);
            
            IWebElement exitButton = driver.FindElement(By.XPath("//a[contains(text(),'Вихід')]"));
            exitButton.Click();

            driver.SwitchTo().Window(driver.WindowHandles.First());

            driver.Navigate().Refresh();           

            Assert.AreEqual(titleOfPageAfterExit, driver.Title.Trim());

        }      

        [TearDown]
        public void AfterTests()
        {
            driver.Quit();
        }




    }


}


