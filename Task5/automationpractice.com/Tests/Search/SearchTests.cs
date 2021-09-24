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
    public class SearchTests : TestBase
    {
        private SearchObject SearchObject => new SearchObject(this.GetWebDriver());

        [TestCase("Blouse")]
        public void Should_Search_By_Entered_Product_Name_Succesfully(string productName)
        {
            this.SearchObject.SearchForProduct(productName);
            this.SearchObject.VerifyHowManyProductsWereFoundMessage(this.SearchObject.ProductsList.Count);
        }

        [TestCase("badproductname")]
        public void Should_Search_By_Non_Existing_Product_Name_And_Show_That_No_Results_Were_Found(string productName)
        {
            this.SearchObject.SearchForProduct(productName);
            this.SearchObject.VerifyNoProductsWereFoundMessage(productName);
            this.SearchObject.VerifyHowManyProductsWereFoundMessage(0);
        }

        [TestCase("Blou")]
        public void Correct_Product_Should_Appear_In_The_Search_Results_Page(string productName)
        {
            this.SearchObject.SearchForProduct(productName);
            this.SearchObject.VerifyProductInTheList(this.SearchObject.ProductsList, productName);
        }
        
    }
}
