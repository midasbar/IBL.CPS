using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using IBL.CPS.Controlador;

namespace IBL.CPS.Testes
{
    [TestClass]
    public class TestesPessoa
    {
        [TestMethod]
        public void TesteObterLista()
        {
            var l = ControladorPessoa.ObterLista();
            Assert.IsTrue(l.Count == 0);
        }
    }
}
