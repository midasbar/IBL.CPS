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
    static public class ControladorCasal
    {
        static public List<CasalDTO>
        ObterLista()
        {
            IQueryable<CASAL> e = null;
            List<CasalDTO> r = null;
            using (var ct = new dbCPSEntities())
            {
                e = ct.CASAL;

                r = e.ToList().ConvertAll(x => (CasalDTO)x);
            }

            return r;

        }

        static public void Incluir(CasalDTO dto)
        {
            String erros = null;
            if (!ValidarGravacao(dto, out erros))
                throw new ValidationException(erros);
            CASAL func = new CASAL();
            using (var ct = new dbCPSEntities())
            {

                AtualizarObjeto(ct, dto, ref func);
                //((IObjectContextAdapter)ct.CASAL).ObjectContext.AddObject("CASAL",func);
                ((IObjectContextAdapter)ct).ObjectContext.AddObject("CASAL", func);
                //ct.CASAL.AddObject(func);
                ct.SaveChanges();
            }
        }

        static public void Gravar(CasalDTO dto)
        {
            if (dto.IDCASAL == 0)
                throw new Exception("Objeto não possui Id. Inválido para gravação.");

            String erros = null;
            if (!ValidarGravacao(dto, out erros))
                throw new ValidationException(erros);

            using (var ct = new dbCPSEntities())
            {
                CASAL func = ObterEntidade(ct, dto.IDCASAL);

                if (func == null)
                    throw new Exception(String.Format("Id não encontrado {0}.", dto.IDCASAL));

                AtualizarObjeto(ct, dto, ref func);
                ct.SaveChanges();
            }
        }

        static public void Excluir(Int32 Id)
        {
            using (var ct = new dbCPSEntities())
            {

                //
                //
                //
                //
                //
                //Refatorar em todos
                //
                //
                //
                //
                // CASAL func = ObterEntidade(ct, Id);

                CASAL func = ObterEntidade(ct, Id);

                if (func == null)
                    throw new Exception(String.Format("Id não encontrado {0}.", Id));


                String erros = null;
                if (!ValidarExclusao(func, out erros))
                    throw new ValidationException(erros);

                ((IObjectContextAdapter)ct).ObjectContext.DeleteObject(func);
                ct.SaveChanges();
            }
        }

        static public CASAL ObterEntidade(dbCPSEntities ct, Int32 Id)
        {
            CASAL obj = null;
            obj = (CASAL)RepositorioUtils.ObterObjeto(ct, "CASAL", "IDCASAL" , Id);

            return obj;
        }

        static public CasalDTO Obter(Int32 Id)
        {
            CasalDTO r = null;
            using (var ct = new dbCPSEntities())
            {
                r = (CasalDTO)ObterEntidade(ct, Id);
            }
            return r;
        }

        static private Boolean ValidarGravacao(CasalDTO dto, out String erros)
        {
            erros = String.Empty;
            StringBuilder listaErros = new StringBuilder();

            if (dto.IDMARIDO == 0)
                listaErros.AppendLine("O marido deve ser informado.");

            if (dto.IDESPOSA == 0)
                listaErros.AppendLine("A esposa deve ser informada.");

            if (dto.FUNCAO_ATUAL == 0)
                listaErros.AppendLine("A função atual deve ser informada.");

            if (String.IsNullOrEmpty(dto.UF) || String.IsNullOrWhiteSpace(dto.UF))
                listaErros.AppendLine("A UF deve ser informada.");

            if (String.IsNullOrEmpty(dto.CIDADE) || String.IsNullOrWhiteSpace(dto.CIDADE))
                listaErros.AppendLine("A cidade deve ser informada.");

            if (String.IsNullOrEmpty(dto.BAIRRO) || String.IsNullOrWhiteSpace(dto.BAIRRO))
                listaErros.AppendLine("O bairro deve ser informado.");

            if (String.IsNullOrEmpty(dto.ENDERECO) || String.IsNullOrWhiteSpace(dto.ENDERECO))
                listaErros.AppendLine("O endereco deve ser informado.");

            if (String.IsNullOrEmpty(dto.NUMERO) || String.IsNullOrWhiteSpace(dto.NUMERO))
                listaErros.AppendLine("O número deve ser informado.");

            if (String.IsNullOrEmpty(dto.COMPLEMENTO) || String.IsNullOrWhiteSpace(dto.COMPLEMENTO))
                listaErros.AppendLine("O complemento deve ser informado.");

            if (String.IsNullOrEmpty(dto.CEP) || String.IsNullOrWhiteSpace(dto.CEP))
                listaErros.AppendLine("O CEP deve ser informado.");

            Boolean valido = listaErros.Length == 0;

            if (!valido)
                erros = "Alguns erros impedem a gravação deste registro. Favor verificar: " + Environment.NewLine + listaErros.ToString();


            return valido;
        }


        static private Boolean ValidarExclusao(CASAL obj, out String erros)
        {
            erros = String.Empty;
            StringBuilder listaErros = new StringBuilder();

            if (obj.PARTICIPANTE.Count > 0)
                listaErros.AppendLine("Alguns Participantes estão associados a esta Função.");

            if (obj.GRUPO.Count > 0)
                listaErros.AppendLine("Alguns Grupos estão associados a esta Função.");

            Boolean valido = listaErros.Length == 0;

            if (!valido)
                erros = "Alguns erros impedem a exclusão deste registro. Favor verificar: " + Environment.NewLine + listaErros.ToString();


            return valido;
        }


        static public void AtualizarObjeto(dbCPSEntities ct, CasalDTO dto, ref CASAL func)
        {
            func.IDMARIDO = dto.IDMARIDO;
            func.IDESPOSA = dto.IDESPOSA;
            func.FUNCAO_ATUAL = dto.FUNCAO_ATUAL;
            func.UF = dto.UF;
            func.CIDADE = dto.CIDADE;
            func.BAIRRO = dto.BAIRRO;
            func.ENDERECO = dto.ENDERECO;
            func.NUMERO = dto.NUMERO;
            func.COMPLEMENTO = dto.COMPLEMENTO;
            func.CEP = dto.CEP;
        }
    }
}
