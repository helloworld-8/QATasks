using automationpractice.com.BaseClass;
using automationpractice.com.DataModels.Authentication;
using automationpractice.com.PageObjects;
using BaseFramework.Helpers;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace automationpractice.com.Tests.Search
{
    public class PurchaseTests : TestBase
    {
        private SearchObject SearchObject => new SearchObject(this.GetWebDriver());
        private ShoppingCartObject ShoppingCartObject => new ShoppingCartObject(this.GetWebDriver());
        private AuthenticationObject AuthenticationObject => new AuthenticationObject(this.GetWebDriver());
        private OrderPageObject OrderPageObject => new OrderPageObject(this.GetWebDriver());

        [TestCase("Blouse")]
        public void Should_Buy_Product_Succesfully_With_Already_Registered_User_Account(string productName)
        {
            var loginData = new LoginDataModel()
            {
                EmailAddress = "martynas115@gmail.com",
                Password = "slaptazodis"
            };

            this.SearchObject.SearchForProduct(productName);
            var firstProduct = this.SearchObject.ProductsList.ElementAt(0);
            this.SearchObject.MouseOverOnTheProduct(firstProduct);
            this.SearchObject.WaitUntilAddToCartButtonAppears(firstProduct);
            this.SearchObject.AddProductToCartButton(firstProduct).Click();

            this.ShoppingCartObject.VerifyShoppingCartPopUp();
            this.ShoppingCartObject.VerifyProductInTheList(this.ShoppingCartObject.ProductsList, this.SearchObject.ProductName(firstProduct).Text);
            this.ShoppingCartObject.ProceedToCheckOutButton.Click();

            this.OrderPageObject.WaitUntilCheckOutPageIs(OrderPageObject.CheckOutPage.Summary);            
            this.OrderPageObject.ProceedToCheckOutButton(this.OrderPageObject.CheckOutNavigation).Click();

            this.OrderPageObject.WaitUntilCheckOutPageIs(OrderPageObject.CheckOutPage.SignIn);
            this.AuthenticationObject.Login(loginData);

            this.OrderPageObject.WaitUntilCheckOutPageIs(OrderPageObject.CheckOutPage.Address);
            this.OrderPageObject.ProceedToCheckOutButton(this.OrderPageObject.CheckOutNavigation, OrderPageObject.CheckOutPage.Address).Click();

            this.OrderPageObject.WaitUntilCheckOutPageIs(OrderPageObject.CheckOutPage.Shipping);
            this.OrderPageObject.AgreeToTerms();
            this.OrderPageObject.ProceedToCheckOutButton(this.OrderPageObject.CheckOutNavigation, OrderPageObject.CheckOutPage.Shipping).Click();

            this.OrderPageObject.WaitUntilCheckOutPageIs(OrderPageObject.CheckOutPage.Payment);
            this.OrderPageObject.PayByBankWireButton.Click();

            this.GetWebDriver().VerifyUrl(Routes.BankWirePaymentPage);
            this.OrderPageObject.ConfirmOrderButton(this.OrderPageObject.CheckOutNavigation).Click();

            this.OrderPageObject.VerifyOrderIsCompleted();

        }

    }
}
