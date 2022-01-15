using OpenQA.Selenium;

namespace WebUI.Domain.PageObjects
{
    public class GoogleSearchPage
    {
        private readonly IWebDriver _driver;
        public GoogleSearchPage(IWebDriver driver)
        {
            _driver = driver;
        }
        private string URL = "https://www.google.co.in/";
        private IWebElement SearchBox => _driver.FindElement(By.Name("q"));
        private IWebElement SearchButton => _driver.FindElement(By.Name("btnI"));
        
        public void GoToPage()
        {
            _driver.Navigate().GoToUrl(URL);
        }

        public void Search(string text)
        {
            SearchBox.SendKeys(text);
            SearchButton.Click();
        }
    }
}
