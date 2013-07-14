using System.Collections.Generic;

namespace EstadoCidade.Dominio.Intefaces
{
    public interface IRepositorio<T>
        where T : class
    {
        void Atualizar(T objeto);
        void Excluir(T objeto);
        void Inserir(T objeto);
        IEnumerable<T> Todos();
        T Obter(int id);
    }
}