using NUnit.Framework;
using BaseFramework.Config;
using BaseFramework.Libraries.WebDriver;
using System;
using OpenQA.Selenium;
using System.Drawing.Imaging;
using NUnit.Framework.Interfaces;
using BaseFramework.Libraries;

namespace BaseFramework.BaseClass
{
    [TestFixture]
    public class BaseFramework_TestBase
    {
        private WebDriver webDriver;

        protected BaseFramework_TestBase()
        {
            this.webDriver = new WebDriver();
        }

        protected BaseFramework_TestBase(Browsers browser)
        {
            this.webDriver = new WebDriver(browser);
        }

        protected WebDriver GetWebDriver()
        {
            return this.webDriver;
        }

        [OneTimeSetUp]
        protected virtual void OneTimeSetUp()
        {
            this.GetWebDriver().Init();
        }

        [SetUp]
        protected void SetUp()
        {
        }

        [TearDown]
        public void TearDown()
        {
            if (TestContext.CurrentContext.Result.Outcome != ResultState.Success)
            {
                //MyScreenshot.TakeScreenshot(this.GetWebDriver().GetCurrentDriver());
            }
        }

        [OneTimeTearDown]
        protected void OneTimeTearDown()
        {
            this.GetWebDriver().WebDriverQuit();
        }
    }

}
