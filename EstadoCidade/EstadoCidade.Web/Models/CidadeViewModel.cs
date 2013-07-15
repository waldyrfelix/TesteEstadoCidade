using System.ComponentModel.DataAnnotations;
using EstadoCidade.Dominio;

namespace EstadoCidade.Web.Models
{
    public class CidadeViewModel
    {
        public int Id { get; set; }
        [Required, StringLength(50)]
        public string Nome { get; set; }
        public bool Capital { get; set; }
        [Required]
        public int EstadoId { get; set; }

        public Cidade Model()
        {
            if (Id > 0)
            {
                return new Cidade(Id, Nome, Capital, EstadoId);
                
            }
            return new Cidade(Nome, Capital, EstadoId);
        }
    }
}