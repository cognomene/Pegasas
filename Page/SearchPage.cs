using System;
using BaigiamasisDarbas.Page;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumExtras.WaitHelpers;
using OpenQA.Selenium.Support.UI;
using System.Linq;
using static System.Net.Mime.MediaTypeNames;
using OpenQA.Selenium.Interactions;

namespace BaigiamasisDarbas.Page
{
    public class SearchPage : BasePage
    {
        private string pageAddress => "https://www.pegasas.lt/";

        private IWebElement cookieBanner => Driver.FindElement(By.Id("CybotCookiebotDialog"));
        private IWebElement acceptMarkedCookies => Driver.FindElement(By.Id("CybotCookiebotDialogBodyLevelButtonLevelOptinAllowallSelection"));

        private IWebElement searchInput => Driver.FindElement(By.CssSelector(".flex-grow-1 .lupa-search-box-input-field"));

        private IWebElement bookName => Driver.FindElement(By.LinkText("1984-ieji (4-oji laida)"));


        private string bookPage => "https://www.pegasas.lt/1984-ieji-4-oji-laida-2186234/";

        public SearchPage(IWebDriver webdriver) : base(webdriver) { }

        public void NavigateToPage()
        {
            Driver.Url = pageAddress;
        }

        public void CloseCookies()
        {
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.Id("CybotCookiebotDialogBodyLevelButtonLevelOptinAllowallSelection")));
            //Assert.AreEqual("Patvirtinti pažymėtus", acceptMarkedCookies.Text, message: "Wrong button");
            acceptMarkedCookies.Click();
        }

        public void SearchBook()
        {
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.CssSelector(".flex-grow-1 .lupa-search-box-input-field")));

            searchInput.Click();
            searchInput.SendKeys("1984");

            Actions action = new Actions(Driver);
            action.KeyDown(Keys.Enter);
            action.KeyUp(Keys.Enter);
            action.Build().Perform();
        }

        public void VerifyBookIsFound()
        {
            Assert.AreEqual("1984-ieji (4-oji laida)", bookName.Text, message: "Wrong book");
        }

        public void ClickOnBook()
        {
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(15));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.LinkText("1984-ieji (4-oji laida)")));
            bookName.Click();
        }

        public void VerifyBookPageOpens(string link)
        {
            string bookPageLink = link;
            Assert.IsTrue(Driver.Url == bookPageLink);

        }
    }
}