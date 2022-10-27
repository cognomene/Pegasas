using System;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using BaigiamasisDarbas.Page;
using BaigiamasisDarbas.Tools;

namespace BaigiamasisDarbas.Test
{
    public class BaseTest
    {
        protected static IWebDriver chromeDriver;
        protected static FirstLevelMenuPage firstLevelMenuPage;
        protected static BookstoreFinderPage bookStoreFinderPage;
        protected static PriceFilterCheckPage priceFilterCheckPage;
        protected static SearchPage searchPage;


        [OneTimeSetUp]
        public static void OneTimeSetup()
        {
            chromeDriver = new ChromeDriver();
            firstLevelMenuPage = new FirstLevelMenuPage(chromeDriver);
            bookStoreFinderPage = new BookstoreFinderPage(chromeDriver);
            priceFilterCheckPage = new PriceFilterCheckPage(chromeDriver);
            searchPage = new SearchPage(chromeDriver);
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

    }
}

