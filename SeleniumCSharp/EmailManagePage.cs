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

namespace SeleniumCSharp
{
    class EmailManagePage
    {
        public EmailManagePage()
        {
            PageFactory.InitElements(InstanceOfDriver.driver, this);
        }

        [FindsBy(How = How.Name, Using = "list[]")]
        IWebElement element { get; set; }

        [FindsBy(How = How.LinkText, Using = "Створити листа")]
        IWebElement createEmail { get; set; }

        [FindsBy(How = How.Name, Using = "to")]
        IWebElement sendEmailTo { get; set; }

        [FindsBy(How = How.Name, Using = "subject")]
        IWebElement sendEmailSubject { get; set; }

        [FindsBy(How = How.Id, Using = "text")]
        IWebElement sendEmailBody { get; set; }

        [FindsBy(How = How.Name, Using = "save_in_drafts")]
        IWebElement SaveInDraft { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[contains(text(),'Лист успішно збережено')]")]
        IWebElement NoticeLetterWasCreated { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[contains(text(),'Чернетки')]")]
        IWebElement draftEmails { get; set; }

        [FindsBy(How = How.XPath, Using = "//span[contains(text(),'qwerty@gmail.com')]")]
        IWebElement savedDraftdEmail { get; set; }

        [FindsBy(How = How.XPath, Using = "//span[contains(text(),'qwerty@gmail.com')]/ancestor::a/ancestor::div/span")]
        IWebElement includeCheckBoxForManageEmail { get; set; }

        [FindsBy(How = How.XPath, Using = "//span[@buttonname='del'])[first()]")]
        IWebElement deleteButton { get; set; }

       



        string xpath = "//div[contains(text(),'Лист успішно збережено')]";
        public string editText = "edit";


        public string title = "Вхідні - I.UA ";
        public string sendTo = "qwerty@gmail.com";
        public string subject = "Subject";
        public string emailText = "Some text";
        public string emailWasCreated = "Лист успішно збережено";
        


        public void CheckTitleOnThePage(string title)
        {
            Assert.AreEqual(this.title, InstanceOfDriver.driver.Title);
        }

        public void CreateNewLetter(string sendTo, string subject, string text)
        {
            this.createEmail.Click();
            this.sendEmailTo.SendKeys(sendTo);
            this.sendEmailSubject.SendKeys(subject);
            this.sendEmailBody.SendKeys(text);
            this.SaveInDraft.Click();            
            CustomMethods.WaitForElement(this.xpath);

            Assert.AreEqual(this.emailWasCreated, this.NoticeLetterWasCreated.Text.Trim()); 
                     
        }

        public void DeleteEmail()
        {
            this.draftEmails.Click();
            this.includeCheckBoxForManageEmail.Click();         
            this.deleteButton.Click();
            IAlert confirmationAlert = InstanceOfDriver.driver.SwitchTo().Alert();

            Assert.False(includeCheckBoxForManageEmail.Displayed);

        }




        public void EditDraftdEmail(string text)
        {
            this.draftEmails.Click();
            this.savedDraftdEmail.Click();
            this.sendEmailTo.SendKeys(text);
            this.sendEmailSubject.SendKeys(text);
            this.sendEmailBody.SendKeys(text);

            this.SaveInDraft.Click();
            CustomMethods.WaitForElement(this.xpath);

            Assert.AreEqual(this.emailWasCreated, this.NoticeLetterWasCreated.Text.Trim());
        }

        public void VerifySendToFieldAfterEdit()
        {
            this.draftEmails.Click();
            this.savedDraftdEmail.Click();                

            Assert.AreEqual(this.sendTo + this.editText, this.sendEmailTo.Text.Trim());
        }

        public void VerifySubjectFieldAfterEdit()
        {
            this.draftEmails.Click();
            this.savedDraftdEmail.Click();

            Assert.AreEqual(this.subject + this.editText, this.sendEmailSubject.GetAttribute("value"));
        }
        public void VerifyBodyFieldAfterEdit()
        {
            this.draftEmails.Click();
            this.savedDraftdEmail.Click();

            Assert.AreEqual(this.emailText + "\r\n" + this.editText, this.sendEmailBody.Text.Trim());
        }
    }
}
