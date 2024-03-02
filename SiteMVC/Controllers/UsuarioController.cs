using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using SiteMVC.Filters;
using SiteMVC.Models;
using SiteMVC.Repositorio;
using SiteMVC.Repositorio.Usuarios;
using System;

namespace SiteMVC.Controllers
{
    [AdmFilter]
    public class UsuarioController : Controller
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;
        public UsuarioController(IUsuarioRepositorio usuarioRepositorio)
        {

            _usuarioRepositorio = usuarioRepositorio;

        }
        public IActionResult Index()
        {
            var list = _usuarioRepositorio.Listar();
            return View(list);
        }

        public IActionResult Criar()
        {
            return View();
        }

        public IActionResult Editar(int id)
        {
            var usuarioID = _usuarioRepositorio.ListarUsuarioPorID(id);
            return View(usuarioID);
        }

        public IActionResult Apagar(int id)
        {
            var usuarioID = _usuarioRepositorio.ListarUsuarioPorID(id);
            return View(usuarioID);
        }

        [HttpPost]
        public IActionResult Criar(UsuarioModel usuario)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    _usuarioRepositorio.Adicionar(usuario);
                    TempData["MensagemSucesso"] = "Usuário cadastrado com sucesso!";
                    return RedirectToAction("Index");
                }

                return View("Criar", usuario);
            }
            catch (System.Exception erro)
            {
                TempData["MensagemErro"] = $"Falha ao cadastrar usuário: {erro.Message}";
                return RedirectToAction("Index");
            }

        }

        [HttpPost]
        public IActionResult Editar(UsuarioEditado usuarioEditado)
        {
            
            try
            {
                UsuarioModel usuario = null;

                if (ModelState.IsValid)
                {

                    usuario = new UsuarioModel()
                    {

                        Id = usuarioEditado.Id,
                        Nome = usuarioEditado.Nome,
                        Login = usuarioEditado.Login,
                        Email = usuarioEditado.Email,
                        Perfil = usuarioEditado.Perfil,
                    };

                    _usuarioRepositorio.AtualizarUsuario(usuario);
                    TempData["MensagemSucesso"] = "Usuário atualizado com sucesso!";
                    return RedirectToAction("Index");
                }

                return View("Editar", usuario);

            }
            catch (System.Exception erro)
            {
                TempData["MensagemErro"] = $"Falha ao atualizar usuário: {erro.Message}";
                return RedirectToAction("Index");

            }
        }

        public IActionResult ApagarUsuario(int id)
        {
            try
            {
                _usuarioRepositorio.ApagarUsuario(id);
                TempData["MensagemSucesso"] = "Usuário apagado com sucesso!";
                return RedirectToAction("Index");
            }
            catch (System.Exception erro)
            {

                TempData["MensagemErro"] = $"Falha ao atualizar usuário: {erro.Message}";
                return RedirectToAction("Index");
            }
        }
    }
}
