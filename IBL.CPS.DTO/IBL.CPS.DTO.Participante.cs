using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace IBL.CPS.DTO
{
    [DataContract]
    public class ParticipanteDTO
    {
        [DataMember]
        public int ID { get; set; }

        [DataMember]
        public int IDCASAL { get; set; }

        [DataMember]
        public int IDGRUPO { get; set; }

        [DataMember]
        public int FUNCAO_NA_EPOCA { get; set; }

    }

    public class ParticipanteFTR
    {
        public string descricao { get; set; }
    }
}
