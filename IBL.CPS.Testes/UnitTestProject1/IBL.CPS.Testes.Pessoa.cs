using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using IBL.CPS.Controlador;
using IBL.CPS.DTO;

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

        [TestMethod]
        public void TesteIncluir()
        {
            var l = ControladorPessoa.ObterLista();

            var qi = l.Count;

            for (int i = 0; i < 10; i++)
            {
                var d = new PessoaDTO();
                d.NUMERO_DE_MEMBRO = 1;
                d.SEXO = "M";
                d.NOME = "TESTE";
                d.DATANASC = DateTime.Today;
                d.RG = "01234567890";
                d.CPF = "MG-12345678";
                d.TELEFONE_FIXO = "3132224888";
                d.CELULAR = "3199998888";
                d.E_MAIL = "teste@ibp.com";
                ControladorPessoa.Incluir(d);
            }

            l = ControladorPessoa.ObterLista();

            Assert.AreEqual(qi + 10, l.Count);
        }

        [TestMethod]
        public void TesteExcluir()
        {
            var l = ControladorPessoa.ObterLista();

            var qi = l.Count;

            foreach (PessoaDTO d in l)
            {
                try
                {
                    ControladorPessoa.Excluir(d.IDPESSOA);
                    qi--;
                }
                catch (Exception ex) { Console.WriteLine(ex.Message); }
            }

            l = ControladorPessoa.ObterLista();
            Assert.AreEqual(qi, l.Count);
        }


    }
}
