using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic; 
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;

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
            
            driver.Navigate().GoToUrl("http://the-internet.herokuapp.com/tinymce");
            driver.Manage().Window.Maximize();

        }
        [SetUp]
        public void BeforeEachTests()
        {

        }


        //3.1
        [Test]
        public void InsertGettextFromForm()
        {
            string text = "Vasillsa@email.ua";           
            IWebElement InsertIntoEditor = driver.FindElement(By.XPath("//body[@id='tinymce']/p"));
            InsertIntoEditor.SendKeys(text);

            Assert.AreEqual(text, InsertIntoEditor.GetAttribute("value"));
        }




        //2.2 

        [Test]
        public void LogIntoMailBox()
        {
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
        }

        //2.3

        [Test]
        public void LogIntoMailBoxVerification()
        {
            IWebElement passwordInput = driver.FindElement(By.Name("pass"));
            IWebElement loginInput = driver.FindElement(By.Name("login"));
            IWebElement loginButton = driver.FindElement(By.CssSelector("input[value='Увійти']"));
            IWebElement dropdownWithDomens = driver.FindElement(By.Name("domn"));
            IWebElement rememberMeCheckBox = driver.FindElement(By.Name("auth_type"));

            SelectElement oSelect = new SelectElement(dropdownWithDomens);

            string myLogin = "Vasillsa@email.ua";
            string myPassword = "qwerty123!";
            string title = "Вхідні - I.UA ";
            string emailDomen = "email.ua";       
                       
            loginInput.SendKeys(myLogin);
            passwordInput.SendKeys(myPassword);
            oSelect.SelectByText(emailDomen);
            rememberMeCheckBox.Click();            

            Assert.AreEqual(emailDomen, oSelect.SelectedOption.Text);
            Assert.IsTrue(rememberMeCheckBox.Selected);
            Assert.AreEqual(myLogin, loginInput.GetAttribute("value"));
            Assert.AreEqual(myPassword, passwordInput.GetAttribute("value"));           
        }

        //2.4
        [Test]
        public void VerifyEmail()
        {
            IWebElement passwordInput = driver.FindElement(By.Name("pass"));
            IWebElement loginInput = driver.FindElement(By.Name("login"));
            IWebElement loginButton = driver.FindElement(By.CssSelector("input[value='Увійти']"));
    
            

            string myLogin = "Vasillsa@email.ua";
            string myPassword = "qwerty123!";
            string welcomEmail = "Ласкаво просимо на I.UA!";            
         

            loginInput.SendKeys(myLogin);
            passwordInput.SendKeys(myPassword);
            loginButton.Click();

            IWebElement welcomThemeEmail = driver.FindElement(By.XPath("//a/span/span[contains(text(),'Ласкаво просимо на I.UA!')]"));
            
            Assert.AreEqual(welcomEmail, welcomThemeEmail.Text);

            Actions actions = new Actions(driver);
            actions.MoveToElement(welcomThemeEmail);
            actions.Perform();
        

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromMilliseconds(2000));
            wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath("//li[contains(text(),' Добрий день, vasyl vasyl.')]")));

            IWebElement emailPopup = driver.FindElement(By.XPath("//li[contains(text(),' Добрий день, vasyl vasyl.')]"));
            Assert.IsTrue(emailPopup.Displayed);
         
         
        }

        //2.5
        [Test]
        public void LogIntoMailBoxJSExecutor()
        {
            IWebElement passwordInput = driver.FindElement(By.Name("pass"));
            IWebElement loginInput = driver.FindElement(By.Name("login"));
            IWebElement loginButton = driver.FindElement(By.CssSelector("input[value='Увійти']"));
            IJavaScriptExecutor js = (IJavaScriptExecutor) driver;

            string myLogin = "Vasillsa@email.ua";
            string myPassword = "qwerty123!";
            string title = "Вхідні - I.UA ";            

            js.ExecuteScript("arguments[0].setAttribute('value', arguments[1])", loginInput, myLogin);
            js.ExecuteScript("arguments[0].setAttribute('value', arguments[1])", passwordInput, myPassword);
            js.ExecuteScript("arguments[0].click();", loginButton);         

            Assert.AreEqual(title, driver.Title);
        }


        [TearDown]
        public void AfterTests()
        {
            driver.Quit();
        }




    }


}


