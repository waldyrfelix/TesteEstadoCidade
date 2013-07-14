using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using EstadoCidade.Dominio;
using EstadoCidade.Dominio.Intefaces;
using System.Linq;
using EstadoCidade.Web.Models;

namespace EstadoCidade.Web.Controllers.Api
{
    public class CidadeController : ApiController
    {
        private readonly IRepositorioDeCidades _repositorioDeCidades;

        public CidadeController(IRepositorioDeCidades repositorioDeCidades)
        {
            _repositorioDeCidades = repositorioDeCidades;
        }

        // GET api/cidade
        public IEnumerable<CidadeViewModel> Get()
        {
            return _repositorioDeCidades.Todos()
                .Select(TransformarEmViewModel);
        }

        // GET api/cidade/5
        public HttpResponseMessage Get(int id)
        {
            var cidade = _repositorioDeCidades.Obter(id);
            if (cidade == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Cidade não encontrada.");
            }

            return Request.CreateResponse(HttpStatusCode.OK, TransformarEmViewModel(cidade));
        }


        // POST api/cidade
        public void Post([FromBody]CidadeViewModel cidade)
        {
            _repositorioDeCidades.Inserir(cidade.Model());
        }

        // PUT api/cidade/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/cidade/5
        public void Delete(int id)
        {
        }


        private CidadeViewModel TransformarEmViewModel(Cidade cidade)
        {
            return new CidadeViewModel
            {
                Id = cidade.Id,
                Nome = cidade.Nome
            };
        }
    }
}
