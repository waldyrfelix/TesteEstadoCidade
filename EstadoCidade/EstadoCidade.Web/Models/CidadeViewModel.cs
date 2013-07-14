using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EstadoCidade.Dominio;

namespace EstadoCidade.Web.Models
{
    public class CidadeViewModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public bool Capital { get; set; }
        public int EstadoId { get; set; }

        public Cidade Model()
        {
            return new Cidade(Id, Nome, Capital, EstadoId);
        }
    }
}