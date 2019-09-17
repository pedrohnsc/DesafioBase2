using System;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;

namespace PageObjects
{
    public static class WebDriverExtensions
    {

        public static IWebElement FindElement(this IWebDriver driver, By by, int timeInSeconds)
        {
            if (timeInSeconds > 0)
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeInSeconds));
                return wait.Until(drv => drv.FindElement(by));
            }
            return driver.FindElement(by);
        }

        public static bool ElementIsPresent(this IWebDriver driver, By by)
        {
            try
            {
                return driver.FindElement(by).Displayed;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

    }
}
