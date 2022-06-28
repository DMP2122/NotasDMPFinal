using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using NotasFinalNS;

namespace NotasDMPTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void PruebaNotasCorrectas()
        {
            EstadisticasNotas notas = new EstadisticasNotas();
            List<int> ListaNotas = new List<int>();
            ListaNotas.Add(5);
            ListaNotas.Add(3);
            ListaNotas.Add(6);
            ListaNotas.Add(2);
            ListaNotas.Add(8);
            ListaNotas.Add(9);
            ListaNotas.Add(7);

            int suspensosEsperados = 2;
            int aprobadosEsperados = 2;
            int notablesEsperados = 2;
            int sobresalientesEsperados = 1;
            double mediaEsperada = 5.71;

            notas.CalcularResultados(ListaNotas);

            Assert.AreEqual(suspensosEsperados, notas.Suspensos, "Suspensos Error");
            Assert.AreEqual(aprobadosEsperados, notas.Aprobados, "Aprobados Error");
            Assert.AreEqual(notablesEsperados, notas.Notables, "Notables Error");
            Assert.AreEqual(sobresalientesEsperados, notas.Sobresalientes, "Sobresalientes Error");
            Assert.AreEqual(mediaEsperada, notas.Media, 0.01, "Media Error");
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), EstadisticasNotas.ListaVacia)]
        public void PruebaExcepcionVacia()
        {
            EstadisticasNotas notas = new EstadisticasNotas();
            List<int> ListaNotas = new List<int>();
            notas.CalcularResultados(ListaNotas);
        }

        [TestMethod]
        public void PruebaNotasIncorrectas()
        {
            EstadisticasNotas notas = new EstadisticasNotas();
            List<int> ListaNotas = new List<int>();
            ListaNotas.Add(-5);
            ListaNotas.Add(3);
            ListaNotas.Add(16);
            ListaNotas.Add(2);
            ListaNotas.Add(8);
            ListaNotas.Add(9);
            ListaNotas.Add(7);

            try
            {
                notas.CalcularResultados(ListaNotas);
            }
            catch(ArgumentOutOfRangeException e)
            {
                StringAssert.Contains(e.Message, EstadisticasNotas.NotasIncorrectas);
                return;
            }
            Assert.Fail("Error");
        }
           
    }
    
}
