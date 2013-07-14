using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EstadoCidade.Dominio.Intefaces;
using EstadoCidade.Web.Models;

namespace EstadoCidade.Web.Controllers
{
    public class EstadoController : Controller
    {
        private readonly IRepositorioDeEstados _repositorioDeEstados;

        public EstadoController(IRepositorioDeEstados repositorioDeEstados )
        {
            _repositorioDeEstados = repositorioDeEstados;
        }

        public ActionResult Index()
        {
            var estados = _repositorioDeEstados.Todos().Select(ControllerHelper.TransformarParaViewModel);
            return View(estados);
        }


        public ActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Cadastrar(EstadoViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var estado = viewModel.Model();
                _repositorioDeEstados.Inserir(estado);
                return RedirectToAction("Index");
            }

            return View(viewModel);
        }

        public ActionResult Editar(int id)
        {
            var estado = _repositorioDeEstados.Obter(id);
            return View(ControllerHelper.TransformarParaViewModel(estado));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar(EstadoViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var estado = viewModel.Model();
                _repositorioDeEstados.Atualizar(estado);

                return RedirectToAction("Index");
            }

            return View(viewModel);
        }
    }
}
