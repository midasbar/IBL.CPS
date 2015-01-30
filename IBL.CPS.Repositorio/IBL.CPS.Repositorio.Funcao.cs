using IBL.CPS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBL.CPS.Repositorio
{
    public partial class FUNCAO
    {
        public static explicit operator FuncaoDTO(FUNCAO f)
        {
            if (f == null) return null;
            return new FuncaoDTO()
            {
                ID = f.IDFUNCAO,
                DESCRICAO = f.DESCRICAO, //Pode ou não ter esta virgula pois é uma lista de parametros 
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
