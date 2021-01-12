using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace AutoPaskaitos.BaigiamasisProjektas.Puslapiai
{
    class DropdownPuslapis : BazinePuslapiu
    {
        public DropdownPuslapis(IWebDriver driver) : base(driver) { }

        private IWebElement paprastasDropdownas => driver.FindElement(By.Id("select-demo"));

        //var selectElement = new SelectElement(education);

        public void PasirinktiElementa()
        {
            SelectElement pasirinktiReiksmeIsDropdowno = new SelectElement(paprastasDropdownas);
            pasirinktiReiksmeIsDropdowno.SelectByText("Wednesday");
        }
    }
}
