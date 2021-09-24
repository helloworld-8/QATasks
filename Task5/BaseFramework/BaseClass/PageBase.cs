using BaseFramework.Libraries.WebDriver;
using OpenQA.Selenium;

namespace BaseFramework.BaseClass
{
    public class BaseFramework_PageObjectBase
    {
        private WebDriver webDriver;

        protected BaseFramework_PageObjectBase(WebDriver webDriver)
        {
            this.webDriver = webDriver;
        }

        protected WebDriver GetWebDriver()
        {
            return this.webDriver;
        }
    }
}
