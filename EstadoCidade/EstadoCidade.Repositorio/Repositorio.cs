using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using EstadoCidade.Dominio.Intefaces;

namespace EstadoCidade.Repositorio
{
    public abstract class Repositorio<T> : IRepositorio<T> where T : class
    {
        public void Atualizar(T objeto)
        {
            ExecutarComando((command) =>
            {
                command.CommandText = SqlParaAtualizar;
                foreach (var parameter in PreencherParametros(command, objeto))
                {
                    command.Parameters.Add(parameter);
                }
                command.ExecuteNonQuery();
            });
        }

        public void Excluir(T objeto)
        {
            ExecutarComando((command) =>
            {
                command.CommandText = SqlParaDeletar;
                foreach (var parameter in PreencherParametros(command, objeto))
                {
                    command.Parameters.Add(parameter);
                }
                command.ExecuteNonQuery();
            });
        }

        public void Inserir(T objeto)
        {
            ExecutarComando((command) =>
            {
                command.CommandText = SqlParaInserir;
                foreach (var parameter in PreencherParametros(command, objeto))
                {
                    command.Parameters.Add(parameter);
                }
                command.ExecuteNonQuery();
            });
        }

        public IEnumerable<T> Todos()
        {
            var objetos = new List<T>();

            ExecutarComando((command) =>
                {
                    command.CommandText = SqlParaObterUm;
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                        objetos.Add(HidratarObjeto(reader));
                });

            return objetos;
        }

        public T Obter(int id)
        {
            T objeto = default(T);

            ExecutarComando((command) =>
                {
                    command.CommandText = SqlParaObterUm;

                    var parameter = command.CreateParameter();
                    parameter.ParameterName = "@id";
                    parameter.Value = id;

                    command.Parameters.Add(parameter);

                    var reader = command.ExecuteReader();
                    objeto = reader.Read() ? HidratarObjeto(reader) : null;
                });

            return objeto;
        }

        protected string ConnectionString
        {
            get { return ConfigurationManager.ConnectionStrings["DefaultConnectionString"].ConnectionString; }
        }

        protected string ProviderName
        {
            get { return ConfigurationManager.ConnectionStrings["DefaultConnectionString"].ProviderName; }
        }

        protected abstract string SqlParaAtualizar { get; }
        protected abstract string SqlParaDeletar { get; }
        protected abstract string SqlParaInserir { get; }
        protected abstract string SqlParaObterUm { get; }
        protected abstract T HidratarObjeto(DbDataReader dataReader);
        protected abstract IEnumerable<DbParameter> PreencherParametros(DbCommand command, T objeto);

        private void ExecutarComando(Action<DbCommand> action)
        {
            var factory = DbProviderFactories.GetFactory(ProviderName);
            var connection = factory.CreateConnection();
            connection.ConnectionString = this.ConnectionString;

            try
            {
                connection.Open();
                action(connection.CreateCommand());
            }
            catch (DbException exception)
            {
                throw;
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
        }
    }
}