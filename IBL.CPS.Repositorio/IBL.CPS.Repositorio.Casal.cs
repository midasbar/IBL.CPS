using IBL.CPS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBL.CPS.Repositorio
{
    public partial class CASAL
    {
        public static explicit operator CasalDTO(CASAL f)
        {
            if (f == null) return null;
            return new CasalDTO()
            {
                ID = f.IDCASAL,
                IDMARIDO = f.IDMARIDO,
                IDESPOSA = f.IDESPOSA,
                FUNCAO_ATUAL = f.FUNCAO_ATUAL,
                UF = f.UF,
                CIDADE = f.CIDADE,
                BAIRRO = f.BAIRRO,
                ENDERECO = f.ENDERECO,
                NUMERO = f.NUMERO,
                COMPLEMENTO = f.COMPLEMENTO,
                CEP = f.CEP
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
