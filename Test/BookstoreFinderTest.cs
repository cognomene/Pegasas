using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using BaigiamasisDarbas.Page;
using BaigiamasisDarbas.Tools;
using NUnit.Framework.Interfaces;

namespace BaigiamasisDarbas.Test
{
    public class BookstoreFinderTest : BaseTest
    {
        [Test]
        public static void Bookstores_Siauliai()
        {
            bookStoreFinderPage.NavigateToPage();
            bookStoreFinderPage.Click_KnygynuTinklas();
            bookStoreFinderPage.Open_Dropdown();
            bookStoreFinderPage.Select_City("Šiauliai");
            bookStoreFinderPage.Open_Dropdown();
            bookStoreFinderPage.Verify_CityPageLink("https://www.pegasas.lt/c/kontaktai/%C5%A0iauliai");
            bookStoreFinderPage.Verify_ContactsAreDisplayed();
        }
    }
}