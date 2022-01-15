using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;

namespace WebUI.AcceptanceTests
{
    public class TestDataContext
    {
        public UnityContainer Container { get; set; }
        public Config Config { get; set; }

        public IWebDriver Driver { get; set; }
    }
}
