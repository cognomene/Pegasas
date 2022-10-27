using System;
using OpenQA.Selenium;

namespace BaigiamasisDarbas.Page
{
    public class BasePage
    {
        protected static IWebDriver Driver;

        public BasePage(IWebDriver webdriver)
        {
            Driver = webdriver;
        }
    }
}