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
            driver.Url = "https://wolt.com/lt/ltu/?gdpr=&tld=lt&fbclid=IwAR1pGrd-I4MV8KPUB-T2UQsQU0w_vvfOHWJAiD0x46JJSh4olwdpN-2VB5M";
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
            driver.FindElement(By.CssSelector("#app > div > div > div:nth-child(2) > div:nth-child(5) > div > div.ModalWithAnimationWrapper__root___3bsCj > div > div > div > div > div.ConsentsBanner__buttons___1Lyem > div:nth-child(2) > button")).Click();
            Thread.Sleep(3000);
        }
        [TearDown]
        public void poKiekvienoTesto()
        {
            driver.Quit();
        }
    }
}
