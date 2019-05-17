using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium;
using NUnit.Framework;
using OpenQA.Selenium.Support.UI;
using SeleniumCSharp.WrapperFactory;
using System.Threading;
using System.IO;
using System.Configuration;

namespace SeleniumCSharp
{
    class EmailManagePage
    {
        public EmailManagePage()
        {
            PageFactory.InitElements(BrowserFactory.Driver, this);
        }

        [FindsBy(How = How.Name, Using = "list[]")]
        IWebElement Element { get; set; }

        [FindsBy(How = How.LinkText, Using = "Створити листа")]
        IWebElement CreateEmail { get; set; }

        [FindsBy(How = How.Name, Using = "to")]
        IWebElement SendEmailTo { get; set; }

        [FindsBy(How = How.Name, Using = "subject")]
        IWebElement SendEmailSubject { get; set; }

        [FindsBy(How = How.Id, Using = "text")]
        IWebElement SendEmailBody { get; set; }

        [FindsBy(How = How.Name, Using = "save_in_drafts")]
        IWebElement SaveInDraft { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[contains(text(),'Лист успішно збережено')]")]
        IWebElement NoticeLetterWasCreated { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[contains(text(),'Чернетки')]")]
        IWebElement DraftEmails { get; set; }

        [FindsBy(How = How.XPath, Using = "//span[contains(text(),'qwerty@gmail.com')]")]
        IWebElement SavedDraftdEmail { get; set; }

        [FindsBy(How = How.XPath, Using = "//span[contains(text(),'qwerty@gmail.com')]/ancestor::a/ancestor::div/span")]
        IWebElement IncludeCheckBoxForManageEmail { get; set; }

        [FindsBy(How = How.XPath, Using = "//span[@buttonname='del'])[first()]")]
        IWebElement deleteButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//ol[@id='attached']/li/b/a")]
        IWebElement DownloadAttach;


        [FindsBy(How = How.Id, Using = "label_inpSourceuform_2")]
        IWebElement CheckBox;

       
       
               
        
        public string editText = "edit";
        public string title = "Вхідні - I.UA ";
        public string sendTo = "qwerty@gmail.com";
        public string subject = "Subject";
        public string emailText = "Some text";
        public string emailWasCreated = "Лист успішно збережено";
        


        public void CheckTitleOnThePage(string title)
        {
            Assert.AreEqual(this.title, BrowserFactory.Driver.Title);
        }

        public void CreateNewLetter(string sendTo, string subject, string text)
        {
            this.CreateEmail.Click();
            this.SendEmailTo.SendKeys(sendTo);
            this.SendEmailSubject.SendKeys(subject);
            this.SendEmailBody.SendKeys(text);
            this.SaveInDraft.Click();
            
            CustomMethods.WaitForElement(this.NoticeLetterWasCreated);

            Assert.AreEqual(this.emailWasCreated, this.NoticeLetterWasCreated.Text.Trim()); 
                     
        }
        
        public void DeleteEmail()
        {
            this.DraftEmails.Click();
            this.IncludeCheckBoxForManageEmail.Click();         
            this.deleteButton.Click();

            IAlert confirmationAlert = BrowserFactory.Driver.SwitchTo().Alert();

            CheckTitleOnThePage(this.title);
            Assert.False(IncludeCheckBoxForManageEmail.Displayed);

        }




        public void EditDraftdEmail(string text)
        {
            this.DraftEmails.Click();
            this.SavedDraftdEmail.Click();
            this.SendEmailTo.SendKeys(text);
            this.SendEmailSubject.SendKeys(text);
            this.SendEmailBody.SendKeys(text);
            this.SaveInDraft.Click();

            CustomMethods.WaitForElement(this.NoticeLetterWasCreated);

            Assert.AreEqual(this.emailWasCreated, this.NoticeLetterWasCreated.Text.Trim());
        }

        public void VerifySendToFieldAfterEdit()
        {
            this.DraftEmails.Click();
            this.SavedDraftdEmail.Click();                

            Assert.AreEqual(this.sendTo + this.editText, this.SendEmailTo.Text.Trim());
        }

        public void VerifySubjectFieldAfterEdit()
        {
            this.DraftEmails.Click();
            this.SavedDraftdEmail.Click();

            Assert.AreEqual(this.subject + this.editText, this.SendEmailSubject.GetAttribute("value"));
        }
        public void VerifyBodyFieldAfterEdit()
        {
            this.DraftEmails.Click();
            this.SavedDraftdEmail.Click();

            Assert.AreEqual(this.emailText + "\r\n" + this.editText, this.SendEmailBody.Text.Trim());
        }

        public void VerifyFileDownloading()
        {
            this.DraftEmails.Click();
            this.SavedDraftdEmail.Click();
            CustomMethods.WaitForElement(this.CheckBox);           
            this.DownloadAttach.Click();
            CustomMethods.WaitUntilFileDownloaded(ConfigurationManager.AppSettings["filePath"], this.DownloadAttach.Text);

        }
    }
}
