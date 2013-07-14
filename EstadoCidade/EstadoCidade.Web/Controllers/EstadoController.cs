using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EstadoCidade.Dominio.Intefaces;

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


        public ActionResult Create()
        {
            return View();
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
