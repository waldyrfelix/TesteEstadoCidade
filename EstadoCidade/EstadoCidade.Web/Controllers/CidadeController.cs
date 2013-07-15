using System.Linq;
using System.Web.Mvc;
using EstadoCidade.Dominio.Intefaces;
using EstadoCidade.Web.Models;

namespace EstadoCidade.Web.Controllers
{
    public class CidadeController : Controller
    {
        private readonly IRepositorioDeCidades _repositorioDeCidades;
        private readonly IRepositorioDeEstados _repositorioDeEstados;

        public CidadeController(IRepositorioDeCidades repositorioDeCidades, IRepositorioDeEstados repositorioDeEstados)
        {
            _repositorioDeCidades = repositorioDeCidades;
            _repositorioDeEstados = repositorioDeEstados;
        }

        public ActionResult Index()
        {
            var cidades = _repositorioDeCidades.Todos().Select(ControllerHelper.TransformarParaViewModel);
            return View(cidades);
        }


        public ActionResult Cadastrar()
        {
            ViewBag.Estados = _repositorioDeEstados.Todos();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Cadastrar(CidadeViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var cidade = viewModel.Model();
                _repositorioDeCidades.Inserir(cidade);
                return RedirectToAction("Index");
            }
            
            ViewBag.Estados = _repositorioDeEstados.Todos();
            return View(viewModel);
        }

        public ActionResult Editar(int id)
        {
            ViewBag.Estados = _repositorioDeEstados.Todos();
            var cidade = _repositorioDeCidades.Obter(id);
            return View(ControllerHelper.TransformarParaViewModel(cidade));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar(CidadeViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var cidade = viewModel.Model();
                _repositorioDeCidades.Atualizar(cidade);

                return RedirectToAction("Index");
            }

            ViewBag.Estados = _repositorioDeEstados.Todos();
            return View(viewModel);
        }
    }
}
