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
            
            driver.Navigate().GoToUrl("https://www.i.ua/");
            driver.Manage().Window.Maximize();

        }
        [SetUp]
        public void BeforeEachTests()
        {
          
        }

        // Smoke Tests

        [Test]
        public void CheckIfLoginFormIsPresented()
        {
            IWebElement loginForm = driver.FindElement(By.Name("lform"));

            Assert.IsTrue(loginForm.Displayed);

        }

        [Test]
        public void VerifyTitleOfLoginForm()
        {

            IWebElement TitleOfLoginForm = driver.FindElement(By.LinkText("Пошта"));

            Assert.IsTrue(TitleOfLoginForm.Displayed);

        }

        [Test]
        public void LoginText()
        {

            IWebElement loginText = driver.FindElement(By.XPath("//p[contains(text(),'Логін')]"));

            Assert.IsTrue(loginText.Displayed);

        }
        [Test]
        public void LoginInput()
        {

            IWebElement loginInput = driver.FindElement(By.Name("login"));

            Assert.IsTrue(loginInput.Displayed);

        }

        [Test]
        public void PasswordText()
        {

            IWebElement passwordText = driver.FindElement(By.XPath("//p[contains(text(),'Пароль')]"));

            Assert.IsTrue(passwordText.Displayed);

        }
        [Test]
        public void PasswordInput()
        {

            IWebElement passwordInput = driver.FindElement(By.Name("pass"));

            Assert.IsTrue(passwordInput.Displayed);

        }

        [Test]
        public void RememberLink()
        {

            IWebElement rememberLink = driver.FindElement(By.LinkText("нагадати"));

            Assert.IsTrue(rememberLink.Displayed);

        }

        [Test]
        public void DropdownWithDomens()
        {

            IWebElement dropdownWithDomens = driver.FindElement(By.Name("domn"));

            Assert.IsTrue(dropdownWithDomens.Displayed);

        }

        [Test]
        public void RememberMeText()
        {

            IWebElement rememberMeText = driver.FindElement(By.CssSelector("#c00"));

            Assert.IsTrue(rememberMeText.Displayed);

        }

        [Test]
        public void RememberMeCheckBox()
        {

            IWebElement rememberMeCheckBox = driver.FindElement(By.Name("auth_type"));

            Assert.IsTrue(rememberMeCheckBox.Displayed);

        }
        [Test]
        public void RegistrationLink()
        {

            IWebElement registrationLink = driver.FindElement(By.LinkText("Реєстрація"));

            Assert.IsTrue(registrationLink.Displayed);

        }

        [Test]
        public void LoginButton()
        {

            IWebElement loginButton = driver.FindElement(By.CssSelector("input[value='Увійти']"));

            Assert.IsTrue(loginButton.Displayed);

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


