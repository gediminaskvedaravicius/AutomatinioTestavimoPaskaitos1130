using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace AutoPaskaitos.BaigiamasisProjektas.Testai
{
    class Kika
    {
        private IWebDriver driver;

        [SetUp]
        public void priesKiekvienaTesta()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Url = "https://rahulshettyacademy.com/#/index";
        }
        [Test]
        public void PrisijungimoTestas()
        {

            driver.FindElement(By.CssSelector("#profile_menu > a")).Click();
            // driver.FindElement(By.LinkText("https://www.kika.lt/lt/paskyra/")).Click();
            driver.FindElement(By.Name("email")).Click();
            driver.FindElement(By.Name("email")).SendKeys("gediminaskvedaravicius@yahoo.com");
            driver.FindElement(By.Name("password")).SendKeys("BlogasSlaptazodis");

            Assert.IsTrue(driver.FindElement(By.CssSelector("#customers_login > div > div.alert.alert-danger.alert-dismissible")).Displayed);
        }
        [Test]
        public void PatikrinkArPasikeiteKalba()
        {
            driver.FindElement(By.CssSelector("body > app-root > div > header > div.header-top > div > div > div.top-right.clearfix > div:nth-child(3) > a")).Click();
            driver.FindElement(By.Id("user_email")).SendKeys("gediminaskvedaravicius@yahoo.com");
            driver.FindElement(By.Id("user_password")).SendKeys("Labas123@");
            driver.FindElement(By.Name("commit")).Click();
            Thread.Sleep(3000);
            Assert.IsTrue(driver.FindElement(By.CssSelector("body > div.view - school > div > div > div > div > div > div.row > div > div")).Displayed);

            Thread.Sleep(3000);

            driver.FindElement(By.Id("user_email")).SendKeys("gediminaskvedaravicius@yahoo.com");
            driver.FindElement(By.Id("user_email")).SendKeys("gediminaskvedaravicius@yahoo.com");
            driver.FindElement(By.Id("user_email")).SendKeys("gediminaskvedaravicius@yahoo.com");
            driver.FindElement(By.Id("user_email")).SendKeys("gediminaskvedaravicius@yahoo.com");
            driver.FindElement(By.Id("user_email")).SendKeys("gediminaskvedaravicius@yahoo.com");
            driver.FindElement(By.Id("user_email")).SendKeys("gediminaskvedaravicius@yahoo.com");


        }
        [TearDown]
        public void poKiekvienoTesto()
        {
            driver.Quit();
        }
    }
}
