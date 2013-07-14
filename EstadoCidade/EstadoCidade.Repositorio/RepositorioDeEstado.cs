using System;
using System.Collections.Generic;
using System.Data.Common;
using EstadoCidade.Dominio;
using EstadoCidade.Dominio.Intefaces;

namespace EstadoCidade.Repositorio
{
    public class RepositorioDeEstado : Repositorio<Estado>, IRepositorioDeEstados
    {
        protected override string SqlParaAtualizar
        {
            get { throw new NotImplementedException(); }
        }

        protected override string SqlParaDeletar
        {
            get { throw new NotImplementedException(); }
        }

        protected override string SqlParaInserir
        {
            get { throw new NotImplementedException(); }
        }

        protected override string SqlParaObterUm
        {
            get { throw new NotImplementedException(); }
        }

        protected override Estado HidratarObjeto(DbDataReader dataReader)
        {
            throw new NotImplementedException();
        }

        protected override IEnumerable<DbParameter> PreencherParametros(DbCommand command, Estado objeto)
        {
            throw new NotImplementedException();
        }
    }
}