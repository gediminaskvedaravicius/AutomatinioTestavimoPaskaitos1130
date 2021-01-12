using AutoPaskaitos.BaigiamasisProjektas.Puslapiai;
using NUnit.Framework;


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
                .IrasytiTeksta(irasomasTekstas)
                .PaspauskSpausdinimoMygtuka()
                .PatikrinkAtspausdintaTeksta(irasomasTekstas);
        }
    }
}
