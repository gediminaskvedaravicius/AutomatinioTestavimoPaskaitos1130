using AutoPaskaitos.BaigiamasisProjektas.Puslapiai;
using NUnit.Framework;
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
        public void PasirinkPirma()
        {
            dropdownPuslapis.PasirinktiElementa();
            Thread.Sleep(3000);
        }
    }
}
