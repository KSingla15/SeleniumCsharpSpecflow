using OpenQA.Selenium;
using System.Collections.Generic;
using System.Linq;
using WebUI.Automation;

namespace WebUI.Domain.PageObjects.ExecuteAutomation
{
    public class ExecuteAutomationLoginPage : DriverHelper
    {
        public readonly IWebDriver _driver;
        private readonly string _loginPageUrl = "http://eaapp.somee.com/Account/Login";

        public ExecuteAutomationLoginPage(IWebDriver driver)
        {
            _driver = driver;
        }
        private IWebElement TxtUserName => _driver.FindElement(By.Id("UserName"));
        private IWebElement TxtPassword => _driver.FindElement(By.Id("Password"));
        private IWebElement BtnLogin => _driver.FindElement(By.XPath("//input[contains(@class,'btn-default')]"));
        private IReadOnlyCollection<IWebElement> LstErrorMessages => _driver.FindElements(By.XPath("//*[@class = 'validation-summary-errors text-danger']//li"));

        public void InvalidLogin(string username, string password)
        {
            TxtUserName.SendKeys(username);
            TxtPassword.SendKeys(password);
            BtnLogin.Click();
        }

        public string GetErrorMessage()
        {
            return LstErrorMessages.First().Text;
        }

        public override void GoToPage()
        {
            _driver.Navigate().GoToUrl(_loginPageUrl);
        }
    }
}
