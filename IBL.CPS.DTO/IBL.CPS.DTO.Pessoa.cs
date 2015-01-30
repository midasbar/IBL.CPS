using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace IBL.CPS.DTO
{
    [DataContract]
    public class PessoaDTO
    {
        [DataMember]
        public int ID { get; set; }

        [DataMember]
        public int NUMERO_DE_MEMBRO { get; set; }

        [DataMember]
        public string SEXO { get; set; }

        [DataMember]
        public string NOME { get; set; }

        [DataMember]
        public DateTime DATANASC { get; set; }

        [DataMember]
        public string RG { get; set; }

        [DataMember]
        public string CPF { get; set; }

        [DataMember]
        public string TELEFONE_FIXO { get; set; }

        [DataMember]
        public string CELULAR { get; set; }

        [DataMember]
        public string E_MAIL { get; set; }
    }
    public class PessoaFTR
    {
        public string descricao { get; set; }
    }

}
