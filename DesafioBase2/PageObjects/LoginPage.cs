using OpenQA.Selenium;

namespace PageObjects
{
    public class PageLogin
    {
        IWebDriver driver;
        public Browser browser;
        int timeInSeconds;

        public PageLogin(IWebDriver driver, int timeOutInSeconds)
        {
            this.driver = driver;
            this.timeInSeconds = timeOutInSeconds;
        }

        public void Login(string usuario, string senha)
        {
            InputUser().Clear();
            InputUser().SendKeys(usuario);
            InputPassword().Clear();
            InputPassword().SendKeys(senha);
            ButtonLogin().Click();
        }

        public IWebElement InputUser()
        {

            return driver.FindElement(By.Name("username"), timeInSeconds);
        }


        public IWebElement ButtonLogin()
        {
            return driver.FindElement(By.CssSelector("[value='Login']"), timeInSeconds);
        }

        public IWebElement InputPassword()
        {
            return driver.FindElement(By.Name("password"), timeInSeconds);
        }

        public void Visit()
        {
            browser = new Browser(driver);
            browser.NavigateTo("http://mantis-prova.base2.com.br");
        }

    }
}
