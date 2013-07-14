using EstadoCidade.Dominio;

namespace EstadoCidade.Web.Models
{
    public class EstadoViewModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Sigla { get;  set; }
        public string Pais { get;  set; }
        public string Regiao { get;  set; }

        public Estado Model()
        {
            return new Estado(Id, Pais, Regiao,Sigla, Nome);
        }
    }
}