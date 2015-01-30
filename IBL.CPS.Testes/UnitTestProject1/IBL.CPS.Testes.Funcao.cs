using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using IBL.CPS.Controlador;
using IBL.CPS.DTO;

namespace IBL.CPS.Testes
{
    [TestClass]
    public class TestesFuncao
    {
        [TestMethod]
        public void TesteObterListaFiltrada()
        {
            var filtro = new FuncaoFTR(){descricao = "lider"};
            var l = ControladorFuncao.ObterLista(filtro);
            Assert.IsTrue(l.Count == 3);
        }
        
        public void TesteObterLista(null)
        {
            var l = ControladorFuncao.ObterLista(null);
            Assert.IsTrue(l.Count == 7);
        }

        [TestMethod]
        public void TesteIncluir()
        {
            var l = ControladorFuncao.ObterLista(null);

            var qi = l.Count;

            for (int i = 0; i < 10; i++)
            {
                var d = new FuncaoDTO();

                d.DESCRICAO = "bla";
                ControladorFuncao.Incluir(d);
            }

            l = ControladorFuncao.ObterLista(null);
            
            Assert.AreEqual(qi +10 , l.Count);
        }

        [TestMethod]
        public void TesteExcluir()
        {
            var l = ControladorFuncao.ObterLista(null);
            l = l.Where(f => f.ID > 7).ToList();
            
            var qi = l.Count;

            foreach (FuncaoDTO d in l)
            {
                try
                {
                    ControladorFuncao.Excluir(d.ID);
                    qi--;
                }
                catch (Exception ex) { Console.WriteLine(ex.Message); }
            }

            l = ControladorFuncao.ObterLista(null);
            l = l.Where(f => f.ID > 7).ToList();
            Assert.AreEqual(qi, l.Count);
        }  
    }
}
