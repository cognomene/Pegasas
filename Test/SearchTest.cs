using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using BaigiamasisDarbas.Page;
using BaigiamasisDarbas.Tools;
using NUnit.Framework.Interfaces;

namespace BaigiamasisDarbas.Test
{
    public class SearchTest : BaseTest
    {
        [Test]
        public static void SearchCheck()
        {
            searchPage.NavigateToPage();
            searchPage.CloseCookies();
            searchPage.SearchBook();
            searchPage.VerifyBookIsFound();
            searchPage.ClickOnBook();
            searchPage.VerifyBookPageOpens("https://www.pegasas.lt/1984-ieji-4-oji-laida-2186234/");
        }
    }
}