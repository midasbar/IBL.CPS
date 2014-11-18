using IBL.CPS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBL.CPS.Repositorio
{
    public partial class PARTICIPANTE
    {
        public static explicit operator ParticipanteDTO(PARTICIPANTE f)
        {
            if (f == null) return null;
            return new ParticipanteDTO()
            {
                IDPARTICIPANTE = f.IDPARTICIPANTE,
                IDCASAL = f.IDCASAL,
                IDGRUPO = f.IDGRUPO,
                FUNCAO_NA_EPOCA = f.FUNCAO_NA_EPOCA
            };

            /* Pode ser escrito tambem desta forma:
            var x = new FuncaoDTO();
            x.IDFUNCAO = f.IDFUNCAO;
            x.DESCRICAO = f.DESCRICAO;
            return x;
            */
        }
    }
}
