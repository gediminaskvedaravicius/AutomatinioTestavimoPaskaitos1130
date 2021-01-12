using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using TechTalk.SpecFlow;

namespace SpecFlow2.Steps
{
    [Binding]
    public sealed class CalculatorStepDefinitions
    {
        private int pirmasNumeris;
        private int antrasNumeris;
        private int suma;
        private IWebDriver driver;

        [Given("the first number is (.*)")]
        public void GivenTheFirstNumberIs(int number)
        {
            pirmasNumeris = number;
        }

        [Given("the second number is (.*)")]
        public void GivenTheSecondNumberIs(int number)
        {
            antrasNumeris = number;
        }

        [When("the two numbers are added")]
        public void WhenTheTwoNumbersAreAdded()
        {
            suma = pirmasNumeris + antrasNumeris;
        }

        [Then("the result should be (.*)")]
        public void ThenTheResultShouldBe(int result)
        {
            Assert.AreEqual(result, suma);
        }
        [Given(@"naudojas yra selenium easy puslapyje")]
        public void GivenNaudojasYraSeleniumEasyPuslapyje()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Url = "https://www.seleniumeasy.com/test/";
            // papildomas zingsnis siam puslapiui
            try
            {
                driver.FindElement(By.Id("at-cv-lightbox-close")).Click();
            }
            catch (WebDriverException)
            {

            }
        }
        [When(@"naudojas ives ""(.*)"" i laukeli")]
        public void WhenNaudojasIvesILaukeli(string tekstas)
        {
            driver.FindElement(By.LinkText("Input Forms")).Click();
            driver.FindElement(By.LinkText("Simple Form Demo")).Click();
            driver.FindElement(By.Id("user-message")).SendKeys(tekstas);
        }
        [When(@"naudojas paspaus mygtuka")]
        public void WhenNaudojasPaspausMygtuka()
        {
            driver.FindElement(By.CssSelector("#get-input button")).Click();
        }
        [Then(@"tekstas turi atsivaizduoti apacioje")]
        public void ThenTekstasTuriAtsivaizduotiApacioje()
        {
            Assert.AreEqual("Tekstas", driver.FindElement(By.Id("display")).Text);
        }
        [Then(@"naudotojas uzdaro narsykle")]
        public void ThenNaudotojasUzdaroNarsykle()
        {
            driver.Quit();
        }





    }
}
