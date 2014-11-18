using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using IBL.CPS.Controlador;

namespace IBL.CPS.Testes
{
    [TestClass]
    public class TestesFuncao
    {
        [TestMethod]
        public void TesteObterLista()
        {
            var l = ControladorCasal.ObterLista();
            Assert.IsTrue(l.Count == 0);
        }
    }
}
