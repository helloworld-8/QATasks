using automationpractice.com.DataModels.Authentication;
using BaseFramework.BaseClass;
using BaseFramework.Helpers;
using BaseFramework.Libraries.WebDriver;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace automationpractice.com.PageObjects
{
    public class AuthenticationObject : BaseFramework_PageObjectBase
    {
        public AuthenticationObject(WebDriver webDriver) : base(webDriver)
        {
        }

        // Global
        public IWebElement PageHeading => this.GetWebDriver().GetCurrentDriver().FindElement(By.CssSelector("h1.page-heading"));
        public IWebElement PasswordInput => this.GetWebDriver().GetCurrentDriver().FindElement(By.Id("passwd"));

        // Login
        public IWebElement EmailInput => this.GetWebDriver().GetCurrentDriver().FindElement(By.Id("email"));
        public IWebElement LoginButton => this.GetWebDriver().GetCurrentDriver().FindElement(By.Id("SubmitLogin"));


        // Registration
        public IWebElement EmailCreateInput => this.GetWebDriver().GetCurrentDriver().FindElement(By.Id("email_create"));
        public IWebElement CreateAccountButton => this.GetWebDriver().GetCurrentDriver().FindElement(By.Id("SubmitCreate"));
        public IWebElement CreateAccountForm => this.GetWebDriver().GetCurrentDriver().FindElement(By.Id("account-creation_form"));
        public IWebElement GenderMrsRadioButton => this.GetWebDriver().GetCurrentDriver().FindElement(By.Id("id_gender2"));
        public IWebElement GenderMrRadioButton => this.GetWebDriver().GetCurrentDriver().FindElement(By.Id("id_gender1"));
        public IWebElement FirstNameInput => this.GetWebDriver().GetCurrentDriver().FindElement(By.Id("customer_firstname"));
        public IWebElement LastNameInput => this.GetWebDriver().GetCurrentDriver().FindElement(By.Id("customer_lastname"));
        public IWebElement MobilePhoneInput => this.GetWebDriver().GetCurrentDriver().FindElement(By.Id("phone_mobile"));
        public IWebElement AddressInput => this.GetWebDriver().GetCurrentDriver().FindElement(By.Id("address1"));
        public IWebElement CityInput => this.GetWebDriver().GetCurrentDriver().FindElement(By.Id("city"));
        public IWebElement ZipPostalCodeInput => this.GetWebDriver().GetCurrentDriver().FindElement(By.Id("postcode"));
        public IWebElement StateInput => this.GetWebDriver().GetCurrentDriver().FindElement(By.Id("id_state"));
        public IWebElement RegistrationButton => this.GetWebDriver().GetCurrentDriver().FindElement(By.Id("submitAccount"));


        public void RegisterNewUserAccount(RegistrationDataModel testData)
        {
            this.EmailCreateInput.SendKeys(testData.EmailAddress);
            this.CreateAccountButton.Click();
            this.GetWebDriver().GetCurrentDriver().WaitUntilElementIsVisible(this.CreateAccountForm);
            this.GenderMrRadioButton.Click(); // this should come from test data
            this.FirstNameInput.SendKeys(testData.FirstName);
            this.LastNameInput.SendKeys(testData.LastName);
            this.PasswordInput.SendKeys(testData.Password);
            this.MobilePhoneInput.SendKeys(testData.MobilePhone);
            this.AddressInput.SendKeys(testData.Address);
            this.CityInput.SendKeys(testData.City);
            this.ZipPostalCodeInput.SendKeys(testData.ZipPostalCode);
            new SelectElement(this.StateInput).SelectByText(testData.State);
            this.RegistrationButton.Click();
        }

        public void Login(LoginDataModel testData)
        {
            this.EmailInput.SendKeys(testData.EmailAddress);
            this.PasswordInput.SendKeys(testData.Password);
            this.LoginButton.Click();
        }

    }
}
