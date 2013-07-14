using System;
using System.Collections.Generic;

namespace EstadoCidade.Dominio
{
    public class Estado
    {
        private IList<Cidade> _cidades;

        public Estado(int id, string pais, string regiao, string sigla, string nome)
            : this(pais, regiao, sigla, nome)
        {
            if (id <= 0)
                throw new ArgumentException("Id deve ser maior que 0.", "id");

            this.Id = id;
        }

        public Estado(string pais, string regiao, string sigla, string nome)
        {
            if (String.IsNullOrEmpty(pais))
                throw new ArgumentNullException("pais");
            if (String.IsNullOrEmpty(regiao))
                throw new ArgumentNullException("regiao");
            if (String.IsNullOrEmpty(sigla))
                throw new ArgumentNullException("sigla");
            if (String.IsNullOrEmpty(nome))
                throw new ArgumentNullException("nome");

            this.Sigla = sigla;
            this.Nome = nome;
            this.Pais = pais;
            this.Regiao = regiao;

            _cidades = new List<Cidade>();
        }

        public int Id { get; protected set; }
        public string Sigla { get; protected set; }
        public string Nome { get; protected set; }
        public string Pais { get; protected set; }
        public string Regiao { get; protected set; }

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
