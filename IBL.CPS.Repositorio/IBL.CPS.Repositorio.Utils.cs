using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBL.CPS.Repositorio
{
    static public class RepositorioUtils
    {
        //Na versão Anterior é assim:
        static public object ObterObjeto(dbCPSEntities ct, String entitySetName,String NomeColunaChave, Int32 Id)
        //static public object ObterObjeto(dbCPSEntities ct, String entitySetName, Int32 Id)
        {
            try
            {
                var prodKey = new EntityKey("dbCPSEntities." + entitySetName, "IDFUNCAO", Id);
                return ((IObjectContextAdapter)ct).ObjectContext.GetObjectByKey(prodKey);
            }
            catch (ObjectNotFoundException exObjNotFound)
            {
                throw new Exception("O registro com o código " + Id + " do objeto " + entitySetName + " não foi localizado.", exObjNotFound);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        static public String ObterNomeMes(Int32 mes)
        {
            switch (mes)
            {
                case 1: return "Janeiro";
                case 2: return "Fevereiro";
                case 3: return "Março";
                case 4: return "Abril";
                case 5: return "Maio";
                case 6: return "Junho";
                case 7: return "Julho";
                case 8: return "Agosto";
                case 9: return "Setembro";
                case 10: return "Outubro";
                case 11: return "Novembro";
                case 12: return "Dezembro";
            }

            return String.Empty;
        }


    }
}
