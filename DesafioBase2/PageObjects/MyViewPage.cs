using OpenQA.Selenium;

namespace PageObjects
{
    public class PageMyView
    {
        IWebDriver driver;
        int timeOutInSeconds;

        public PageMyView(IWebDriver driver, int timeOutInSeconds)
        {
            this.driver = driver;
            this.timeOutInSeconds = timeOutInSeconds;
        }


        public By LoggedAs()
        {
            return By.ClassName("login-info-left");
        }

        public IWebElement TextLoggedAs()
        {
            return driver.FindElement(LoggedAs(), timeOutInSeconds);
        }

        public IWebElement TextPasswordOrUserIncorrect()
        {
            return driver.FindElement(By.XPath("//font[text() = 'Your account may be disabled or blocked or the username/password you entered is incorrect.']"), timeOutInSeconds);
        }

    }
}
