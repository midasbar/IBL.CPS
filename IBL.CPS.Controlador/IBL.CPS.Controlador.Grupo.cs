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
    static public class ControladorGrupo
    {
        static public List<GrupoDTO>
        ObterLista()
        {
            IQueryable<GRUPO> e = null;
            List<GrupoDTO> r = null;
            using (var ct = new dbCPSEntities())
            {
                e = ct.GRUPO;

                r = e.ToList().ConvertAll(x => (GrupoDTO)x);
            }

            return r;

        }

        static public void Incluir(GrupoDTO dto)
        {
            String erros = null;
            if (!ValidarGravacao(dto, out erros))
                throw new ValidationException(erros);
            GRUPO func = new GRUPO();
            using (var ct = new dbCPSEntities())
            {
                AtualizarObjeto(ct, dto, ref func);
                // ct.GRUPO.AddObject(func);
                ((IObjectContextAdapter)ct).ObjectContext.AddObject("GRUPO", func);
                ct.SaveChanges();
            }
        }

        static public void Gravar(GrupoDTO dto)
        {
            if (dto.IDGRUPO == 0)
                throw new Exception("Objeto não possui Id. Inválido para gravação.");

            String erros = null;
            if (!ValidarGravacao(dto, out erros))
                throw new ValidationException(erros);

            using (var ct = new dbCPSEntities())
            {
                GRUPO func = ObterEntidade(ct, dto.IDGRUPO);

                if (func == null)
                    throw new Exception(String.Format("Id não encontrado {0}.", dto.IDGRUPO));

                AtualizarObjeto(ct, dto, ref func);
                ct.SaveChanges();
            }
        }

        static public void Excluir(Int32 Id)
        {
            using (var ct = new dbCPSEntities())
            {
                GRUPO func = ObterEntidade(ct, Id);

                if (func == null)
                    throw new Exception(String.Format("Id não encontrado {0}.", Id));


                String erros = null;
                if (!ValidarExclusao(func, out erros))
                    throw new ValidationException(erros);


                ((IObjectContextAdapter)ct).ObjectContext.DeleteObject(func);
                ct.SaveChanges();
            }
        }

        static public GRUPO ObterEntidade(dbCPSEntities ct, Int32 Id)
        {
            GRUPO obj = null;
            obj = (GRUPO)RepositorioUtils.ObterObjeto(ct, "GRUPO", "IDGRUPO" , Id);

            return obj;
        }

        static public GrupoDTO Obter(Int32 Id)
        {
            GrupoDTO r = null;
            using (var ct = new dbCPSEntities())
            {
                r = (GrupoDTO)ObterEntidade(ct, Id);
            }
            return r;
        }

        static private Boolean ValidarGravacao(GrupoDTO dto, out String erros)
        {
            erros = String.Empty;
            StringBuilder listaErros = new StringBuilder();

            if (dto.LIDER ==0)
                listaErros.AppendLine("O Lider deve ser informado.");

            if (dto.LIDER_EM_TREINAMENTO ==0)
                listaErros.AppendLine("O Lider em treinamento deve ser informado.");

            if (String.IsNullOrEmpty(dto.UF) || String.IsNullOrWhiteSpace(dto.UF))
                listaErros.AppendLine("UF deve ser informada.");

            if (String.IsNullOrEmpty(dto.CIDADE) || String.IsNullOrWhiteSpace(dto.CIDADE))
                listaErros.AppendLine("A Cidade deve ser informada.");

            if (String.IsNullOrEmpty(dto.BAIRRO) || String.IsNullOrWhiteSpace(dto.BAIRRO))
                listaErros.AppendLine("O Bairro deve ser informado.");

            if (String.IsNullOrEmpty(dto.ENDERECO) || String.IsNullOrWhiteSpace(dto.ENDERECO))
                listaErros.AppendLine("O Endereco deve ser informado.");

            if (String.IsNullOrEmpty(dto.NUMERO) || String.IsNullOrWhiteSpace(dto.NUMERO))
                listaErros.AppendLine("O Numero deve ser informado.");

            if (String.IsNullOrEmpty(dto.COMPLEMENTO) || String.IsNullOrWhiteSpace(dto.COMPLEMENTO))
                listaErros.AppendLine("O Complemento deve ser informado.");

            if (String.IsNullOrEmpty(dto.CEP) || String.IsNullOrWhiteSpace(dto.CEP))
                listaErros.AppendLine("O Cep deve ser informado.");

            if (dto.SEMESTRE ==0)
                listaErros.AppendLine("O Semestre deve ser informado.");

            if (dto.ANO ==0)
                listaErros.AppendLine("O Ano deve ser informado.");

            if (dto.TIPOGRUPO ==0)
                listaErros.AppendLine("O Tipo Grupo deve ser informado.");
            Boolean valido = listaErros.Length == 0;

            if (!valido)
                erros = "Alguns erros impedem a gravação deste registro. Favor verificar: " + Environment.NewLine + listaErros.ToString();


            return valido;
        }


        static private Boolean ValidarExclusao(GRUPO obj, out String erros)
        {
            erros = String.Empty;
            StringBuilder listaErros = new StringBuilder();

            if (obj.PARTICIPANTE.Count > 0)
                listaErros.AppendLine("Alguns casais estão associados a esta Função.");

            Boolean valido = listaErros.Length == 0;

            if (!valido)
                erros = "Alguns erros impedem a exclusão deste registro. Favor verificar: " + Environment.NewLine + listaErros.ToString();


            return valido;
        }


        static public void AtualizarObjeto(dbCPSEntities ct, GrupoDTO dto, ref GRUPO func)
        {
            func.LIDER = dto.LIDER;
            func.LIDER_EM_TREINAMENTO = dto.LIDER_EM_TREINAMENTO;
            func.UF = dto.UF;
            func.CIDADE = dto.CIDADE;
            func.BAIRRO = dto.BAIRRO;
            func.ENDERECO = dto.ENDERECO;
            func.NUMERO = dto.NUMERO;
            func.COMPLEMENTO = dto.COMPLEMENTO;
            func.CEP = dto.CEP;
            func.SEMESTRE = dto.SEMESTRE;
            func.ANO = dto.ANO;
            func.TIPOGRUPO = dto.TIPOGRUPO;
        }
    }
}
