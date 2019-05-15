using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using SeleniumCSharp.WrapperFactory;

namespace SeleniumCSharp
{
    class Translation
    {
        public Translation()
        {
            PageFactory.InitElements(BrowserFactory.Driver, this);
        }

        [FindsBy(How = How.Id, Using = "source")]
        IWebElement InputField;

        [FindsBy(How = How.XPath, Using = "//div[@class='text-wrap tlid-copy-target']")]
        IWebElement OutputField; 
               
        
        public string Translate(string text, string from, string to)
        {
            CustomMethods.OpenSite(ConfigurationManager.AppSettings["urlForTranslation"] +
                from + ConfigurationManager.AppSettings["partOfTranslationUrl"] + to);            
            this.InputField.SendKeys(text);
            CustomMethods.WaitForElement(this.OutputField);
            Console.WriteLine(this.OutputField.Text);
            return this.OutputField.Text;

        }


    }
}
