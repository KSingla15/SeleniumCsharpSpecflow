using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using Unity;
using WebUI.Domain.PageObjects;

namespace WebUI.AcceptanceTests.StepDefinitions
{
    [Binding]
    public class GoogleSearch
    {
        private readonly GoogleSearchPage _googleSearchPage;
        public GoogleSearch(TestDataContext testDataContext)
        {
            _googleSearchPage = testDataContext.Container.Resolve<GoogleSearchPage>();
        }

        [Given(@"I am on the Google search page")]
        public void GivenIAmOnTheGoogleSearchPage()
        {
            _googleSearchPage.GoToPage();
        }

        [When(@"I search ""(.*)""")]
        public void WhenISearch(string text)
        {
            _googleSearchPage.Search(text);
        }

        [Then(@"I should be navigated to result page")]
        public void ThenIShouldBeNavigatedToResultPage()
        {
            //
        }

    }
}
