using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace IBL.CPS.DTO
{
    [DataContract]
    public class CasalDTO
    {
        [DataMember]
        public int ID { get; set; }

        [DataMember]
        public int IDMARIDO { get; set; }

        [DataMember]
        public int IDESPOSA { get; set; }

        [DataMember]
        public int FUNCAO_ATUAL { get; set; }

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
        public string NOMEMARIDO { get; set; }
        
        [DataMember]
        public string NOMEESPOSA { get; set; }
    }
    
    public class CasalFTR
    {
        public string descricao { get; set; }
    }
    
}
