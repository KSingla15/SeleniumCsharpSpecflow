using OpenQA.Selenium;
using System.Collections.Generic;
using System.Linq;
using WebUI.Automation;
using WebUI.Domain.Models;

namespace WebUI.Domain.PageObjects.ExecuteAutomation
{
    public class ExecuteAutomationRegistrationPage : DriverHelper
    {
        private readonly IWebDriver _driver;
        private readonly string _registrationPageUrl = "http://eaapp.somee.com/Account/Register";

        public ExecuteAutomationRegistrationPage(IWebDriver driver)
        {
            _driver = driver;
        }
        private IWebElement txtUserName => _driver.FindElement(By.Id("UserName"));
        private IWebElement txtPassword => _driver.FindElement(By.Id("Password"));
        private IWebElement txtConfirmPassword => _driver.FindElement(By.Id("ConfirmPassword"));
        private IWebElement txtEmail => _driver.FindElement(By.Id("Email"));
        private IWebElement btnRegister => _driver.FindElement(By.XPath("//input[contains(@class,'btn-default')]"));
        private IReadOnlyCollection<IWebElement> lstErrorMessages => _driver.FindElements(By.XPath("//*[@class = 'text-danger validation-summary-errors']//li"));

        public void RegisterUser(UserRegistrationEntity userRegistrationEntity)
        {
            txtUserName.SendKeys(userRegistrationEntity.UserName);
            txtPassword.SendKeys(userRegistrationEntity.Password);
            txtConfirmPassword.SendKeys(userRegistrationEntity.ConfirmPassword);
            txtEmail.SendKeys(userRegistrationEntity.Email);
            btnRegister.Click();
        }

        public List<string> GetErrorMessages()
        {
            return lstErrorMessages.Select(item => item.Text).ToList();
        }

        public override void GoToPage()
        {
            _driver.Navigate().GoToUrl(_registrationPageUrl);
        }
    }
}
