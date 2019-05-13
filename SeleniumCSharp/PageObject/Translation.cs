using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumCSharp
{
    class Translation
    {
        public Translation()
        {
            PageFactory.InitElements(InstanceOfDriver.driver, this);
        }

        [FindsBy(How = How.XPath, Using = "//div[@class='sl-more tlid-open-source-language-list']")]
        IWebElement SelectSourceLanguage;

        [FindsBy(How = How.XPath, Using = "//div[contains(text(),'англійська')]")]
        IWebElement En;

        [FindsBy(How = How.XPath, Using = "//div[@class='tl - more tlid - open - target - language - list']")]
        IWebElement SelecTargetLanguage;

        [FindsBy(How = How.XPath, Using = "//div[contains(text(),'німецька')]")]
        IWebElement De;

        [FindsBy(How = How.Id, Using = "source")]
        IWebElement InputField;

        [FindsBy(How = How.XPath, Using = "//div[@class='text-wrap tlid-copy-target']")]
        IWebElement OutputField;
        

        public string url = "https://translate.google.com/#view=home&op=translate&sl=";
        public string partOfUrl = "&tl=";       


        public string Translate(string text, string from, string to)
        {
            CustomMethods.OpenSite(this.url + from + this.partOfUrl + to);
            Console.WriteLine(this.url + from + this.partOfUrl + to);
            this.InputField.SendKeys(text);
            CustomMethods.WaitForElement(this.OutputField);
            Console.WriteLine(this.OutputField.Text);
            return this.OutputField.Text;

        }


    }
}
