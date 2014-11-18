using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using IBL.CPS.Controlador;

namespace IBL.CPS.Testes
{
    [TestClass]
    public class TestesParticipante
    {
        [TestMethod]
        public void TesteObterLista()
        {
            var l = ControladorParticipante.ObterLista();
            Assert.IsTrue(l.Count == 0);
        }
    }
}
