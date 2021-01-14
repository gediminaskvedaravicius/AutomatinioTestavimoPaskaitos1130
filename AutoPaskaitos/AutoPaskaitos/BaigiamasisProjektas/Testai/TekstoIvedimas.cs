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
            PadarykScreenshotaJeiguTestasFailed();
            ivedimoLaukuPuslapis
                .paspauskAntSimpleFormDemoNavigacijos()
                .IrasytiTeksta("Tekstas")
                .PaspauskSpausdinimoMygtuka()
                .PatikrinkAtspausdintaTeksta("Tekstasx");
            Thread.Sleep(3000);
            
           
        }
    }
}
