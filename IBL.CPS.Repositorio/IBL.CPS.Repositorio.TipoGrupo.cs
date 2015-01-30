using IBL.CPS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBL.CPS.Repositorio
{
    public partial class TIPOGRUPO
    {
        public static explicit operator TipoGrupoDTO(TIPOGRUPO f)
        {
            if (f == null) return null;
            return new TipoGrupoDTO()
            {
                ID = f.IDTIPOGRUPO,
                DESCRICAO = f.DESCRICAO
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
