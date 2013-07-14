using System;

namespace EstadoCidade.Dominio
{
    public class Cidade
    {
        public Cidade(int id, string nome, Estado estado)
        {
            if (estado == null) 
                throw new ArgumentNullException("estado");
            if (String.IsNullOrEmpty(nome))
                throw new ArgumentNullException("nome");
            if (id <= 0)
                throw new ArgumentException("Id deve ser maior que 0.", "id");
            
            this.Id = id;
            this.Nome = nome;
            this.Estado = estado;
        }

        public int Id { get; protected set; }
        public string Nome { get; protected set; }

        public Estado Estado { get; protected set; }

        public void TrocarEstado (Estado estado)
        {
            if (estado == null) 
                throw new ArgumentNullException("estado");

            Estado = estado;
        }
    }
}