using NUnit.Framework;
using OpenQA.Selenium;
using System.Threading;

namespace AutoPaskaitos.BaigiamasisProjektas.Testai
{
    class PerspejimoZinutes : Bazine
    {
        //private IWebElement csslokatoriauspavyzdys => driver.FindElement(By.CssSelector("[for='kazkokiaReiksme']"));
        private IWebElement zaliosNeuzisdaranciosZinutesMygtukas => driver.FindElement(By.Id("normal-btn-success"));
        private IWebElement zaliosNeuzisdaranciosZinutesUzdarymoMygtukas => driver.FindElement(By.CssSelector(".alert-normal-success[style='display: block;'] .close"));
        private IWebElement alertaiIrModeliniaiMygtukas => driver.FindElement(By.LinkText("Alerts & Modals"));
        private IWebElement bootstrapAlertsMygtukas => driver.FindElement(By.LinkText("Bootstrap Alerts"));


        private IWebElement zaliaNeuzisdarantiZinute
        {
            get
            {
                try
                {
                    return driver.FindElement(By.CssSelector(".alert-normal-success[style='display: block;']"));
                }
                catch(NoSuchElementException)
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
            zaliosNeuzisdaranciosZinutesMygtukas.Click();
            Assert.IsNotNull(zaliaNeuzisdarantiZinute);
            Thread.Sleep(2000);
            zaliosNeuzisdaranciosZinutesUzdarymoMygtukas.Click();
            Assert.IsNull(zaliaNeuzisdarantiZinute);
        }



    }
}
