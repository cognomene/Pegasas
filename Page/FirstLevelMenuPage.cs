using System;
using BaigiamasisDarbas.Page;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumExtras.WaitHelpers;
using OpenQA.Selenium.Support.UI;

namespace BaigiamasisDarbas.Page
{
    public class FirstLevelMenuPage : BasePage
    {
        private string pageAddress => "https://www.pegasas.lt/";

        private IWebElement cookieBanner => Driver.FindElement(By.Id("CybotCookiebotDialog"));
        private IWebElement acceptMarkedCookies => Driver.FindElement(By.Id("CybotCookiebotDialogBodyLevelButtonLevelOptinAllowallSelection"));

        private IWebElement naujosKnygos => Driver.FindElement(By.LinkText("Naujos knygos"));
        private IWebElement netrukusPasirodys => Driver.FindElement(By.LinkText("Netrukus pasirodys"));
        private IWebElement topKnygos => Driver.FindElement(By.LinkText("TOP knygos"));
        private IWebElement pegasoKolekcija => Driver.FindElement(By.LinkText("Pegaso kolekcija"));
        private IWebElement kakeMake => Driver.FindElement(By.LinkText("Kakė Makė"));
        private IWebElement dovanuKuponai => Driver.FindElement(By.LinkText("Dovanų kuponai"));
        private IWebElement superkainos => Driver.FindElement(By.LinkText("Rudens SUPERKAINOS"));

        public FirstLevelMenuPage(IWebDriver webdriver) : base(webdriver) { }

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

        // Click methods
        public void Click_NaujosKnygos()
        {
            naujosKnygos.Click();
        }

        public void Click_NetrukusPasirodys()
        {
            netrukusPasirodys.Click();
        }

        public void Click_TopKnygos()
        {
            topKnygos.Click();
        }

        public void Click_PegasoKolekcija()
        {
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.CssSelector("#root > main > nav > div > ol > li.breadcrumb-item.active")));
            pegasoKolekcija.Click();
        }

        public void Click_KakeMake()
        {
            kakeMake.Click();
        }

        public void Click_DovanuKuponai()
        {
            dovanuKuponai.Click();
        }

        public void Click_Superkainos()
        {
            superkainos.Click();
        }

        // Assert methods
        public void Verify_NaujosKnygos_Link(string link)
        {
            string naujosKnygosLink = link;
            Assert.IsTrue(Driver.Url == naujosKnygosLink);
        }

        public void Verify_NetrukusPasirodys_Link(string link)
        {
            string netrukusPasirodysLink = link;
            Assert.IsTrue(Driver.Url == netrukusPasirodysLink);
        }

        public void Verify_TopKnygos_Link(string link)
        {
            string topKnygosLink = link;
            Assert.IsTrue(Driver.Url == topKnygosLink);
        }

        public void Verify_PegasoKolekcija_Link(string link)
        {
            string pegasoKolekcijaLink = link;
            Assert.IsTrue(Driver.Url == pegasoKolekcijaLink);
        }

        public void Verify_KakeMake_Link(string link)
        {
            string kakeMakeLink = link;
            Assert.IsTrue(Driver.Url == kakeMakeLink);
        }

        public void Verify_DovanuKuponai_Link(string link)
        {
            string dovanuKuponaiLink = link;
            Assert.IsTrue(Driver.Url == dovanuKuponaiLink);
        }

        public void Verify_Superkainos_Link(string link)
        {
            string superkainosLink = link;
            Assert.IsTrue(Driver.Url == superkainosLink);
        }
    }
}