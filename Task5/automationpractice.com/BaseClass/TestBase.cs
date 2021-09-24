using BaseFramework.BaseClass;
using System;
using OpenQA.Selenium;
using BaseFramework.Helpers;

namespace automationpractice.com.BaseClass
{
    public class TestBase : BaseFramework_TestBase
    {
        protected override void OneTimeSetUp()
        {
            base.OneTimeSetUp();
            this.GetWebDriver().SetUrl(Routes.HomePage);
        }
    }
}
