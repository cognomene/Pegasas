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
            PriceFilterCheckPage page = new PriceFilterCheckPage(chromeDriver);
            page.NavigateToPage();
            page.CloseCookies();
            page.MaxPrice("15");
            page.VerifyFilterLabel();
        }
    }
}