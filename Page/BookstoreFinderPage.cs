using System;
using BaigiamasisDarbas.Page;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumExtras.WaitHelpers;
using OpenQA.Selenium.Support.UI;
using System.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace BaigiamasisDarbas.Page
{
    public class BookstoreFinderPage : BasePage
    {
        private string pageAddress => "https://www.pegasas.lt/";

        private IWebElement cookieBanner => Driver.FindElement(By.Id("CybotCookiebotDialog"));
        private IWebElement acceptMarkedCookies => Driver.FindElement(By.Id("CybotCookiebotDialogBodyLevelButtonLevelOptinAllowallSelection"));

        private IWebElement knygynuTinklas => Driver.FindElement(By.LinkText("Knygynų tinklas"));
        private IWebElement dropdownSelect => Driver.FindElement(By.CssSelector(".form-select"));
        private SelectElement dropdown => new SelectElement(Driver.FindElement(By.CssSelector(".form-select")));
        private IWebElement contacts => Driver.FindElement(By.CssSelector(".ContactPage-stores-3GF"));

        public BookstoreFinderPage(IWebDriver webdriver) : base(webdriver) { }

        public void NavigateToPage()
        {
            Driver.Url = pageAddress;
        }

        public void CloseCookies()
        {
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.Id("CybotCookiebotDialogBodyLevelButtonLevelOptinAllowallSelection")));
            Assert.AreEqual("Patvirtinti pažymėtus", acceptMarkedCookies.Text, message: "Wrong button");
            acceptMarkedCookies.Click();
        }

        public void Click_KnygynuTinklas()
        {
            knygynuTinklas.Click();
        }

        public void Open_Dropdown()
        {
            dropdownSelect.Click();
        }

        public void Select_City(string text)
        {
            dropdown.SelectByText(text);
        }

        public void Verify_CityPageLink(string link)
        {
            string siauliuPageAddress = link;
            Assert.IsTrue(Driver.Url == siauliuPageAddress);
        }

        public void Verify_ContactsAreDisplayed()
        {
            Assert.IsTrue(contacts.Displayed);
        }
    }
}