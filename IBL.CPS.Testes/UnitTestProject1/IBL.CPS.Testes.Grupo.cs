using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using IBL.CPS.Controlador;

namespace IBL.CPS.Testes
{
    [TestClass]
    public class TestesGrupo
    {
        [TestMethod]
        public void TesteObterLista()
        {
            var l = ControladorGrupo.ObterLista();
            Assert.IsTrue(l.Count == 0);
        }
    }
}
