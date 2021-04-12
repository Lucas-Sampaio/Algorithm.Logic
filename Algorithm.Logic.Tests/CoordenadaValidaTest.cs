using System;
using Algorithm.Logic.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Algorithm.Logic.Tests
{
    [TestClass]
    public class CoordenadaValidaTest
    {
        [TestMethod]
        public void CoordenadaIsValid()
        {
            var nx2 = new Coordenada("NX2");
            Assert.AreEqual(false, nx2.isValid());

            var coordenada2 = new Coordenada("NLSOXXN40L30S20O10");
            Assert.AreEqual(true, coordenada2.isValid());

            var testeNumeroInicio = new Coordenada("123N");
            Assert.AreEqual(false, testeNumeroInicio.isValid());

            var testeNulo = new Coordenada(null);
            Assert.AreEqual(false, testeNulo.isValid());
        }
    }
}
