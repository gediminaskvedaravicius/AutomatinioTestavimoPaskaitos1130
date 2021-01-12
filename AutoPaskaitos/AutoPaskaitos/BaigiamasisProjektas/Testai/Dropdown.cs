using AutoPaskaitos.BaigiamasisProjektas.Puslapiai;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace AutoPaskaitos.BaigiamasisProjektas.Testai
{
    class Dropdown : Bazine
    {
        private DropdownPuslapis dropdownPuslapis;

        [SetUp]
        public void PriesKiekvienaTesta()
        {
            dropdownPuslapis = new DropdownPuslapis(driver);
        }
        [Test]
        public void PasirinkSekmadieni()
        {
            string pirmadienis = "Monday";
            string antradienis = "Tuesday";
            string treciadienis = "Wednesday";

            dropdownPuslapis
                .nunaviguotiIDropdownPuslapi()
                .PasirinktiElementaPagalText(pirmadienis)
                .PatikrinkArAtsiradesTekstasTeisingas($"Day selected :- {pirmadienis}");
            Thread.Sleep(3000);
            try 
            {
                dropdownPuslapis
                .PasirinktiElementaPagalText("Betkas")
                .PatikrinkArAtsiradesTekstasTeisingas($"Day selected :- {treciadienis}");
            }
            catch(WebDriverException)
            {

            }
            
            Thread.Sleep(3000);
            dropdownPuslapis
                .PasirinktiElementaPagalText(treciadienis)
                .PatikrinkArAtsiradesTekstasTeisingas($"Day selected :- {treciadienis}");
            Thread.Sleep(3000);

        }
        [Test]
        public void PasirinkPirmadieni()
        {
            string savaitesDiena = "Monday";

            dropdownPuslapis
                .nunaviguotiIDropdownPuslapi()
                .PasirinktiElementaPagalText(savaitesDiena)
                .PatikrinkArAtsiradesTekstasTeisingas($"Day selected :- {savaitesDiena}");

        }
    }
}
