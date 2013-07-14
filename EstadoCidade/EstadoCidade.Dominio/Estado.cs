using System;
using System.Collections.Generic;

namespace EstadoCidade.Dominio
{
    public class Estado
    {
        private IList<Cidade> _cidades;

        public Estado(int id, string uf, string nome):this(uf, nome)
        {
            if (id <= 0)
                throw new ArgumentException("Id deve ser maior que 0.", "id");

            this.Id = id;
        }

        public Estado(string uf, string nome)
        {
            if (String.IsNullOrEmpty(uf))
                throw new ArgumentNullException("uf");
            if (String.IsNullOrEmpty(nome))
                throw new ArgumentNullException("nome");
          
            this.UF = uf;
            this.Nome = nome;

            _cidades = new List<Cidade>();
        }

        public int Id { get; protected set; }
        public string UF { get; protected set; }
        public string Nome { get; protected set; }

        public IEnumerable<Cidade> Cidades
        {
            get { return _cidades; }
            protected set { _cidades = new List<Cidade>(value); }
        }

        public void AdicionarCidade(Cidade cidade)
        {
            if (cidade == null)
                throw new ArgumentNullException("cidade");

            _cidades.Add(cidade);
        }
    }
}
