using AutoPaskaitos.BaigiamasisProjektas.Puslapiai;
using NUnit.Framework;
using System.Threading;

namespace AutoPaskaitos.BaigiamasisProjektas.Testai
{
    class TekstoIvedimas : Bazine
    {
        private IvedimoLaukuPuslapis ivedimoLaukuPuslapis;

        [SetUp]
        public void PriesKiekvienaTesta()
        {
            ivedimoLaukuPuslapis = new IvedimoLaukuPuslapis(driver);
        }
        [Test]
        public void RodykZinute()
        {
            string irasomasTekstas = "Tekstas";

            ivedimoLaukuPuslapis
                .paspauskAntSimpleFormDemoNavigacijos()
                .IrasytiTeksta(irasomasTekstas)
                .PaspauskSpausdinimoMygtuka()
                .PatikrinkAtspausdintaTeksta(irasomasTekstas);
            Thread.Sleep(3000);
        }
    }
}
