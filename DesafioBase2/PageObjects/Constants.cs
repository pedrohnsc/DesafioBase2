using OpenQA.Selenium;

namespace PageObjects
{
    public class Constants
    {
        IWebDriver driver;
        int timeOutInSeconds;

        public Constants(IWebDriver driver, int timeOutInSeconds)
        {
            this.driver = driver;
            this.timeOutInSeconds = timeOutInSeconds;
        }

        public IWebElement SuccessMessage()
        {
            return driver.FindElement(BySuccessMessage());
        }
        public By BySuccessMessage()
        {
            return By.XPath("//div[contains(text(), 'Operação realizada com sucesso.')]");
        }
        public IWebElement ErrorMessageApllicationError11()
        {
            return driver.FindElement(By.XPath("//td[text()='APPLICATION ERROR #11']"), timeOutInSeconds);
        }

        public void ClickSeeCaseSend()
        {
            driver.FindElement(By.XPath("//a[contains(text(), 'Visualizar Caso Enviado')]"), timeOutInSeconds).Click();
        }
    }
}
