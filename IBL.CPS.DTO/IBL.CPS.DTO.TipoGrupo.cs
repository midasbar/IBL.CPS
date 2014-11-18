using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace IBL.CPS.DTO
{
    [DataContract]
    public class TipoGrupoDTO
    {
        [DataMember]
        public int IDTIPOGRUPO { get; set; }

        [DataMember]
        public string DESCRICAO { get; set; }
    }
}
