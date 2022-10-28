using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using BaigiamasisDarbas.Page;

namespace BaigiamasisDarbas.Test
{
    public class PriceFilterCheckTest : BaseTest
    {
        [Test]
        public static void PriceFilterCheck()
        {
            priceFilterCheckPage.NavigateToPage();
            priceFilterCheckPage.CloseCookies();
            priceFilterCheckPage.MaxPrice("15");
            priceFilterCheckPage.VerifyFilterLabel();
        }
    }
}