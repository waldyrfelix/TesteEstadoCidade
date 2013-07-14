using System.Collections.Generic;

namespace EstadoCidade.Dominio.Intefaces
{
    public interface IRepositorio<T>
        where T : class
    {
        void Atualizar(T objeto);
        void Excluir(int id);
        void Inserir(T objeto);
        IEnumerable<T> Todas();
        T Obter(int id);
    }
}