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
        IWebElement selectSourceLanguage { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[contains(text(),'англійська')]")]
        IWebElement en { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@class='tl - more tlid - open - target - language - list']")]
        IWebElement selecTargetLanguage { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[contains(text(),'німецька')]")]
        IWebElement de { get; set; }

        [FindsBy(How = How.Id, Using = "source")]
        IWebElement inputField { get; set; }
    
        [FindsBy(How = How.XPath, Using = "//div[@class='text-wrap tlid-copy-target']")]
        IWebElement outputField { get; set; }


        string xpath = "//div[@class='text-wrap tlid-copy-target']";  
        

        public string enToDeURL = "https://translate.google.com/#view=home&op=translate&sl=en&tl=de";
        public string enToFrURL = "https://translate.google.com/#view=home&op=translate&sl=en&tl=fr";
        public string deToFrURL = "https://translate.google.com/#view=home&op=translate&sl=de&tl=fr";


        public string Translate(string text, string url)
        {
            CustomMethods.OpenSite(url);          
            this.inputField.SendKeys(text);
            CustomMethods.WaitForElement(this.xpath);
            Console.WriteLine(this.outputField.Text);
            return this.outputField.Text;
          
        }

      


    }
}
