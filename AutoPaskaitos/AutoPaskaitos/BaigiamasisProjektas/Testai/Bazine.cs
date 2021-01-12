using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

namespace AutoPaskaitos.BaigiamasisProjektas.Testai
{
    class Bazine
    {
        public IWebDriver driver;

        [SetUp]
        public void priesKiekvienaTesta()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Url = "https://www.seleniumeasy.com/test/basic-select-dropdown-demo.html";
            // papildomas zingsnis siam puslapiui
           // driver.FindElement(By.Id("at-cv-lightbox-close")).Click();
        }
        [TearDown]
        public void poKiekvienoTesto()
        {
            driver.Quit();
        }
    }
}
