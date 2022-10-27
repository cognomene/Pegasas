using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using BaigiamasisDarbas.Page;
using BaigiamasisDarbas.Tools;
using NUnit.Framework.Interfaces;

namespace BaigiamasisDarbas.Test
{
    public class BookstoreFinderTest
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
        public static void Bookstores_Siauliai()
        {
            BookstoreFinderPage page = new BookstoreFinderPage(chromeDriver);
            page.NavigateToPage();
            page.CloseCookies();
            page.Click_KnygynuTinklas();
            page.Open_Dropdown();
            page.Select_City("Šiauliai");
            page.Open_Dropdown();
            page.Verify_CityPageLink("https://www.pegasas.lt/c/kontaktai/%C5%A0iauliai");
            page.Verify_ContactsAreDisplayed();
        }
    }
}