using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace AutoPaskaitos.BaigiamasisProjektas.Puslapiai
{
    class DropdownPuslapis : BazinePuslapiu
    {
        public DropdownPuslapis(IWebDriver driver) : base(driver) { }

        private IWebElement paprastasDropdownas => driver.FindElement(By.Id("select-demo"));
        private IWebElement inputFormsMygtukas => driver.FindElement(By.LinkText("Input Forms"));
        private IWebElement selectDropdownListMygtukas => driver.FindElement(By.LinkText("Select Dropdown List"));
        private IWebElement atsiradesTekstas => driver.FindElement(By.ClassName("selected-value"));

        public DropdownPuslapis nunaviguotiIDropdownPuslapi()
        {
            inputFormsMygtukas.Click();
            selectDropdownListMygtukas.Click();
            return this;
        }
        public DropdownPuslapis PasirinktiElementaPagalIndeksa(int indeksas)
        {
            SelectElement pasirinktiReiksmeIsDropdowno = new SelectElement(paprastasDropdownas);
            pasirinktiReiksmeIsDropdowno.SelectByIndex(indeksas);
            return this;
        }
        public DropdownPuslapis PasirinktiElementaPagalText(string tekstas)
        {
            SelectElement pasirinktiReiksmeIsDropdowno = new SelectElement(paprastasDropdownas);
            pasirinktiReiksmeIsDropdowno.SelectByText(tekstas);
            return this;
        }
        public DropdownPuslapis PasirinktiElementaPagalValue(string value)
        {
            SelectElement pasirinktiReiksmeIsDropdowno = new SelectElement(paprastasDropdownas);
            pasirinktiReiksmeIsDropdowno.SelectByValue(value);
            return this;
        }
        public DropdownPuslapis PatikrinkArAtsiradesTekstasTeisingas(string tekstasKurioTikiuosi)
        {
            Assert.AreEqual(tekstasKurioTikiuosi, atsiradesTekstas.Text);
            return this;
        }
        
    }
}
