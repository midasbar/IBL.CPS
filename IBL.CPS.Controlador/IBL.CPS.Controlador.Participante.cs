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
    static public class ControladorParticipante
    {
        static public List<ParticipanteDTO>
        ObterLista()
        {
            IQueryable<PARTICIPANTE> e = null;
            List<ParticipanteDTO> r = null;
            using (var ct = new dbCPSEntities())
            {
                e = ct.PARTICIPANTE;

                r = e.ToList().ConvertAll(x => (ParticipanteDTO)x);
            }

            return r;

        }


        static public void Incluir(ParticipanteDTO dto)
        {
            String erros = null;
            if (!ValidarGravacao(dto, out erros))
                throw new ValidationException(erros);
            PARTICIPANTE func = new PARTICIPANTE();
            using (var ct = new dbCPSEntities())
            {
                AtualizarObjeto(ct, dto, ref func);
                //ct.PARTICIPANTE.AddObject(func);
                ((IObjectContextAdapter)ct).ObjectContext.AddObject("PARTICIPANTE", func);
                ct.SaveChanges();
            }
        }

        static public void Gravar(ParticipanteDTO dto)
        {
            if (dto.IDPARTICIPANTE == 0)
                throw new Exception("Objeto não possui Id. Inválido para gravação.");

            String erros = null;
            if (!ValidarGravacao(dto, out erros))
                throw new ValidationException(erros);

            using (var ct = new dbCPSEntities())
            {
                PARTICIPANTE func = ObterEntidade(ct, dto.IDPARTICIPANTE);

                if (func == null)
                    throw new Exception(String.Format("Id não encontrado {0}.", dto.IDPARTICIPANTE));

                AtualizarObjeto(ct, dto, ref func);
                ct.SaveChanges();
            }
        }

        static public void Excluir(Int32 Id)
        {
            using (var ct = new dbCPSEntities())
            {
                PARTICIPANTE func = ObterEntidade(ct, Id);

                if (func == null)
                    throw new Exception(String.Format("Id não encontrado {0}.", Id));


                String erros = null;
                if (!ValidarExclusao(func, out erros))
                    throw new ValidationException(erros);


                ((IObjectContextAdapter)ct).ObjectContext.DeleteObject(func);
                ct.SaveChanges();
            }
        }

        static public PARTICIPANTE ObterEntidade(dbCPSEntities ct, Int32 Id)
        {
            PARTICIPANTE obj = null;
            obj = (PARTICIPANTE)RepositorioUtils.ObterObjeto(ct, "PARTICIPANTE", "IDPARTICIPANTE", Id);

            return obj;
        }

        static public ParticipanteDTO Obter(Int32 Id)
        {
            ParticipanteDTO r = null;
            using (var ct = new dbCPSEntities())
            {
                r = (ParticipanteDTO)ObterEntidade(ct, Id);
            }
            return r;
        }

        static private Boolean ValidarGravacao(ParticipanteDTO dto, out String erros)
        {
            erros = String.Empty;
            StringBuilder listaErros = new StringBuilder();

            if (dto.IDCASAL == 0)
                listaErros.AppendLine("O casal deve ser informado.");

            if (dto.IDGRUPO == 0)
                listaErros.AppendLine("O grupo deve ser informado.");

            if (dto.FUNCAO_NA_EPOCA == 0)
                listaErros.AppendLine("A funcao na epoca deve ser informada.");

            Boolean valido = listaErros.Length == 0;

            if (!valido)
                erros = "Alguns erros impedem a gravação deste registro. Favor verificar: " + Environment.NewLine + listaErros.ToString();

            return valido;
        }


        static private Boolean ValidarExclusao(PARTICIPANTE obj, out String erros)
        {
            erros = String.Empty;
            StringBuilder listaErros = new StringBuilder();

          //Nenhum fk por enqunato....

            Boolean valido = listaErros.Length == 0;

            if (!valido)
                erros = "Alguns erros impedem a exclusão deste registro. Favor verificar: " + Environment.NewLine + listaErros.ToString();


            return valido;
        }


        static public void AtualizarObjeto(dbCPSEntities ct, ParticipanteDTO dto, ref PARTICIPANTE func)
        {
            func.IDCASAL = dto.IDCASAL;
            func.IDGRUPO = dto.IDGRUPO;
            func.FUNCAO_NA_EPOCA = dto.FUNCAO_NA_EPOCA;
        }
    }
}
