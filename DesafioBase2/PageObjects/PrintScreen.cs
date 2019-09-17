using System;
using System.IO;
using OpenQA.Selenium;

namespace PageObjects
{
    public class PrintScreen
    {
        IWebDriver driver;

        public PrintScreen(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void TakeScreenshot(string directory)
        {
            var screenshot = ((ITakesScreenshot)driver).GetScreenshot();
            byte[] imageBytes = Convert.FromBase64String(screenshot.ToString());

            using (BinaryWriter bw = new BinaryWriter(new FileStream(directory, FileMode.Append,
            FileAccess.Write)))
            {
                bw.Write(imageBytes);
                bw.Close();
            }
        }
    }
}
