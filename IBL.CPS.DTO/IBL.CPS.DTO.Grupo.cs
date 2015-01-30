using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace IBL.CPS.DTO
{
    [DataContract]
    public class GrupoDTO
    {
        [DataMember]
        public int ID { get; set; }

        [DataMember]
        public int LIDER { get; set; }

        [DataMember]
        public Nullable<int> LIDER_EM_TREINAMENTO { get; set; }

        [DataMember]
        public string UF { get; set; }

        [DataMember]
        public string CIDADE { get; set; }

        [DataMember]
        public string BAIRRO { get; set; }

        [DataMember]
        public string ENDERECO { get; set; }

        [DataMember]
        public string NUMERO { get; set; }

        [DataMember]
        public string COMPLEMENTO { get; set; }

        [DataMember]
        public string CEP { get; set; }

        [DataMember]
        public int SEMESTRE { get; set; }

        [DataMember]
        public int ANO { get; set; }

        [DataMember]
        public int TIPOGRUPO { get; set; }

    }

    public class GrupoFTR
    {
        public string descricao { get; set; }
    }
}
