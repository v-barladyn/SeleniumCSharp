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
        IWebElement Element;

        [FindsBy(How = How.LinkText, Using = "Створити листа")]
        IWebElement CreateEmail;

        [FindsBy(How = How.Name, Using = "to")]
        public IWebElement SendEmailTo;

        [FindsBy(How = How.Name, Using = "subject")]
        public IWebElement SendEmailSubject;

        [FindsBy(How = How.Id, Using = "text")]
        public IWebElement SendEmailBody;

        [FindsBy(How = How.Name, Using = "save_in_drafts")]
        IWebElement SaveInDraft;

        [FindsBy(How = How.XPath, Using = "//div[contains(text(),'Лист успішно збережено')]")]
        public IWebElement NoticeLetterWasCreated;

        [FindsBy(How = How.XPath, Using = "//a[contains(text(),'Чернетки')]")]
        IWebElement DraftEmails;

        [FindsBy(How = How.XPath, Using = "//span[contains(text(),'qwerty@gmail.com')]")]
        IWebElement SavedDraftdEmail;

        [FindsBy(How = How.XPath, Using = "//span[contains(text(),'qwerty@gmail.com')]/ancestor::a/ancestor::div/span")]
        IWebElement IncludeCheckBoxForManageEmail;

        [FindsBy(How = How.XPath, Using = "//span[@buttonname='del'])[first()]")]
        IWebElement deleteButton; 

        [FindsBy(How = How.XPath, Using = "//ol[@id='attached']/li/b/a")]
        IWebElement DownloadAttach;

        [FindsBy(How = How.Id, Using = "label_inpSourceuform_2")]
        public IWebElement CheckBox;

        [FindsBy(How = How.XPath, Using = "//span[contains(text(),'Вкласти файл')]")]
        public IWebElement UploadFileButton;

        [FindsBy(How = How.XPath, Using = "//input[@type='file']")]
        public IWebElement SelectFileToUplad;
 


        public string editText = "edit";
        public string title = "Вхідні - I.UA ";
        public string sendTo = "qwerty@gmail.com";
        public string subject = "Subject";
        public string emailText = "Some text";
        public string emailWasCreated = "Лист успішно збережено";
        public string fileName = "Capture.PNG";
        


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
        }  
        

        public void EditDraftdEmail(string text)
        {
            this.DraftEmails.Click();
            this.SavedDraftdEmail.Click();
            this.SendEmailTo.SendKeys(text);
            this.SendEmailSubject.SendKeys(text);
            this.SendEmailBody.SendKeys(text);
            this.SaveInDraft.Click();         
        }

        public void VerifySendToFieldAfterEdit()
        {
            this.DraftEmails.Click();
            this.SavedDraftdEmail.Click();           
                      
        }

        public void VerifySubjectFieldAfterEdit()
        {
            this.DraftEmails.Click();
            this.SavedDraftdEmail.Click();
           
        }
        public void VerifyBodyFieldAfterEdit()
        {
            this.DraftEmails.Click();
            this.SavedDraftdEmail.Click();           
        }

        public void VerifyFileDownloading()
        {
            this.DraftEmails.Click();
            this.SavedDraftdEmail.Click();
            CustomMethods.WaitForElement(this.CheckBox);           
            this.DownloadAttach.Click();           
            CustomMethods.WaitUntilFileDownloaded(ConfigurationManager.AppSettings["filePath"], this.DownloadAttach.Text);
        }

        public void VerifyFileUploading()
        {
            this.DraftEmails.Click();
            this.SavedDraftdEmail.Click();
            this.UploadFileButton.Click();
            CustomMethods.WaitForElement(this.SelectFileToUplad);
            CustomMethods.UploadFile(this.SelectFileToUplad, ConfigurationManager.AppSettings["filePathUpload"], this.fileName);
            CustomMethods.WaitForElement(this.DownloadAttach);
            this.SaveInDraft.Click(); 

        }

    }
}
