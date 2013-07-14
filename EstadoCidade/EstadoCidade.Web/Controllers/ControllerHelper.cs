using EstadoCidade.Dominio;
using EstadoCidade.Web.Models;

namespace EstadoCidade.Web.Controllers
{
    public class ControllerHelper
    {
        public static CidadeViewModel TransformarParaViewModel(Cidade cidade)
        {
            return new CidadeViewModel
            {
                Id = cidade.Id,
                Capital = cidade.Capital,
                Nome = cidade.Nome,
                EstadoId = cidade.EstadoId
            };
        }


        public static EstadoViewModel TransformarParaViewModel(Estado estado)
        {
            return new EstadoViewModel
            {
                Id = estado.Id,
                Nome = estado.Nome,
                Regiao = estado.Regiao,
                Sigla = estado.Sigla,
                Pais = estado.Pais
            };
        }
    }
}