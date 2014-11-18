using IBL.CPS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBL.CPS.Repositorio
{
    public partial class PESSOA
    {
        public static explicit operator PessoaDTO(PESSOA f)
        {
            if (f == null) return null;
            return new PessoaDTO()
            {
                IDPESSOA = f.IDPESSOA,
                NUMERO_DE_MEMBRO = f.NUMERO_DE_MEMBRO,
                SEXO = f.SEXO,
                NOME = f.NOME,
                DATANASC = f.DATANASC,
                RG = f.RG,
                CPF = f.CPF,
                TELEFONE_FIXO = f.TELEFONE_FIXO,
                CELULAR = f.CELULAR,
                E_MAIL = f.E_MAIL
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
