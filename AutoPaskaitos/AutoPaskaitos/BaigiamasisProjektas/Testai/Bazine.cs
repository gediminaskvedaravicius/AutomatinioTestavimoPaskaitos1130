using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.Extensions;
using System;
using System.IO;

namespace AutoPaskaitos.BaigiamasisProjektas.Testai
{
    class Bazine
    {
        public IWebDriver driver;

        [SetUp]
        public void priesKiekvienaTesta()
        {
            PerduotiDriveri("chrome");
            //driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Url = "https://www.seleniumeasy.com/test/";
            // papildomas zingsnis siam puslapiui
            try
            {
                driver.FindElement(By.Id("at-cv-lightbox-close")).Click();
            }
            catch(WebDriverException)
            {
               
            }              
        }
        public void PerduotiDriveri(string driverPavadinimas)
        {
            if(driverPavadinimas=="chrome")
            {
                driver = new ChromeDriver(GautiChromoPradinesKonfiguracijas());
            }
            if(driverPavadinimas=="firefox")
            {
                driver = new FirefoxDriver();
            }
        }
        public ChromeOptions GautiChromoPradinesKonfiguracijas()
        {
            ChromeOptions konfiguracijos = new ChromeOptions();
            konfiguracijos.AddArguments("start-maximized", "incognito");
            //konfiguracijos.AddArgument("headless");
            return konfiguracijos;
        }
        public void PadarykScreenshota()
        {
            //pacio screenshoto padarymas
            Screenshot screenshot = driver.TakeScreenshot();
            //kompiuterio direktorijos nurodymas ir sukurimas
            string screenshotKelia = $"{TestContext.CurrentContext.WorkDirectory}/Screenshots";
            Directory.CreateDirectory(screenshotKelia);
            //screenshotui aprasyti koks pavadinimas bus suteiktas
            string screenshotFailas = Path.Combine(screenshotKelia, $"{TestContext.CurrentContext.Test.Name}.png");
            //issaugoti kaip faila
            screenshot.SaveAsFile(screenshotFailas, ScreenshotImageFormat.Png);
            TestContext.AddTestAttachment(screenshotFailas, "Mano screenshotas");
        }
        public void PadarykScreenshota2()
        {
            Screenshot screenshot = driver.TakeScreenshot();
            string screenshotKelia = $"{TestContext.CurrentContext.WorkDirectory}/Screenshots";
            Directory.CreateDirectory(screenshotKelia);
            string screenshotFailas = Path.Combine(screenshotKelia, $"{TestContext.CurrentContext.Test.Name}.png");
            screenshot.SaveAsFile(screenshotFailas, ScreenshotImageFormat.Png);
            TestContext.AddTestAttachment(screenshotFailas, "Mano screenshotas");
        }
        public void PadarykScreenshotaJeiguTestasFailed()
        {
            if (TestContext.CurrentContext.Result.Outcome.Status != TestStatus.Passed)
            {
                PadarykScreenshota();
            }
        }
        [TearDown]
        public void poKiekvienoTesto()
        {
            driver.Quit();
        }
    }
}
