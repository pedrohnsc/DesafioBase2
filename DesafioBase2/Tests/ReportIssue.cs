using PageObjects;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;

namespace Testes
{

    [TestFixture]
    class TestePaginaRelatarCaso
    {
        public Browser browser;
        public PageLogin loginPage;
        public PrintScreen printScreen;
        public ReportIssue reportIssuePage;
        public Constants constants;

        int timeInSeconds = 10;
        string path = @"C:\Users\pnascimento\Desktop";
        IWebDriver driver;

        [SetUp]
        public void BeforeEach()
        {
            driver = new ChromeDriver();
            loginPage = new PageLogin(driver, timeInSeconds);
            browser = new Browser(driver);
            printScreen = new PrintScreen(driver);
            reportIssuePage = new ReportIssue(driver, timeInSeconds);
            constants = new Constants(driver, timeInSeconds);

            string usuario = "pedro.nascimento";
            string senha = "123456";
            browser.WindowMaximize();
            loginPage.Visit();
            loginPage.Login(usuario, senha);
            reportIssuePage.Visit();
        }

        [TearDown]
        public void AfterEach()
        {
            printScreen.TakeScreenshot(path);

            browser.QuitBrowser();

            if (driver != null)
                driver.Dispose();
        }

        [Test]
        public void ReportIssueAndSubmit()
        {
            reportIssuePage.ReportIssueWithObrigatoryFields(ReportIssue.Categoria.TestPedro, "test", "resumetest");
            Assert.AreEqual(constants.SuccessMessage().Displayed, true);
        }

        [Test]
        public void TryToReportIssueWithoutRequiredFields()
        {
            reportIssuePage.ReportIssueWithObrigatoryFields(ReportIssue.Categoria.TestPedro, "resumetest", "");
            Assert.AreEqual(constants.ErrorMessageApllicationError11().Displayed, true);
            bool SuccessMessage = driver.ElementIsPresent(constants.BySuccessMessage());
            Assert.AreEqual(SuccessMessage, false);
        }

    }

}
