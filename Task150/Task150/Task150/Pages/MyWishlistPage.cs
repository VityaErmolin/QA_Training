using System;
using System.Collections.Generic;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using Task150.HelperPage;

namespace Task150.Pages
{
    internal class MyWishlistPage : Page
    {
        private readonly string NAME_WISHLIST = "MyWishlist";

        [FindsBy(How = How.Id, Using = "name")]
        private IWebElement NameWishlistField;

        [FindsBy(How = How.Id, Using = "submitWishlist")]
        private IWebElement SaveWishlistButton;

        [FindsBy(How = How.CssSelector, Using = "tbody > tr .wishlist_delete > .icon")]
        private IList<IWebElement> WishlistListsDeleteButton;

        public MyWishlistPage(IWebDriver driver) : base(driver)
        {
            PageFactory.InitElements(driver, this);
        }

        public bool IsThisPage()
        {
            var byPageHeadingTitle = By.ClassName("page-heading");

            return _driver.WaiterByElementIsDisplay(byPageHeadingTitle)
                   && _driver.FindElement(byPageHeadingTitle)
                       .Text
                       .ToLower()
                       .Equals("my wishlists");
        }

        public MyWishlistPage FillNameWishlistField()
        {
            NameWishlistField.SendKeys(NAME_WISHLIST);
            return this;
        }

        public MyWishlistPage SaveWishlistButtonClick()
        {
            SaveWishlistButton.Click();
            return this;
        }

        public int GetCountWishlist()
        {
            return WishlistListsDeleteButton.Count;
        }

        public bool IsWishlistEmpty()
        {
            var isClean = _driver.WaiterByElementIsNotDisplay(By.Id("block-history"));
            return isClean;
        }


        public MyWishlistPage CleanWishList()
        {
            if (GetCountWishlist() > 0)
            {
                foreach (var row in WishlistListsDeleteButton)
                {
                    row.Click();
                    var alert = _driver.SwitchTo().Alert();
                    alert.Accept();
                }
            }

            return this;
        }

        public int QuantityProductFromUserWishlist()
        {
            var qtyString = _driver
                .FindElement(By.XPath($"//a[contains(text(), '{NAME_WISHLIST}')]//ancestor::tr//td[2]")).Text;

            return int.TryParse(qtyString, out var qty)
                ? qty
                : throw new ArgumentException($"Cannot parse string {qtyString} to integer!");
        }
    }
}