using System;
using OpenQA.Selenium;

namespace PageObjects
{

    public class Browser
    {
        IWebDriver driver;

        public Browser(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void NavigateTo(String url)
        {
            driver.Navigate().GoToUrl(url);
        }

        public void WindowMaximize()
        {
            driver.Manage().Window.Maximize();
        }

        public void QuitBrowser()
        {
            driver.Close();
        }

    }
}
