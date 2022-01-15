using System;
using TechTalk.SpecFlow;
using Unity;
using WebUI.Automation;
using Newtonsoft.Json;
using System.IO;
using OpenQA.Selenium;

namespace WebUI.AcceptanceTests.Hooks
{
    [Binding]
    public class Hooks
    {
        [BeforeFeature]
        public static void BeforeFeature(TestDataContext testDataContext)
        {
            Console.WriteLine("This is before feature.");
            var projectPath = Environment.CurrentDirectory;
            var configurations = JsonConvert.DeserializeObject<Config>(File.ReadAllText(projectPath+"/../../../Config.json"));
            testDataContext.Container = new UnityContainer();
            testDataContext.Config = configurations;
            var driverHelper = new DriverHelper();
            var driver = driverHelper.InitDriver(configurations.Browser);
            testDataContext.Container.RegisterInstance(driver);
            testDataContext.Container.RegisterInstance(driverHelper);
        }

        [AfterFeature]
        public static void AfterFeature(TestDataContext testDataContext)
        {
            testDataContext.Container.Resolve<DriverHelper>().TearDown(testDataContext.Container.Resolve<IWebDriver>());
            Console.WriteLine("This is after feature.");
        }
    }
}
