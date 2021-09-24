using BaseFramework.BaseClass;
using BaseFramework.Helpers;
using BaseFramework.Libraries.WebDriver;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace automationpractice.com.PageObjects
{
    public class OrderPageObject : BaseFramework_PageObjectBase
    {
        public OrderPageObject(WebDriver webDriver) : base(webDriver)
        {
        }

        public enum CheckOutPage
        {
            Summary,
            SignIn,
            Address,
            Shipping,
            Payment
        }
      
        public IWebElement CheckOutNavigation => this.GetWebDriver().GetCurrentDriver().FindElement(By.ClassName("cart_navigation"));
        public IWebElement CheckOutSteps => this.GetWebDriver().GetCurrentDriver().FindElement(By.Id("order_step"));
        public IWebElement CurrentCheckOutStep => CheckOutSteps.FindElement(By.ClassName("step_current"));
        public IWebElement AgreeToTermsCheckBox => this.GetWebDriver().GetCurrentDriver().FindElement(By.Id("cgv"));
        public IWebElement PayByBankWireButton => this.GetWebDriver().GetCurrentDriver().FindElement(By.ClassName("bankwire"));
        public IWebElement PageHeading => this.GetWebDriver().GetCurrentDriver().FindElement(By.TagName("h1"));

        public IWebElement ProceedToCheckOutButton(IWebElement buttonWrapper, CheckOutPage checkOutPage = CheckOutPage.Summary)
        {
            IWebElement button = null;
            switch(checkOutPage)
            {
                case CheckOutPage.Summary:
                case CheckOutPage.SignIn:
                    button = buttonWrapper.FindElement(By.CssSelector("a[title=\"Proceed to checkout\"]"));
                    break;
                case CheckOutPage.Address:
                    button = buttonWrapper.FindElement(By.Name("processAddress"));
                    break;
                case CheckOutPage.Shipping:
                    button = buttonWrapper.FindElement(By.Name("processCarrier"));
                    break;
            }
            return button;
        }

        public IWebElement ConfirmOrderButton(IWebElement buttonWrapper)
        {
            return buttonWrapper.FindElement(By.TagName("button"));
        }

        public void AgreeToTerms()
        {
            if(!this.AgreeToTermsCheckBox.Selected)
            {
                this.AgreeToTermsCheckBox.Click();
            }
        }
        public void WaitUntilCheckOutPageIs(CheckOutPage checkOutPage)
        {
            if(checkOutPage == CheckOutPage.SignIn)
            {
                this.GetWebDriver().GetCurrentDriver().WaitUntilElemValueEquals(this.CurrentCheckOutStep, "Sign in");
            }
            else
            {
                this.GetWebDriver().GetCurrentDriver().WaitUntilElemValueEquals(this.CurrentCheckOutStep, checkOutPage.ToString());
            }
        }

        public void VerifyOrderIsCompleted()
        {
            this.GetWebDriver().VerifyUrl(Routes.OrderConfirmationPage);
            Assert.AreEqual("Order confirmation".ToLower(), this.PageHeading.Text.ToLower());
        }

    }
}
