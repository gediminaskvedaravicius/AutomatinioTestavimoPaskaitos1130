using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using System;


namespace AutoPaskaitos.BaigiamasisProjektas.Testai
{
    class TraukinioBilietas
    {
        private IWebDriver driver;
        [SetUp]
        public void priesKiekvienaTesta()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Url = "https://www.traukiniobilietas.lt/portal/";
        }
        [Test]
        public void PakeiskKalbaIAnglu()
        {
            driver.FindElement(By.CssSelector(".top-languages > span")).Click();
            driver.FindElement(By.LinkText("EN")).Click();

            Assert.AreEqual("Where would you like to go today?x", driver.FindElement(By.CssSelector(".front-title > h1")).Text);
        }

        [TearDown]
        public void poKiekvienoTesto()
        {
            driver.Quit();
        }
    }
}
