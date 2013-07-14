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

        public ActionResult Edit(int id)
        {
            return View();
        }

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
