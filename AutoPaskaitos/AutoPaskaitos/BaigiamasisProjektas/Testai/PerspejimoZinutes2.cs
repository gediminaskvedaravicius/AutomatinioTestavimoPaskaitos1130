using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace AutoPaskaitos.BaigiamasisProjektas.Testai
{
    class PerspejimoZinutes2 : Bazine
    {
        private IWebElement zaliosUzsidaranciosZinutesMygtukas => driver.FindElement(By.Id("autoclosable-btn-success"));
        private IWebElement alertaiIrModeliniaiMygtukas => driver.FindElement(By.LinkText("Alerts & Modals"));
        private IWebElement bootstrapAlertsMygtukas => driver.FindElement(By.LinkText("Bootstrap Alerts"));


        private IWebElement zaliaPatiUzsidarantiZinute
        {
            get
            {
                try
                {
                    return driver.FindElement(By.CssSelector(".alert-autocloseable-success[style='display: block;']"));
                }
                catch (NoSuchElementException)
                {
                    return null;
                }
            }
        }

        [Test]
        public void PatikrinkArVeikiaPerspejimoZinute()
        {
            alertaiIrModeliniaiMygtukas.Click();
            bootstrapAlertsMygtukas.Click();
            zaliosUzsidaranciosZinutesMygtukas.Click();
            Assert.IsNotNull(zaliaPatiUzsidarantiZinute);

            WebDriverWait waitas = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            waitas.Until(ExpectedConditions.InvisibilityOfElementLocated(By.CssSelector(".alert-autocloseable-success[style='display: block;']")));

            Assert.IsNull(zaliaPatiUzsidarantiZinute);

        }

        [TearDown]
        public void close_Browser()
        {
            driver.Quit();
        }
    }
}
