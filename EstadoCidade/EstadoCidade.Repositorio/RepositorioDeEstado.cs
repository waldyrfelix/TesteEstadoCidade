using System;
using System.Collections.Generic;
using System.Data.Common;
using EstadoCidade.Dominio;
using EstadoCidade.Dominio.Intefaces;

namespace EstadoCidade.Repositorio
{
    public class RepositorioDeEstados : Repositorio<Estado>, IRepositorioDeEstados
    {
        protected override string SqlParaAtualizar
        {
            get { return "update estado set nome=@nome, pais=@pais, regiao=@regiao, sigla=@sigla where id = @id"; }
        }

        protected override string SqlParaDeletar
        {
            get { return "delete from estado where id = @id"; }
        }

        protected override string SqlParaInserir
        {
            get { return "insert into estado (nome, pais, regiao, sigla) values (@nome, @pais, @regiao, @sigla)"; }
        }

        protected override string SqlParaObterUm
        {
            get { return "select id, nome, sigla, pais, regiao from estado where id = @id"; }
        }

        protected override string SqlParaObterTodos
        {
            get { return "select id, nome, sigla, pais, regiao from estado "; }
        }

        protected override Estado HidratarObjeto(DbDataReader dataReader)
        {
            return new Estado(
                id: dataReader.GetInt32(0),
                nome: dataReader.GetString(1),
                sigla: dataReader.GetString(2),
                pais: dataReader.GetString(3),
                regiao: dataReader.GetString(4)
            );
        }

        protected override IEnumerable<DbParameter> PreencherParametros(DbCommand command, Estado objeto)
        {
            var parameter1 = command.CreateParameter();
            parameter1.ParameterName = "@id";
            parameter1.Value = objeto.Id;

            yield return parameter1;

            var parameter2 = command.CreateParameter();
            parameter2.ParameterName = "@nome";
            parameter2.Value = objeto.Nome;

            yield return parameter2;

            var parameter3 = command.CreateParameter();
            parameter3.ParameterName = "@sigla";
            parameter3.Value = objeto.Sigla;

            yield return parameter3;

            var parameter4 = command.CreateParameter();
            parameter4.ParameterName = "@pais";
            parameter4.Value = objeto.Pais;

            yield return parameter4;

            var parameter5 = command.CreateParameter();
            parameter5.ParameterName = "@regiao";
            parameter5.Value = objeto.Regiao;

            yield return parameter5;
        }
    }
}