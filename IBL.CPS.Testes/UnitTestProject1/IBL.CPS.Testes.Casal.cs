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
        public void TesteObterLista(null)
        {
            var l = ControladorCasal.ObterLista(null);
            Assert.IsTrue(l.Count == 0);
        }

        [TestMethod]
        public void TesteIncluir()
        {
            var l = ControladorCasal.ObterLista(null);

            var qi = l.Count;
            
            //Inclui pessoas usadas no teste...
            var p = ControladorPessoa.ObterLista(null);
            if (p.Count == 0)
            {
                var dp = new PessoaDTO();
                dp.NUMERO_DE_MEMBRO = 1;
                dp.SEXO = "M";
                dp.NOME = "TESTE MARIDO";
                dp.DATANASC = DateTime.Today;
                dp.RG = "01234567890";
                dp.CPF = "MG-12345678";
                dp.TELEFONE_FIXO = "3132224888";
                dp.CELULAR = "3199998888";
                dp.E_MAIL = "teste@ibp.com";
                ControladorPessoa.Incluir(dp);
                
                dp.NUMERO_DE_MEMBRO = 2;
                dp.SEXO = "F";
                dp.NOME = "TESTE ESPOSA";
                ControladorPessoa.Incluir(dp);
            }
            // Inclui Funcao usada no teste...
            var f = ControladorFuncao.ObterLista(null);
            if (f.Count == 0)
            {
                var df = new FuncaoDTO();
                df.DESCRICAO = "bla";
                ControladorFuncao.Incluir(df);  
            }

            for (int i = 0; i < 10; i++)
            {
                var d = new CasalDTO();
                d.IDMARIDO = 1;
                d.IDESPOSA = 2;
                d.FUNCAO_ATUAL = 1;
                d.UF = "MG";
                d.CIDADE = "Teste";
                d.BAIRRO = "Teste";
                d.ENDERECO = "Teste";
                d.NUMERO = "125";
                d.COMPLEMENTO = "Teste";
                d.CEP = "Teste";
                ControladorCasal.Incluir(d);
            }

            l = ControladorCasal.ObterLista(null);

            Assert.AreEqual(qi + 10, l.Count);
        }

        [TestMethod]
        public void TesteExcluir()
        {
            var l = ControladorCasal.ObterLista(null);

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

            l = ControladorCasal.ObterLista(null);
            Assert.AreEqual(qi, l.Count);
        }

    }
}
