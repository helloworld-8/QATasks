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
    public class ShoppingCartObject : BaseFramework_PageObjectBase
    {
        public ShoppingCartObject(WebDriver webDriver) : base(webDriver)
        {
        }

        public IWebElement ShoppingCartPopUp => this.GetWebDriver().GetCurrentDriver().FindElement(By.Id("layer_cart"));

        public IWebElement ProductName(IWebElement product)
        {
            return product.FindElement(By.ClassName("product-name"));
        }
        public IWebElement ProductSuccesfullyAddedMessage => ShoppingCartPopUp.FindElement(By.TagName("h2"));
        public IReadOnlyCollection<IWebElement> ProductsList => ShoppingCartPopUp.FindElements(By.CssSelector("div.layer_cart_product_info"));
        public IWebElement ProceedToCheckOutButton => ShoppingCartPopUp.FindElement(By.CssSelector("a[title=\"Proceed to checkout\"]"));
        public IWebElement ContinueShoppingButton => ShoppingCartPopUp.FindElement(By.CssSelector("span[title=\"Continue shopping\"]"));

        public void VerifyShoppingCartPopUp()
        {
            this.GetWebDriver().GetCurrentDriver().WaitUntilElementIsVisible(this.ShoppingCartPopUp);
            Assert.AreEqual("Product successfully added to your shopping cart", this.ProductSuccesfullyAddedMessage.Text);
        }

        public void WaitUntilShoppingCartPopUpIsClosed()
        {
            this.GetWebDriver().GetCurrentDriver().WaitUntilElementNotVisible(this.ShoppingCartPopUp);
        }

        public void VerifyProductInTheList(IReadOnlyCollection<IWebElement> productList, string expectedProductName)
        {
            SearchObject searchObject = new SearchObject(this.GetWebDriver());
            searchObject.VerifyProductInTheList(productList, expectedProductName);
        }

    }
}
