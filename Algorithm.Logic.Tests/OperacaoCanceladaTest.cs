using System;
using Algorithm.Logic.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Algorithm.Logic.Tests
{
    [TestClass]
    public class OperacaoCanceladaTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            var cood1 = new Coordenada("N123XL123NL");
            Assert.AreEqual("L123NL",cood1.CancelarOperacoes());
            var cood2 = new Coordenada("N123XL123NLLLXXOSNX");
            Assert.AreEqual("L123NLOS", cood2.CancelarOperacoes());
        }
    }
}
