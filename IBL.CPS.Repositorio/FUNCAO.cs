//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace IBL.CPS.Repositorio
{
    using System;
    using System.Collections.Generic;
    
    public partial class FUNCAO
    {
        public FUNCAO()
        {
            this.CASAL = new HashSet<CASAL>();
            this.PARTICIPANTE = new HashSet<PARTICIPANTE>();
        }
    
        public int IDFUNCAO { get; set; }
        public string DESCRICAO { get; set; }
    
        public virtual ICollection<CASAL> CASAL { get; set; }
        public virtual ICollection<PARTICIPANTE> PARTICIPANTE { get; set; }
    }
}