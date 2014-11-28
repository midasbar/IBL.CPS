using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using IBL.CPS.Controlador;
using IBL.CPS.DTO;

namespace IBL.CPS.Testes
{
    [TestClass]
    public class TestesTipoGrupo
    {
        [TestMethod]
        public void TesteObterLista()
        {
            var l = ControladorTipoGrupo.ObterLista(null);
            Assert.IsTrue(l.Count == 0);
        }

        [TestMethod]
        public void TesteIncluir()
        {
            var l = ControladorTipoGrupo.ObterLista(null);

            var qi = l.Count;

            for (int i = 0; i < 10; i++)
            {
                var d = new TipoGrupoDTO();
                d.DESCRICAO = "aaaa";
                ControladorTipoGrupo.Incluir(d);
            }

            l = ControladorTipoGrupo.ObterLista(null);

            Assert.AreEqual(qi + 10, l.Count);
        }

        [TestMethod]
        public void TesteExcluir()
        {
            var l = ControladorTipoGrupo.ObterLista(null);

            var qi = l.Count;

            foreach (TipoGrupoDTO d in l)
            {
                try
                {
                    ControladorTipoGrupo.Excluir(d.IDTIPOGRUPO);
                    qi--;
                }
                catch (Exception ex) { Console.WriteLine(ex.Message); }
            }

            l = ControladorTipoGrupo.ObterLista(null);
            Assert.AreEqual(qi, l.Count);
        }

    }
}
