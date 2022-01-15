using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using Unity;
using WebUI.Automation;
using WebUI.Domain.Models;

namespace WebUI.AcceptanceTests.StepDefinitions
{
    [Binding]
    public class DummyStepDefinitions
    {
        private int first;
        private int second;
        private int result;
        private readonly PerformCalculations _performCalculations;
        public DummyStepDefinitions(TestDataContext testDataContext)
        {
            _performCalculations = testDataContext.Container.Resolve<PerformCalculations>();
        }

        [Given(@"two numbers are")]
        public void GivenTwoNumbersAre(Numbers numbers)
        {
            first = numbers.First;
            second = numbers.Second;
        }

        [When(@"the two numbers are added")]
        public void WhenTheTwoNumbersAreAdded()
        {
            result = _performCalculations.AddNumbers(first, second);
        }

        [Then(@"the result should be (.*)")]
        public void ThenTheResultShouldBe(int expected)
        {
            result.Should().Be(expected);
        }
    }
}
