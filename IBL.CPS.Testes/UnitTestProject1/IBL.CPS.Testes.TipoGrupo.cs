using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using IBL.CPS.Controlador;

namespace IBL.CPS.Testes
{
    [TestClass]
    public class TestesTipoGrupo
    {
        [TestMethod]
        public void TesteObterLista()
        {
            var l = ControladorTipoGrupo.ObterLista();
            Assert.IsTrue(l.Count == 0);
        }
    }
}
