using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using EstadoCidade.Dominio;
using EstadoCidade.Dominio.Intefaces;
using EstadoCidade.Web.Models;

namespace EstadoCidade.Web.Controllers.Api
{
    public class EstadoController : ApiController
    {
        private readonly IRepositorioDeEstados _repositorioDeEstados;

        public EstadoController(IRepositorioDeEstados repositorioDeEstados)
        {
            _repositorioDeEstados = repositorioDeEstados;
        }

        public IEnumerable<EstadoViewModel> Get()
        {
            return _repositorioDeEstados.Todos()
                .Select(ControllerHelper.TransformarParaViewModel);
        }

        public Estado Get(int id)
        {
            Estado estado = _repositorioDeEstados.Obter(id);
            if (estado == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return estado;
        }

        public HttpResponseMessage Put(int id, EstadoViewModel estado)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            if (id != estado.Id)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            _repositorioDeEstados.Atualizar(estado.Model());

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        public HttpResponseMessage Post(EstadoViewModel estado)
        {
            if (ModelState.IsValid)
            {
                _repositorioDeEstados.Inserir(estado.Model());

                return Request.CreateResponse(HttpStatusCode.Created, estado);
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        public HttpResponseMessage Delete(int id)
        {
            Estado estado = _repositorioDeEstados.Obter(id);
            if (estado == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            _repositorioDeEstados.Excluir(estado);

            return Request.CreateResponse(HttpStatusCode.OK, ControllerHelper.TransformarParaViewModel(estado));
        }
    }
}