using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace AutoPaskaitos.BaigiamasisProjektas.Testai
{
    class Kika
    {
        private IWebDriver driver;
        private IWebElement logInButton => driver.FindElement(By.CssSelector("#masthead > div.header-inner.flex-row.container.logo-center.medium-logo-center > div.flex-col.hide-for-medium.flex-right > ul > li.account-item.has-icon > a > i"));
        private IWebElement emailBox => driver.FindElement(By.Id("username"));
        private IWebElement password => driver.FindElement(By.Id("password"));
        private IWebElement logIn => driver.FindElement(By.Name("login"));
        private IWebElement fault => driver.FindElement(By.CssSelector(".woocommerce-error > li")); // del sitos
        private IWebElement wrong => driver.FindElement(By.LinkText(" yra neteisingas. ")); // del sitos

        [SetUp]
        public void priesKiekvienaTesta()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Url = "https://www.kika.lt/";
        }
        [Test]
        public void PrisijungimoTestas()
        {
            driver.FindElement(By.CssSelector(".ico-profile")).Click();
            driver.FindElement(By.CssSelector(".form-group:nth-child(2) > .form-control")).SendKeys("gediminaskvedaravicius@yahoo.com");
            driver.FindElement(By.Name("password")).SendKeys("blogas");
            driver.FindElement(By.CssSelector(".btn-primary:nth-child(1)")).Click();

            Assert.AreEqual("×\r\nNeteisingai bandyta prisijungti daugiau nei 5 kartus, vartotojas blokuojamas. Paskyros atblokavimo nuoroda išsiųsta el. paštu", driver.FindElement(By.CssSelector(".alert-dismissible")).Text);
        }
        [Test]
        public void ArEsuTinkamamePuslapyje()
        {
            driver.FindElement(By.CssSelector(".dog > .title > a")).Click();
            driver.FindElement(By.CssSelector("#products_filter_category_tree > .title")).Click();
            driver.FindElement(By.CssSelector("#cat_3 > .text")).Click();

            Assert.AreEqual("https://www.kika.lt/katalogas/sunims/?filter=categories:3xxx", driver.Url);
        }
        [Test]
        public void ArEsuTinkamamePuslapyje2()
        {
            Actions builder = new Actions(driver);
            builder.MoveToElement(driver.FindElement(By.CssSelector(".dog > .title > a"))).Build().Perform();
            driver.FindElement(By.LinkText("Maistas ir skanėstai")).Click();

            Assert.AreEqual("https://www.kika.lt/katalogas/sunims/maistas-ir-skanestai/", driver.Url);
        }
        [Test]
        public void KrepselioTestas()
        {
            Actions builder = new Actions(driver);
            builder.MoveToElement(driver.FindElement(By.CssSelector(".dog > .title > a"))).Build().Perform();
            driver.FindElement(By.LinkText("Maistas ir skanėstai")).Click();
            Thread.Sleep(3000);

            driver.FindElement(By.CssSelector(".product_element:nth-child(1) .btn")).Click();
            Thread.Sleep(3000);
            driver.FindElement(By.CssSelector(".product_element:nth-child(2) .btn")).Click();
            Thread.Sleep(3000);
            driver.FindElement(By.CssSelector(".product_element:nth-child(4) .btn")).Click();
            Thread.Sleep(3000);
            driver.FindElement(By.CssSelector(".ico-cart")).Click();

            Assert.AreEqual("NATURE'S PROTECTION DOG ADULT VEAL KONSERVUOTAS PAŠARAS ŠUNIMS", driver.FindElement(By.CssSelector(".item:nth-child(1) > .info a")).Text);
            Assert.AreEqual("NATURE'S PROTECTION DOG ADULT VEAL KONSERVUOTAS PAŠARAS ŠUNIMS", driver.FindElement(By.CssSelector(".item:nth-child(2) > .info a")).Text);
            Assert.AreEqual("NATURE'S PROTECTION DOG ADULT VEAL KONSERVUOTAS PAŠARAS ŠUNIMS", driver.FindElement(By.CssSelector(".item:nth-child(3) > .info a")).Text);

            Assert.AreEqual("PAKUOTĖ\r\n200 g", driver.FindElement(By.CssSelector(".item:nth-child(1) .wrp > .item_name")).Text);
            Assert.AreEqual("SUMA\r\n1,43 €\r\n1,79 €", driver.FindElement(By.CssSelector(".item:nth-child(1) .wrp > .price")).Text);
        }

        [TearDown]
        public void poKiekvienoTesto()
        {
            driver.Quit();
        }
    }
}
