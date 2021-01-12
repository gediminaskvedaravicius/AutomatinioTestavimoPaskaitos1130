using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;

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
        [TearDown]
        public void poKiekvienoTesto()
        {
            driver.Quit();
        }
    }
}
