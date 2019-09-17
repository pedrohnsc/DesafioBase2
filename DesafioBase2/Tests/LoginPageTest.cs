using PageObjects;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;

namespace Testes
{

    [TestFixture]
    class TestePaginaLogin
    {
        public Browser browser;
        public PageLogin loginPage;
        public PrintScreen printScreen;
        public PageMyView myViewPage;

        int timeoutInSeconds = 10;
        string path = @"C:\Users\pnascimento\Desktop";
        IWebDriver driver;

        [SetUp]
        public void BeforeEach()
        {
            driver = new ChromeDriver();
            loginPage = new PageLogin(driver, timeoutInSeconds);
            browser = new Browser(driver);
            printScreen = new PrintScreen(driver);
            browser.WindowMaximize();
            loginPage.Visit();
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
        public void DoLogin()
        {
            string usuario = "pedro.nascimento";
            string senha = "123456";

            loginPage.Login(usuario, senha);

            myViewPage = new PageMyView(driver, timeoutInSeconds);
            Assert.AreEqual(myViewPage.TextLoggedAs().Displayed, true);
        }


        [Test, Pairwise]
        public void FailedLogin(
            [Values("banana", "", "!!!!!!!!")] string usuario,
            [Values("banana", "", "@@@@@@@@")] string senha)
        {
            loginPage.Login(usuario, senha);

            myViewPage = new PageMyView(driver, timeoutInSeconds);
            Assert.AreEqual(myViewPage.TextPasswordOrUserIncorrect().Displayed, true);

            bool textAccessAs = driver.ElementIsPresent(myViewPage.LoggedAs());
            Assert.AreEqual(textAccessAs, false);
        }

    }

}
