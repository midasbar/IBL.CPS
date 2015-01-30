using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace IBL.CPS.DTO
{
    [DataContract]
    public class TipoGrupoDTO : IDTO
    {
        [DataMember]
        public int ID { get; set; }

        [DataMember]
        public string DESCRICAO { get; set; }
    }

    public class TipoGrupoFTR
    {
        public string descricao { get; set; }
    }

}
