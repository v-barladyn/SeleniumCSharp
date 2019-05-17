using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Support.Extensions;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing.Imaging;

namespace SeleniumCSharp.WrapperFactory
{
    class BrowserFactory
    {
        private static readonly IDictionary<string, IWebDriver> Drivers = new Dictionary<string, IWebDriver>();
        private static IWebDriver driver;

        public static IWebDriver Driver
        {
            get
            {
                if (driver == null)
                    throw new NullReferenceException("The WebDriver browser instance was not initialized. You should first call the method InitBrowser.");
                return driver;
            }
            private set
            {
                driver = value;
            }
        }

        public static void InitBrowser(string browserName)
        {
            switch (browserName)
            {
                case "Chrome":
                    if (driver == null)
                    {                        
                        ChromeOptions chromeopt = new ChromeOptions();
                        chromeopt.AddUserProfilePreference("plugins.always_open_pdf_externally", true);
                        chromeopt.AddUserProfilePreference("profile.default_content_settings.popups", 0);
                        chromeopt.AddUserProfilePreference("download.prompt_for_download", false);
                        chromeopt.AddUserProfilePreference("download.default_directory","C:\\images\\");
                        chromeopt.AddUserProfilePreference("intl.accept_languages", "nl");
                        chromeopt.AddUserProfilePreference("disable-popup-blocking", "true");

                        driver = new ChromeDriver(chromeopt);
                        Drivers.Add("Chrome", Driver);


                    }
                    break;

                case "IE":
                    if (Driver == null)
                    {
                        driver = new InternetExplorerDriver(@"C:\PathTo\IEDriverServer");
                        Drivers.Add("IE", Driver);
                    }
                    break;
             
            }
        }

        public static void LoadApplication(string url)
        {
            Driver.Url = url;
        }

        public static void CloseAllDrivers()
        {
            foreach (var key in Drivers.Keys)
            {
                Drivers[key].Close();
                Drivers[key].Quit();
            }
        }
  
    }
}
