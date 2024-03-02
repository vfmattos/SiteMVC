using Microsoft.AspNetCore.Mvc;
using SiteMVC.Filters;
using SiteMVC.Helper;
using SiteMVC.Models;
using SiteMVC.Repositorio.Usuarios;
using System;

namespace SiteMVC.Controllers
{
    [LogadoFilter]
    public class RedefinirController : Controller
    {

        private readonly IUsuarioRepositorio _usuarioRepositorio;
        private readonly ISessao _sessao;

        public RedefinirController(IUsuarioRepositorio usuarioRepositorio, ISessao sessao)
        {
            _usuarioRepositorio = usuarioRepositorio;
            _sessao = sessao;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AtualizarSenha(RedefinirModel redefinirSenha)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    UsuarioModel usuario = _sessao.BuscarSessao();

                    redefinirSenha.Id = usuario.Id;

                    if (!usuario.SenhaValida(redefinirSenha.SenhaAtual)) throw new Exception("Senha atual não confere!");
                    if (usuario.Senha == redefinirSenha.NovaSenha.GerarHash()) throw new Exception("A senha nova não pode ser igual a senha atual!");

                    _usuarioRepositorio.RedefinirSenha(redefinirSenha);

                    TempData["MensagemSucesso"] = "Senha atualizada com sucesso";

                    return View("Index");


                }

                return View("Index", redefinirSenha);
            }
            catch (System.Exception e)
            {
                TempData["MensagemErro"] = "Erro ao tentar redefinir a senha!: " + e.Message;
                return View("Index", redefinirSenha);
            }
        }
    }
}
