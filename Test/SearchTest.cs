using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using BaigiamasisDarbas.Page;
using BaigiamasisDarbas.Tools;
using NUnit.Framework.Interfaces;

namespace BaigiamasisDarbas.Test
{
    public class SearchTest
    {
        private static IWebDriver chromeDriver;

        [OneTimeSetUp]
        public static void OneTimeSetup()
        {
            chromeDriver = new ChromeDriver();
            chromeDriver.Manage().Window.Maximize();
            chromeDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
        }

        [TearDown]
        public static void Teardown()
        {
            if (TestContext.CurrentContext.Result.Outcome != ResultState.Success)
            {
                MyScreenshot.TakeScreenshot(chromeDriver);
            }
        }

        [OneTimeTearDown]
        public static void OneTimeTearDown()
        {
            chromeDriver.Quit();
        }

        [Test]
        public static void SearchCheck()
        {
            SearchPage page = new SearchPage(chromeDriver);
            page.NavigateToPage();
            page.CloseCookies();
            page.SearchBook();
            page.VerifyBookIsFound();
            page.ClickOnBook();
            page.VerifyBookPageOpens("https://www.pegasas.lt/1984-ieji-4-oji-laida-2186234/");

        }
    }
}