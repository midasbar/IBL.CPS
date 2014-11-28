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


            //Inclui pessoas usadas no teste...
            var p = ControladorPessoa.ObterLista();
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

            // inclui casal usado no teste
            var c = ControladorCasal.ObterLista();
            if (c.Count == 0)
            {
                for (int i = 0; i < 2; i++)
                {
                    var dc = new CasalDTO();
                    dc.IDMARIDO = 1;
                    dc.IDESPOSA = 2;
                    dc.FUNCAO_ATUAL = 1;
                    dc.UF = "MG";
                    dc.CIDADE = "Teste";
                    dc.BAIRRO = "Teste";
                    dc.ENDERECO = "Teste";
                    dc.NUMERO = "125";
                    dc.COMPLEMENTO = "Teste";
                    dc.CEP = "Teste";
                    ControladorCasal.Incluir(dc);
                }
            }
            
            // Inclui o tipo do grupo usado no teste
            var tg = ControladorTipoGrupo.ObterLista(null);
            if (tg.Count == 0)
            {
                var dtg = new TipoGrupoDTO();
                dtg.DESCRICAO = "aaaa";
                ControladorTipoGrupo.Incluir(dtg);
            }


            for (int i = 0; i < 10; i++)
            {
                var d = new GrupoDTO();
                d.LIDER = 1;
                d.LIDER_EM_TREINAMENTO = 1;
                d.UF = "MG";
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
