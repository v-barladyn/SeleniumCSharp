using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumCSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter sum of  2 + 2 = ");          

            Assert.That(2 + 2, Is.EqualTo(Convert.ToInt32(Console.ReadLine())));
        }
      

        [Test]
        public void CompareTitle()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.i.ua/");

            string title = "І.UA - твоя пошта";


            Assert.AreEqual(title, driver.Title.Trim());
            driver.Close();
        }

        [Test]
        public void VerifyNumber()
        {
            Random rnd = new Random();
            int rd = rnd.Next(0, 100);
                       

            Assert.That((rd <= 50) && (rd >= 10) && (CheckIfPrime(rd) == true), "not prime " + rd);
            
        }

        public bool CheckIfPrime(int number)
        {
            if (number == 1 || number == 2)
            {
                return false;
            }


            if (number % 2 == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
