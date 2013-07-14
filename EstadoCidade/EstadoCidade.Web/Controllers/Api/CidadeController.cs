using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using EstadoCidade.Dominio.Intefaces;
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

        public IEnumerable<CidadeViewModel> Get()
        {
            return _repositorioDeCidades.Todos().Select(ControllerHelper.TransformarParaViewModel);
        }


        public CidadeViewModel Get(int id)
        {
            var cidade = _repositorioDeCidades.Obter(id);
            if (cidade == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return ControllerHelper.TransformarParaViewModel(cidade);
        }

        public HttpResponseMessage Put(int id, CidadeViewModel cidade)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            if (id != cidade.Id)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            _repositorioDeCidades.Atualizar(cidade.Model());

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        public HttpResponseMessage Post(CidadeViewModel cidade)
        {
            if (ModelState.IsValid)
            {
                _repositorioDeCidades.Inserir(cidade.Model());

                return Request.CreateResponse(HttpStatusCode.Created, cidade);
            }
            return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
        }

        public HttpResponseMessage Delete(int id)
        {
            var cidade = _repositorioDeCidades.Obter(id);
            if (cidade == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            _repositorioDeCidades.Excluir(cidade);

            return Request.CreateResponse(HttpStatusCode.OK, cidade);
        }

       
    }
}