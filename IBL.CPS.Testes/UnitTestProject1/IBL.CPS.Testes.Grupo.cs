using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using IBL.CPS.Controlador;
using IBL.CPS.DTO;

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

        [TestMethod]
        public void TesteIncluir()
        {
            var l = ControladorGrupo.ObterLista();

            var qi = l.Count;

            for (int i = 0; i < 10; i++)
            {
                var d = new GrupoDTO();
                d.LIDER = 1;
                d.LIDER_EM_TREINAMENTO = 1;
                d.UF = "Teste";
                d.CIDADE = "Teste";
                d.BAIRRO = "Teste";
                d.ENDERECO = "Teste";
                d.NUMERO = "Teste";
                d.COMPLEMENTO = "Teste";
                d.CEP = "Teste";
                d.SEMESTRE = 1;
                d.ANO = 2014;
                d.TIPOGRUPO = 1;
                ControladorGrupo.Incluir(d);
            }

            l = ControladorGrupo.ObterLista();

            Assert.AreEqual(qi + 10, l.Count);
        }

        [TestMethod]
        public void TesteExcluir()
        {
            var l = ControladorGrupo.ObterLista();

            var qi = l.Count;

            foreach (GrupoDTO d in l)
            {
                try
                {
                    ControladorGrupo.Excluir(d.IDGRUPO);
                    qi--;
                }
                catch (Exception ex) { Console.WriteLine(ex.Message); }
            }

            l = ControladorGrupo.ObterLista();
            Assert.AreEqual(qi, l.Count);
        }
    }
}
