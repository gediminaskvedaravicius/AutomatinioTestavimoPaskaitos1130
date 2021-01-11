using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;

namespace AutoPaskaitos._1Auto
{
    class IvedimoLaukai
    {
        [Test]
        public void RodykZinute()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Url = "https://www.seleniumeasy.com/test/basic-first-form-demo.html";
            driver.Manage().Window.Maximize();

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(120);

            driver.FindElement(By.Id("at-cv-lightbox-closeXX")).Click();


            string irasomasTekstas = "Tekšktas";

            driver.FindElement(By.Id("user-message")).SendKeys(irasomasTekstas);
            driver.FindElement(By.CssSelector("#get-input button")).Click();

            Assert.AreEqual(irasomasTekstas, driver.FindElement(By.Id("display")).Text);
        }
        [Test]
        public void ApskaiciuokSuma()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Url = "https://www.seleniumeasy.com/test/basic-first-form-demo.html";
            driver.Manage().Window.Maximize();
            driver.FindElement(By.Id("at-cv-lightbox-close")).Click();

            driver.FindElement(By.Id("sum1")).SendKeys("10");
            driver.FindElement(By.Id("sum2")).SendKeys("5");
            driver.FindElement(By.CssSelector("#gettotal button")).Click();

            Assert.AreEqual("15", driver.FindElement(By.Id("displayvalue")).Text);
        }

        [Test]
        public void UzkroveSimtuProcentu()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Url = "https://www.seleniumeasy.com/test/bootstrap-download-progress-demo.html";
            driver.Manage().Window.Maximize();
            //driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(120);

            driver.FindElement(By.Id("cricle-btn")).Click();
            driver.FindElement(By.Id("cricle-btn")).Click();
            driver.FindElement(By.Id("cricle-btn")).Click();
            driver.FindElement(By.Id("cricle-btn")).Click();
            driver.FindElement(By.Id("cricle-btn")).Click();

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            wait.Until(
                ExpectedConditions.TextToBePresentInElement(driver.FindElement(By.ClassName("percenttext")),"100%"));

            Assert.AreEqual("100%", driver.FindElement(By.ClassName("percenttext")).Text);

            Assert.IsTrue(driver.FindElement(By.Id("atsijungti")).Displayed);
        }

        [Test]
        public void PatikrinkArVisiCheckboxPazymeti()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Url = "https://www.seleniumeasy.com/test/basic-checkbox-demo.html";
            driver.Manage().Window.Maximize();
           // driver.FindElement(By.Id("at-cv-lightbox-close")).Click();

            var checkboxai = driver.FindElements(By.ClassName("cb1-element"));
            var checkboxas = driver.FindElement(By.ClassName("cb1-element"));


            foreach (var checkboxElementas in checkboxai) 
            {
                checkboxElementas.Click();
                Thread.Sleep(2000);
            }

            checkboxas.Click();


            foreach (var checkboxElementas in checkboxai)
            {
                Assert.IsTrue(checkboxElementas.Selected);
            }


        }

        [Test]
        public void Melynas()
        {
        }
    }
}
