using System.ComponentModel.DataAnnotations;
using EstadoCidade.Dominio;

namespace EstadoCidade.Web.Models
{
    public class EstadoViewModel
    {
        public int Id { get; set; }
        [Required, StringLength(50)]
        public string Nome { get; set; }
        [Required, StringLength(2)]
        public string Sigla { get; set; }
        [Required, StringLength(50)]
        public string Pais { get; set; }
        [Required, StringLength(50)]
        public string Regiao { get; set; }

        public Estado Model()
        {
            if (Id > 0)
            {
                return new Estado(Id, Pais, Regiao, Sigla, Nome);
                
            }
            return new Estado(Pais, Regiao, Sigla, Nome);
        }
    }
}