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
    static public class ControladorPessoa
    {
        static public List<PessoaDTO>
        ObterLista()
        {
            IQueryable<PESSOA> e = null;
            List<PessoaDTO> r = null;
            using (var ct = new dbCPSEntities())
            {
                e = ct.PESSOA;

                r = e.ToList().ConvertAll(x => (PessoaDTO)x);
            }

            return r;

        }
        static public void Incluir(PessoaDTO dto)
        {
            String erros = null;
            if (!ValidarGravacao(dto, out erros))
                throw new ValidationException(erros);
            PESSOA func = new PESSOA();
            using (var ct = new dbCPSEntities())
            {
                AtualizarObjeto(ct, dto, ref func);
                //ct.PESSOA.AddObject(func);
                ((IObjectContextAdapter)ct.PESSOA).ObjectContext.AddObject("PESSOA", func);
                ct.SaveChanges();
            }
        }

        static public void Gravar(PessoaDTO dto)
        {
            if (dto.IDPESSOA == 0)
                throw new Exception("Objeto não possui Id. Inválido para gravação.");

            String erros = null;
            if (!ValidarGravacao(dto, out erros))
                throw new ValidationException(erros);

            using (var ct = new dbCPSEntities())
            {
                PESSOA func = ObterEntidade(ct, dto.IDPESSOA);

                if (func == null)
                    throw new Exception(String.Format("Id não encontrado {0}.", dto.IDPESSOA));

                AtualizarObjeto(ct, dto, ref func);
                ct.SaveChanges();
            }
        }

        static public void Excluir(Int32 Id)
        {
            using (var ct = new dbCPSEntities())
            {
                PESSOA func = ObterEntidade(ct, Id);

                if (func == null)
                    throw new Exception(String.Format("Id não encontrado {0}.", Id));


                String erros = null;
                if (!ValidarExclusao(func, out erros))
                    throw new ValidationException(erros);


                ((IObjectContextAdapter)ct).ObjectContext.DeleteObject(func);
                ct.SaveChanges();
            }
        }

        static public PESSOA ObterEntidade(dbCPSEntities ct, Int32 Id)
        {
            PESSOA obj = null;
            obj = (PESSOA)RepositorioUtils.ObterObjeto(ct, "PESSOA", "IDPESSOA" , Id);

            return obj;
        }

        static public PessoaDTO Obter(Int32 Id)
        {
            PessoaDTO r = null;
            using (var ct = new dbCPSEntities())
            {
                r = (PessoaDTO)ObterEntidade(ct, Id);
            }
            return r;
        }

        static private Boolean ValidarGravacao(PessoaDTO dto, out String erros)
        {
            erros = String.Empty;
            StringBuilder listaErros = new StringBuilder();
            if (dto.NUMERO_DE_MEMBRO == 0)
                listaErros.AppendLine("O Número de membro deve ser informado.");

            if (String.IsNullOrEmpty(dto.SEXO) || String.IsNullOrWhiteSpace(dto.SEXO))
                listaErros.AppendLine("O Sexo deve ser informado.");

            if (String.IsNullOrEmpty(dto.NOME) || String.IsNullOrWhiteSpace(dto.NOME))
                listaErros.AppendLine("O Nome deve ser informada.");

            if (dto.DATANASC == new DateTime())
                listaErros.AppendLine("A data de nascimento deve ser informada.");

            if (String.IsNullOrEmpty(dto.RG) || String.IsNullOrWhiteSpace(dto.RG))
                listaErros.AppendLine("O RG deve ser informado.");

            if (String.IsNullOrEmpty(dto.CPF) || String.IsNullOrWhiteSpace(dto.CPF))
                listaErros.AppendLine("O CPF deve ser informado.");

            if (String.IsNullOrEmpty(dto.TELEFONE_FIXO) || String.IsNullOrWhiteSpace(dto.TELEFONE_FIXO))
                listaErros.AppendLine("O Telefone fixo deve ser informado.");

            if (String.IsNullOrEmpty(dto.CELULAR) || String.IsNullOrWhiteSpace(dto.CELULAR))
                listaErros.AppendLine("O celular deve ser informado.");

            if (String.IsNullOrEmpty(dto.E_MAIL) || String.IsNullOrWhiteSpace(dto.E_MAIL))
                listaErros.AppendLine("O e-mail deve ser informado.");

            Boolean valido = listaErros.Length == 0;

            if (!valido)
                erros = "Alguns erros impedem a gravação deste registro. Favor verificar: " + Environment.NewLine + listaErros.ToString();


            return valido;
        }


        static private Boolean ValidarExclusao(PESSOA obj, out String erros)
        {
            erros = String.Empty;
            StringBuilder listaErros = new StringBuilder();

            if (obj.CASAL.Count > 0)
                listaErros.AppendLine("Alguns casais estão associados a esta Função.");

            Boolean valido = listaErros.Length == 0;

            if (!valido)
                erros = "Alguns erros impedem a exclusão deste registro. Favor verificar: " + Environment.NewLine + listaErros.ToString();


            return valido;
        }


        static public void AtualizarObjeto(dbCPSEntities ct, PessoaDTO dto, ref PESSOA func)
        {
            func.NUMERO_DE_MEMBRO = dto.NUMERO_DE_MEMBRO;
            func.SEXO = dto.SEXO;
            func.NOME = dto.NOME;
            func.DATANASC = dto.DATANASC;
            func.RG = dto.RG;
            func.CPF = dto.CPF;
            func.TELEFONE_FIXO = dto.TELEFONE_FIXO;
            func.CELULAR = dto.CELULAR;
            func.E_MAIL = dto.E_MAIL;
        }
    }
}
