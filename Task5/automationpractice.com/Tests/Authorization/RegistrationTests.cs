using automationpractice.com.BaseClass;
using automationpractice.com.DataModels.Authentication;
using automationpractice.com.PageObjects;
using BaseFramework.Helpers;
using NUnit.Framework;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace automationpractice.com.Tests.Authorization
{
    public class RegistrationTests : TestBase
    {
        private AuthenticationObject AuthenticationObject => new AuthenticationObject(this.GetWebDriver());
        protected override void OneTimeSetUp()
        {
            base.OneTimeSetUp();
            this.GetWebDriver().NavigateToUrl(Routes.AuthenticationPage);
        }

        [Test]
        public void Should_Register_A_New_Account_Succesfully()
        {
            RegistrationDataModel testData = new RegistrationDataModel()
            {
                EmailAddress = "asdfasdfasfas151df@asddfasfa1sdf.com",
                Password = "slaptazodis",
                FirstName = "Vardenis",
                LastName = "Pavardenis",
                MobilePhone = "86666666",
                City = "Miestas",
                Address = "Adreso g. 25-25",
                ZipPostalCode = "12354",
                State = "Florida"
            };

            this.AuthenticationObject.RegisterNewUserAccount(testData);
            this.GetWebDriver().VerifyUrl(Routes.MyAccountPage);
        }



    }
}
