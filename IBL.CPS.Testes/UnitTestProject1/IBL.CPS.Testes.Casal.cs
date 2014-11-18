using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using IBL.CPS.Controlador;
using IBL.CPS.DTO;

namespace IBL.CPS.Testes
{
    [TestClass]
    public class TestesCasal
    {
        [TestMethod]
        public void TesteObterLista()
        {
            var l = ControladorCasal.ObterLista();
            Assert.IsTrue(l.Count == 0);
        }

        [TestMethod]
        public void TesteIncluir()
        {
            var l = ControladorCasal.ObterLista();

            var qi = l.Count;

            for (int i = 0; i < 10; i++)
            {
                var d = new CasalDTO();
                d.IDMARIDO = 1;
                d.IDESPOSA = 2;
                d.FUNCAO_ATUAL = 1;
                d.UF = "Teste";
                d.CIDADE = "Teste";
                d.BAIRRO = "Teste";
                d.ENDERECO = "Teste";
                d.NUMERO = "Teste";
                d.COMPLEMENTO = "Teste";
                d.CEP = "Teste";
                ControladorCasal.Incluir(d);
            }

            l = ControladorCasal.ObterLista();

            Assert.AreEqual(qi + 10, l.Count);
        }

        [TestMethod]
        public void TesteExcluir()
        {
            var l = ControladorCasal.ObterLista();

            var qi = l.Count;

            foreach (CasalDTO d in l)
            {
                try
                {
                    ControladorCasal.Excluir(d.IDCASAL);
                    qi--;
                }
                catch (Exception ex) { Console.WriteLine(ex.Message); }
            }

            l = ControladorCasal.ObterLista();
            Assert.AreEqual(qi, l.Count);
        }

    }
}
