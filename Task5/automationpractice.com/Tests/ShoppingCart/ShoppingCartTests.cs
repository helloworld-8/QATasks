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
    public class ShoppingCartTests : TestBase
    {
        private SearchObject SearchObject => new SearchObject(this.GetWebDriver());
        private ShoppingCartObject ShoppingCartObject => new ShoppingCartObject(this.GetWebDriver());

        [TestCase("Blouse")]
        public void Should_Add_Product_To_Shopping_Cart_And_Appear_Pop_Up_Succesfully(string productName)
        {
            this.SearchObject.SearchForProduct(productName);
            var firstProduct = this.SearchObject.ProductsList.ElementAt(0);
            this.SearchObject.MouseOverOnTheProduct(firstProduct);
            this.SearchObject.WaitUntilAddToCartButtonAppears(firstProduct);
            this.SearchObject.AddProductToCartButton(firstProduct).Click();
            this.ShoppingCartObject.VerifyShoppingCartPopUp();
            this.ShoppingCartObject.VerifyProductInTheList(this.ShoppingCartObject.ProductsList, this.SearchObject.ProductName(firstProduct).Text);
        }

        [TestCase("Blouse")]
        public void Should_Let_To_Continue_Shopping_After_Adding_Product_To_Shopping_Cart(string productName)
        {
            this.SearchObject.SearchForProduct(productName);
            var firstProduct = this.SearchObject.ProductsList.ElementAt(0);
            this.SearchObject.MouseOverOnTheProduct(firstProduct);
            this.SearchObject.WaitUntilAddToCartButtonAppears(firstProduct);
            this.SearchObject.AddProductToCartButton(firstProduct).Click();
            this.ShoppingCartObject.VerifyShoppingCartPopUp();
            this.ShoppingCartObject.ContinueShoppingButton.Click();
            this.ShoppingCartObject.WaitUntilShoppingCartPopUpIsClosed();
        }

    }
}
