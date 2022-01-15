using FluentAssertions;
using TechTalk.SpecFlow;
using Unity;
using WebUI.AcceptanceTests.Utilities;
using WebUI.Domain.Models;
using WebUI.Domain.PageObjects.ExecuteAutomation;

namespace WebUI.AcceptanceTests.StepDefinitions
{
    [Binding]
    public class ExecuteAutomationStepDefinitions
    {
        private readonly ExecuteAutomationLoginPage _executeAutomationLoginPage;
        private readonly ExecuteAutomationRegistrationPage _executeAutomationRegistrationPage;
        public ExecuteAutomationStepDefinitions(TestDataContext testDataContext)
        {
            _executeAutomationLoginPage = testDataContext.Container.Resolve<ExecuteAutomationLoginPage>();
            _executeAutomationRegistrationPage = testDataContext.Container.Resolve<ExecuteAutomationRegistrationPage>();
        }       

        [When(@"I login with invalid credentials")]
        public void WhenILoginWithInvalidCredentials()
        {
            _executeAutomationLoginPage.InvalidLogin("dummy", "dummy");
        }

        [Then(@"Error message ""(.*)"" should be displayed")]
        public void ThenErrorMessageShouldBeDisplayed(string expectedError)
        {
            _executeAutomationLoginPage.GetErrorMessage().Should().Be(expectedError);
        }     

        [Given(@"I am on Login page of Execute Automation")]
        public void GivenIAmOnLoginPageOfExecuteAutomation()
        {
            _executeAutomationLoginPage.GoToPage();
        }

        [Given(@"I am on Registration page of the portal")]
        public void GivenIAmOnRegistrationPageOfExecuteAutomation()
        {
            _executeAutomationRegistrationPage.GoToPage();
        }

        [When(@"I register user with following details")]
        public void WhenIRegisterUserWithFollowingDetails(UserRegistrationEntity userRegistrationEntity)
        {
            _executeAutomationRegistrationPage.RegisterUser(userRegistrationEntity);
        }

        [Then(@"""(.*)"" should be displayed")]
        public void ThenShouldBeDisplayed(string message)
        {
            _executeAutomationRegistrationPage.GetErrorMessages().Should().BeEquivalentTo(Converter.ConvertStringToList(message));
        } 

    }
}
