using IBL.CPS.DTO;
using IBL.CPS.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.Infrastructure;

namespace IBL.CPS.Controlador
{
    static public class ControladorFuncao
    {
        static public List<FuncaoDTO> ObterLista(FuncaoFTR Filtro)
        {
            IQueryable<FUNCAO> e = null;
            List<FuncaoDTO> r = null;
            using (var ct = new dbCPSEntities())
            {
                e = ct.FUNCAO;
                if (!String.IsNullOrEmpty(Filtro.descricao))
                {
                    e = e.Where(x => x.DESCRICAO.ToUpper().Contains(Filtro.descricao.ToUpper()));
                }
                r = e.ToList().ConvertAll(x => (FuncaoDTO)x);
            }

            return r;
        }

        static public void Incluir(FuncaoDTO dto)
        {
            String erros = null;
            if (!ValidarGravacao(dto, out erros))
                throw new ValidationException(erros);
            FUNCAO func = new FUNCAO();
            using (var ct = new dbCPSEntities())
            {
                AtualizarObjeto(ct, dto, ref func);
                ((IObjectContextAdapter)ct).ObjectContext.AddObject("FUNCAO", func);
                ct.SaveChanges();
            }
        }

        static public void Gravar(FuncaoDTO dto)
        {
            if (dto.ID == 0)
                throw new Exception("Objeto não possui Id. Inválido para gravação.");

            String erros = null;
            if (!ValidarGravacao(dto, out erros))
                throw new ValidationException(erros);

            using (var ct = new dbCPSEntities())
            {
                FUNCAO func = ObterEntidade(ct, dto.ID);

                if (func == null)
                    throw new Exception(String.Format("Id não encontrado {0}.", dto.ID));

                AtualizarObjeto(ct, dto, ref func);
                ct.SaveChanges();
            }
        }

        static public void Excluir(Int32 Id)
        {
            using (var ct = new dbCPSEntities())
            {
                FUNCAO func = ObterEntidade(ct,Id);

                if (func == null)
                    throw new Exception(String.Format("Id não encontrado {0}.", Id));


                String erros = null;
                if (!ValidarExclusao(func, out erros))
                    throw new ValidationException(erros);


                ((IObjectContextAdapter)ct).ObjectContext.DeleteObject(func);
                ct.SaveChanges();
            }
        }

        static public FUNCAO ObterEntidade(dbCPSEntities ct, Int32 Id)
        {
            FUNCAO obj = null;
            obj = (FUNCAO)RepositorioUtils.ObterObjeto(ct, "FUNCAO", "IDFUNCAO" , Id);

            return obj;
        }

        static public FuncaoDTO Obter(Int32 Id)
        {
            FuncaoDTO r = null;
            using (var ct = new dbCPSEntities())
            {
                r = (FuncaoDTO)ObterEntidade(ct, Id);
            }
            return r;
        }

        static private Boolean ValidarGravacao(FuncaoDTO dto, out String erros)
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


        static private Boolean ValidarExclusao(FUNCAO obj, out String erros)
        {
            erros = String.Empty;
            StringBuilder listaErros = new StringBuilder();

            if (obj.CASAL.Count > 0)
                listaErros.AppendLine("Alguns casais estão associados a esta Função.");

            if (obj.PARTICIPANTE.Count > 0)
                listaErros.AppendLine("Alguns participantes estão associados a esta Função.");

            Boolean valido = listaErros.Length == 0;

            if (!valido)
                erros = "Alguns erros impedem a exclusão deste registro. Favor verificar: " + Environment.NewLine + listaErros.ToString();


            return valido;
        }


        static public void AtualizarObjeto(dbCPSEntities ct, FuncaoDTO dto, ref FUNCAO func)
        {
            func.DESCRICAO = dto.DESCRICAO;
        }

    }
}
