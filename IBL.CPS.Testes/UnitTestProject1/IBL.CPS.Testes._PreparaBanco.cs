using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data.Entity.Infrastructure;
using IBL.CPS.Repositorio;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        static public Boolean ExecutarSQl(String Query)
        {
            try
            {
                var ct = new dbCPSEntities();
                ((IObjectContextAdapter)ct).ObjectContext.ExecuteStoreQuery<dbCPSEntities>(Query);
                return true;
            }
            catch (Exception ex)
            {
                return false;
                throw ex;
            }
        }


        [TestMethod]
        public void LimparBanco()
        {
            try
            {
                ExecutarSQl("DROP TABLE PARTICIPANTE;");
                ExecutarSQl("DROP TABLE GRUPO;");
                ExecutarSQl("DROP TABLE TIPOGRUPO;");
                ExecutarSQl("DROP TABLE CASAL;");
                ExecutarSQl("DROP TABLE PESSOA;");
                ExecutarSQl("DROP TABLE FUNCAO;");
                ExecutarSQl(@"CREATE TABLE PESSOA (
                          IDPESSOA         INT IDENTITY(1,1) NOT NULL,
                          NUMERO_DE_MEMBRO INT               NOT NULL,
                          SEXO             CHAR(1)           NOT NULL,
                          NOME             VARCHAR(30)       NOT NULL,
                          DATANASC         DATE              NOT NULL,
                          RG               VARCHAR(11)       NOT NULL,
                          CPF              VARCHAR(11)       NOT NULL,
                          TELEFONE_FIXO    VARCHAR(10)       NOT NULL,
                          CELULAR          VARCHAR(10)       NULL,
                          E_MAIL           VARCHAR(30)       NULL,
                          PRIMARY KEY(IDPESSOA));");

                ExecutarSQl(@"CREATE TABLE CASAL (
                          IDCASAL      INT IDENTITY(1,1) NOT NULL,
                          IDMARIDO     INT               NOT NULL,
                          IDESPOSA     INT               NOT NULL,
                          FUNCAO_ATUAL INT               NOT NULL,
                          UF           CHAR(02)          NOT NULL,
                          CIDADE       VARCHAR(80)       NOT NULL,
                          BAIRRO       VARCHAR(80)       NOT NULL,
                          ENDERECO     VARCHAR(80)       NOT NULL,
                          NUMERO       VARCHAR(10)       NOT NULL,
                          COMPLEMENTO  VARCHAR(10)       NULL,
                          CEP          VARCHAR(10)       NULL,
                          PRIMARY KEY(IDCASAL)
                         ); ");

                ExecutarSQl(@"CREATE TABLE FUNCAO (
                          IDFUNCAO  INT IDENTITY(1,1) NOT NULL,
                          DESCRICAO VARCHAR(30)       NOT NULL,
                          PRIMARY KEY(IDFUNCAO)
                          ); ");

                ExecutarSQl(@"CREATE TABLE PARTICIPANTE (
                          IDPARTICIPANTE  INT IDENTITY(1,1) NOT NULL,
                          IDCASAL         INT               NOT NULL,
                          IDGRUPO         INT               NOT NULL,
                          FUNCAO_NA_EPOCA INT               NOT NULL,
                          PRIMARY KEY(IDPARTICIPANTE)
                         );  ");

                ExecutarSQl(@"CREATE TABLE GRUPO(
                          IDGRUPO               INT IDENTITY(1,1) NOT NULL,
                          LIDER                 INT               NOT NULL,
                          LIDER_EM_TREINAMENTO  INT               NULL,
                          UF                    CHAR(02)          NOT NULL,
                          CIDADE                VARCHAR(80)       NOT NULL,
                          BAIRRO                VARCHAR(80)       NOT NULL,
                          ENDERECO              VARCHAR(80)       NOT NULL,
                          NUMERO                VARCHAR(10)       NULL,
                          COMPLEMENTO           VARCHAR(10)       NULL,
                          CEP                   VARCHAR(10)       NULL,
                          SEMESTRE              INT               NOT NULL,
                          ANO                   INT               NOT NULL,
                          TIPOGRUPO             INT               NOT NULL,
                          PRIMARY KEY(IDGRUPO)
                         );");

                ExecutarSQl(@"CREATE TABLE TIPOGRUPO(
                          IDTIPOGRUPO INT IDENTITY(1,1) NOT NULL,
                          DESCRICAO   VARCHAR(30)       NOT NULL,
                          PRIMARY KEY(IDTIPOGRUPO)
                         );   ");

                ExecutarSQl(@"ALTER TABLE CASAL
                          ADD CONSTRAINT fk_CASAL_IDMARIDO
                          FOREIGN KEY (IDMARIDO)
                          REFERENCES PESSOA(IDPESSOA);");

                ExecutarSQl(@"ALTER TABLE CASAL
                          ADD CONSTRAINT fk_CASAL_IDESPOSA
                          FOREIGN KEY (IDESPOSA)
                          REFERENCES PESSOA(IDPESSOA); ");

                ExecutarSQl(@"ALTER TABLE CASAL
                          ADD CONSTRAINT fk_CASAL_FUNCAO_ATUAL
                          FOREIGN KEY (FUNCAO_ATUAL)
                          REFERENCES FUNCAO(IDFUNCAO);");

                ExecutarSQl(@"ALTER TABLE PARTICIPANTE
                          ADD CONSTRAINT fk_PARTICIPANTE_IDCASAL
                          FOREIGN KEY (IDCASAL)
                          REFERENCES CASAL(IDCASAL);");

                ExecutarSQl(@"ALTER TABLE PARTICIPANTE
                          ADD CONSTRAINT fk_PARTICIPANTE_IDGRUPO
                          FOREIGN KEY (IDGRUPO)
                          REFERENCES GRUPO(IDGRUPO); ");

                ExecutarSQl(@"ALTER TABLE PARTICIPANTE
                          ADD CONSTRAINT fk_PARTICIPANTE_FUNCAO_NA_EPOCA
                          FOREIGN KEY (FUNCAO_NA_EPOCA)
                          REFERENCES FUNCAO(IDFUNCAO);");

                ExecutarSQl(@"ALTER TABLE GRUPO
                          ADD CONSTRAINT fk_GRUPO_LIDER
                          FOREIGN KEY (LIDER)
                          REFERENCES CASAL(IDCASAL);");

                ExecutarSQl(@"ALTER TABLE GRUPO
                          ADD CONSTRAINT fk_GRUPO_LIDER_EM_TREINAMENTO
                          FOREIGN KEY (LIDER_EM_TREINAMENTO)
                          REFERENCES TIPOGRUPO(IDTIPOGRUPO);");

                ExecutarSQl(@"ALTER TABLE GRUPO
                          ADD CONSTRAINT fk_GRUPO_TIPOGRUPO
                          FOREIGN KEY (TIPOGRUPO)
                          REFERENCES CASAL(IDCASAL);");

                ExecutarSQl(@"DELETE FROM FUNCAO;
                          insert into funcao (Descricao) values ('LIDERADO');
                          insert into funcao (Descricao) values ('NAMORADO DE CELULA');
                          insert into funcao (Descricao) values ('LIDER EM TREINAMENTO');
                          insert into funcao (Descricao) values ('LIDER');
                          insert into funcao (Descricao) values ('SUPERVISOR');
                          insert into funcao (Descricao) values ('COORDENADOR');
                          insert into funcao (Descricao) values ('PASTOR');");

                Assert.IsTrue(false);

            }
            catch (Exception ex)
            {
                 Console.WriteLine(ex.Message);
                 Assert.IsTrue(true);
            }; 
        }
    }
}
