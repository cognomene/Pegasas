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
    public class PriceFilterCheckPage : BasePage
    {
        private string pageAddress => "https://www.pegasas.lt/elektronines-knygos/";

        private IWebElement cookieBanner => Driver.FindElement(By.Id("CybotCookiebotDialog"));
        private IWebElement acceptMarkedCookies => Driver.FindElement(By.Id("CybotCookiebotDialogBodyLevelButtonLevelOptinAllowallSelection"));

        private IWebElement maxPriceInput => Driver.FindElement(By.CssSelector(".lupa-stats-to > input"));
        private IWebElement filter => Driver.FindElement(By.CssSelector(".lupa-current-filter-value"));

        public PriceFilterCheckPage(IWebDriver webdriver) : base(webdriver) { }

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

        public void MaxPrice(string maxPrice)
        {
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.CssSelector(".lupa-stats-to > input")));

            Actions action = new Actions(Driver);
            
            maxPriceInput.Clear();
            maxPriceInput.SendKeys(maxPrice);

            action.KeyDown(Keys.Enter);
            action.KeyUp(Keys.Enter);
            action.Build().Perform();
        }

        public void VerifyFilterLabel()
        {
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(5));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.CssSelector(".filter-values")));
            Assert.AreEqual("0,00 € - 15,00 €", filter.Text, message: "Filter incorrect");
        }

    }
}