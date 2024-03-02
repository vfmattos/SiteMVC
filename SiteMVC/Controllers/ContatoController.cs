using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using SiteMVC.Filters;
using SiteMVC.Models;
using SiteMVC.Repositorio.Contatos;

namespace SiteMVC.Controllers
{
    [LogadoFilter]
    public class ContatoController : Controller
    {
        private readonly IContatoRepositorio _contatoRepositorio;
        public ContatoController(IContatoRepositorio contatoRepositorio) {
        
            _contatoRepositorio = contatoRepositorio;

        }
        public IActionResult Index()
        {
            var list = _contatoRepositorio.Listar();
            return View(list);
        }

        public IActionResult Criar()
        {
            return View();
        }

        public IActionResult Editar(int id)
        {
            var contatoID = _contatoRepositorio.ListarPorID(id);
            return View(contatoID);
        }

        public IActionResult Apagar(int id)
        {
            var contatoID = _contatoRepositorio.ListarPorID(id);
            return View(contatoID);
        }

        [HttpPost]
        public IActionResult Criar(ContatoModel contato)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    _contatoRepositorio.Adicionar(contato);
                    TempData["MensagemSucesso"] = "Contato cadastrado com sucesso!";
                    return RedirectToAction("Index");
                }

                return View("Criar", contato);
            }
            catch (System.Exception erro)
            {
                TempData["MensagemErro"] = $"Falha ao cadastrar contato: {erro.Message}";
                return RedirectToAction("Index");
            }
              
        }

        [HttpPost]
        public IActionResult Editar(ContatoModel contato)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _contatoRepositorio.AtualizarContato(contato);
                    TempData["MensagemSucesso"] = "Contato atualizado com sucesso!";
                    return RedirectToAction("Index");
                }

                return View("Editar", contato);

            }
            catch (System.Exception erro)
            {
                TempData["MensagemErro"] = $"Falha ao atualizar contato: {erro.Message}";
                return RedirectToAction("Index");

            }
        }

        public IActionResult ApagarContato(int id)
        {
            try
            {
                _contatoRepositorio.ApagarContato(id);
                TempData["MensagemSucesso"] = "Contato apagado com sucesso!";
                return RedirectToAction("Index");
            }
            catch (System.Exception erro)
            {

                TempData["MensagemErro"] = $"Falha ao atualizar contato: {erro.Message}";
                return RedirectToAction("Index");
            }
        }
    }
}
