using System;
using System.Collections.Generic;
using System.Data.Common;
using EstadoCidade.Dominio;
using EstadoCidade.Dominio.Intefaces;

namespace EstadoCidade.Repositorio
{
    public class RepositorioDeCidades : Repositorio<Cidade>, IRepositorioDeCidades
    {
        protected override string SqlParaAtualizar
        {
            get { return "update cidade set nome = @nome, capital = @capital, estadoId = @estadoId where id = @id"; }
        }

        protected override string SqlParaDeletar
        {
            get { return "delete from cidade where id = @id"; }
        }

        protected override string SqlParaInserir
        {
            get { return "insert into cidade (nome, capital, estadoId) values (@nome, @capital, @estadoId)"; }
        }

        protected override string SqlParaObterUm
        {
            get { return "select id, nome, capital, estadoId from cidade where id = @id"; }
        }

        protected override string SqlParaObterTodos
        {
            get { return "select id, nome, capital, estadoId from cidade"; }
        }

        protected override Cidade HidratarObjeto(DbDataReader dataReader)
        {
            return new Cidade(
               id: dataReader.GetInt32(0),
               nome: dataReader.GetString(1),
               capital: dataReader.GetBoolean(2),
               estadoId: dataReader.GetInt32(3));
        }

        protected override IEnumerable<DbParameter> PreencherParametros(DbCommand command, Cidade objeto)
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
            parameter3.ParameterName = "@capital";
            parameter3.Value = objeto.Capital;

            yield return parameter3;

            var parameter4 = command.CreateParameter();
            parameter4.ParameterName = "@estadoId";
            parameter4.Value = objeto.EstadoId;

            yield return parameter4;

        }
    }
}
