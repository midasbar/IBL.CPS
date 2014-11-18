using IBL.CPS.DTO;
using IBL.CPS.Repositorio;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBL.CPS.Controlador
{
    static public class ControladorTipoGrupo
    {
        static public List<TipoGrupoDTO>
        ObterLista()
        {
            IQueryable<TIPOGRUPO> e = null;
            List<TipoGrupoDTO> r = null;
            using (var ct = new dbCPSEntities())
            {
                e = ct.TIPOGRUPO;

                r = e.ToList().ConvertAll(x => (TipoGrupoDTO)x);
            }

            return r;

        }


        static public void Incluir(TipoGrupoDTO dto)
        {
            String erros = null;
            if (!ValidarGravacao(dto, out erros))
                throw new ValidationException(erros);
            TIPOGRUPO func = new TIPOGRUPO();
            using (var ct = new dbCPSEntities())
            {
                AtualizarObjeto(ct, dto, ref func);
                //ct.TIPOGRUPO.AddObject(func);
                ((IObjectContextAdapter)ct).ObjectContext.AddObject("TIPOGRUPO", func);
                ct.SaveChanges();
            }
        }

        static public void Gravar(TipoGrupoDTO dto)
        {
            if (dto.IDTIPOGRUPO == 0)
                throw new Exception("Objeto não possui Id. Inválido para gravação.");

            String erros = null;
            if (!ValidarGravacao(dto, out erros))
                throw new ValidationException(erros);

            using (var ct = new dbCPSEntities())
            {
                TIPOGRUPO func = ObterEntidade(ct, dto.IDTIPOGRUPO);

                if (func == null)
                    throw new Exception(String.Format("Id não encontrado {0}.", dto.IDTIPOGRUPO));

                AtualizarObjeto(ct, dto, ref func);
                ct.SaveChanges();
            }
        }

        static public void Excluir(Int32 Id)
        {
            using (var ct = new dbCPSEntities())
            {
                TIPOGRUPO func = ObterEntidade(ct, Id);

                if (func == null)
                    throw new Exception(String.Format("Id não encontrado {0}.", Id));


                String erros = null;
                if (!ValidarExclusao(func, out erros))
                    throw new ValidationException(erros);


                ((IObjectContextAdapter)ct).ObjectContext.DeleteObject(func);
                ct.SaveChanges();
            }
        }

        static public TIPOGRUPO ObterEntidade(dbCPSEntities ct, Int32 Id)
        {
            TIPOGRUPO obj = null;
            obj = (TIPOGRUPO)RepositorioUtils.ObterObjeto(ct, "TIPOGRUPO","IDTIPOGRUPO", Id);

            return obj;
        }

        static public TipoGrupoDTO Obter(Int32 Id)
        {
            TipoGrupoDTO r = null;
            using (var ct = new dbCPSEntities())
            {
                r = (TipoGrupoDTO)ObterEntidade(ct, Id);
            }
            return r;
        }

        static private Boolean ValidarGravacao(TipoGrupoDTO dto, out String erros)
        {
            erros = String.Empty;
            StringBuilder listaErros = new StringBuilder();

            if (String.IsNullOrEmpty(dto.DESCRICAO) || String.IsNullOrWhiteSpace(dto.DESCRICAO))
                listaErros.AppendLine("Descrição deve ser informada.");

            Boolean valido = listaErros.Length == 0;

            if (!valido)
                erros = "Alguns erros impedem a gravação deste registro. Favor verificar: " + Environment.NewLine + listaErros.ToString();


            return valido;
        }


        static private Boolean ValidarExclusao(TIPOGRUPO obj, out String erros)
        {
            erros = String.Empty;
            StringBuilder listaErros = new StringBuilder();

            if (obj.GRUPO.Count > 0)
                listaErros.AppendLine("Alguns Grupos estão associados a este Tipo de Grupo.");

            Boolean valido = listaErros.Length == 0;

            if (!valido)
                erros = "Alguns erros impedem a exclusão deste registro. Favor verificar: " + Environment.NewLine + listaErros.ToString();


            return valido;
        }


        static public void AtualizarObjeto(dbCPSEntities ct, TipoGrupoDTO dto, ref TIPOGRUPO func)
        {
            func.DESCRICAO = dto.DESCRICAO;
        }
    }
}
