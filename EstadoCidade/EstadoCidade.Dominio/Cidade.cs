using System;

namespace EstadoCidade.Dominio
{
    public class Cidade
    {
        public Cidade(int id, string nome, bool capital, int estadoId)
            : this(nome, capital, estadoId)
        {
            if (id <= 0)
                throw new ArgumentException("Id deve ser maior que 0.", "id");
            this.Id = id;
        }

        public Cidade(string nome, bool capital, int estadoId)
        {
            if (String.IsNullOrEmpty(nome))
                throw new ArgumentNullException("nome");

            if (estadoId <= 0)
                throw new ArgumentException("EstadoId deve ser maior que 0.", "estadoId");

            this.Nome = nome;
            this.EstadoId = estadoId;
            this.Capital = capital;
        }

        public int Id { get; protected set; }
        public string Nome { get; protected set; }
        public bool Capital { get; protected set; }
        public int EstadoId { get; protected set; }
        public Estado Estado { get; protected set; }

        public void TrocarEstado(Estado estado)
        {
            if (estado == null)
                throw new ArgumentNullException("estado");

            Estado = estado;
        }
    }
}