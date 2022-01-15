using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using System;
using WebDriverManager.DriverConfigs.Impl;

namespace WebUI.Automation
{
    public class DriverHelper
    {
        private IWebDriver driver;
       
        public IWebDriver InitDriver(string browserName)
        {
            switch (browserName)
            {
                case "Chrome":
                    new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
                    driver = new ChromeDriver();
                    break;
                case "Edge":
                    var config = new EdgeConfig();
                    new WebDriverManager.DriverManager().SetUpDriver(new EdgeConfig(), config.GetMatchingBrowserVersion());
                    driver = new EdgeDriver();
                    break;
                default:
                    new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
                    driver = new ChromeDriver();
                    break;
            }

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(1500);
            driver.Manage().Window.Maximize();
            return driver;
        }

        public virtual void GoToPage()
        {       
           
        }

        public void TearDown(IWebDriver driver)
        {
            driver.Close();
        }
    }
}
