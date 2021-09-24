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
    public class SearchObject : BaseFramework_PageObjectBase
    {
        public SearchObject(WebDriver webDriver) : base(webDriver)
        {
        }

        public IWebElement SearchQueryInput => this.GetWebDriver().GetCurrentDriver().FindElement(By.Id("search_query_top"));
        public IWebElement SearchButton => this.GetWebDriver().GetCurrentDriver().FindElement(By.Name("submit_search"));
        public IReadOnlyCollection<IWebElement> ProductsList => this.GetWebDriver().GetCurrentDriver().FindElements(By.CssSelector("ul li.ajax_block_product"));
        public IWebElement ProductName(IWebElement product)
        {
            return product.FindElement(By.ClassName("product-name"));
        }
        public IWebElement NoProductsWereFoundMessage => this.GetWebDriver().GetCurrentDriver().FindElement(By.XPath("//p[contains(text(), \"No results were found for your search\")]"));
        public IWebElement HowManyProductsWereFoundMessage => this.GetWebDriver().GetCurrentDriver().FindElement(By.ClassName("heading-counter"));
      
        public IWebElement AddProductToCartButton(IWebElement product)
        {
            return product.FindElement(By.ClassName("ajax_add_to_cart_button"));
        }

        public void SearchForProduct(string productName)
        {
            this.SearchQueryInput.SendKeys(productName);
            this.SearchButton.Click();
            this.GetWebDriver().VerifyUrl(Routes.SearchResultsPage);
        }

        public void MouseOverOnTheProduct(IWebElement product)
        {
            Actions action = new Actions(this.GetWebDriver().GetCurrentDriver());
            action.MoveToElement(product).Perform();
        }

        public void WaitUntilAddToCartButtonAppears(IWebElement product)
        {
            this.GetWebDriver().GetCurrentDriver().WaitUntilElementIsVisible(this.AddProductToCartButton(product));
        }

        public void VerifyNoProductsWereFoundMessage(string productName)
        {
            this.GetWebDriver().GetCurrentDriver().WaitUntilElementIsVisible(this.NoProductsWereFoundMessage);
            string expectedMessage = String.Format($"No results were found for your search \"{productName}\"");
            Assert.AreEqual(expectedMessage, this.NoProductsWereFoundMessage.Text);
        }
        public void VerifyHowManyProductsWereFoundMessage(int howManyProducts)
        {
            this.GetWebDriver().GetCurrentDriver().WaitUntilElementIsVisible(this.HowManyProductsWereFoundMessage);
            string expectedMessage = String.Empty;
            if (howManyProducts == 1)
            {
                expectedMessage = String.Format($"{howManyProducts} result has been found.");
            }
            else
            {
                expectedMessage = String.Format($"{howManyProducts} results have been found.");
            }
            Assert.AreEqual(expectedMessage, this.HowManyProductsWereFoundMessage.Text);
        }

        public void VerifyProductInTheList(IReadOnlyCollection<IWebElement> productList, string expectedProductName)
        {
            bool productFound = false;
            string productNameFound;
            foreach (var product in productList)
            {
                productNameFound = this.ProductName(product).Text;
                if (productNameFound.Contains(expectedProductName))
                {
                    productFound = true;
                    Assert.AreEqual(expectedProductName, productNameFound, "Product was not found");
                    break;
                }
            }

            if(!productFound)
            {
                Assert.Fail($"Product \"{expectedProductName}\" did not appear in the search results page");
            }
        }

    }
}
