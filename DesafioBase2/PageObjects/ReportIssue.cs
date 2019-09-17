using OpenQA.Selenium;

namespace PageObjects
{
    public class ReportIssue
    {
        IWebDriver driver;
        public Browser browser;
        int timeOutInSeconds;

        public ReportIssue(IWebDriver driver, int timeOutInSeconds)
        {
            this.driver = driver;
            this.timeOutInSeconds = timeOutInSeconds;
        }

        public enum Categoria
        {
            Selecione = 1,
            Value66 = 66,
            OtherTest = 59,
            TestPedro = 65
        }
        public void FillListCategory(Categoria category)
        {
            driver.FindElement(By.Name("category_id"), timeOutInSeconds).Click();
            driver.FindElement(By.XPath("//option[@value='" + (int)category + "']"), timeOutInSeconds).Click();
        }

        public void FillDescription(string description)
        {
            driver.FindElement(By.Name("description"), timeOutInSeconds).SendKeys(description);
        }
        public void FillResume(string resume)
        {
            driver.FindElement(By.Name("summary"), timeOutInSeconds).SendKeys(resume);
        }
        public void ClickButtonSendForm()
        {
            driver.FindElement(By.XPath("//input[@value='Enviar Relatório']"), timeOutInSeconds).Click();
        }

        public void ReportIssueWithObrigatoryFields(Categoria category, string resume, string description)
        {
            FillListCategory(category);
            FillResume(resume);
            FillDescription(description);
            ClickButtonSendForm();
        }
        public void Visit()
        {
            browser = new Browser(driver);
            browser.NavigateTo("http://mantis-prova.base2.com.br/bug_report_page.php");
        }
    }
}
