using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using IBL.CPS.Controlador;
using IBL.CPS.DTO;

namespace IBL.CPS.Testes
{
    [TestClass]
    public class TestesParticipante
    {
        [TestMethod]
        public void TesteObterLista()
        {
            var l = ControladorParticipante.ObterLista();
            Assert.IsTrue(l.Count == 0);
        }


        [TestMethod]
        public void TesteIncluir()
        {
            var l = ControladorParticipante.ObterLista();

            var qi = l.Count;

            for (int i = 0; i < 10; i++)
            {
                var d = new ParticipanteDTO();
                d.IDCASAL = 1;
                d.IDGRUPO = 1;
                d.FUNCAO_NA_EPOCA = 1;
                ControladorParticipante.Incluir(d);
            }

            l = ControladorParticipante.ObterLista();

            Assert.AreEqual(qi + 10, l.Count);
        }

        [TestMethod]
        public void TesteExcluir()
        {
            var l = ControladorParticipante.ObterLista();

            var qi = l.Count;

            foreach (ParticipanteDTO d in l)
            {
                try
                {
                    ControladorParticipante.Excluir(d.IDPARTICIPANTE);
                    qi--;
                }
                catch (Exception ex) { Console.WriteLine(ex.Message); }
            }

            l = ControladorParticipante.ObterLista();
            Assert.AreEqual(qi, l.Count);
        }

    }
}
