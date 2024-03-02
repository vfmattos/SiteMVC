using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SiteMVC.Helper;
using SiteMVC.Models;
using SiteMVC.Repositorio.Usuarios;
using System;
using System.Drawing;
using System.Threading.Tasks;

namespace SiteMVC.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;
        private readonly ISessao _sessao;
        private readonly IEmailServico _emailService;

        public LoginController(IUsuarioRepositorio usuarioRepositorio, ISessao sessao, IEmailServico emailService)
        {
            _usuarioRepositorio = usuarioRepositorio;
            _sessao = sessao;
            _emailService = emailService;
        }
        public IActionResult Index()
        {

            if (_sessao.BuscarSessao() != null) return RedirectToAction("Index", "Home");

            return View();
        }

        [HttpPost]
        public IActionResult Entrar(LoginModel loginModel)
        {

            try
            {

                if (ModelState.IsValid)
                {
                    var user = _usuarioRepositorio.UsuarioPorLogin(loginModel.Login);

                    if (user != null)
                    {
                        if (user.SenhaValida(loginModel.Senha))
                        {

                            _sessao.CriarSessao(user);
                            return RedirectToAction("Index", "Home");
                        }

                        TempData["MensagemErro"] = $"Senha inválida";

                    }
                    else
                    {
                        TempData["MensagemErro"] = $"Login ou senha inválido(s)";
                    }

                }

                return View("Index");
            }
            catch (Exception erro)
            {

                TempData["MensagemErro"] = $"Falha ao logar: {erro.Message}";
                return View("Index");
            }

        }

        public IActionResult Sair()
        {
            _sessao.RemoverSessao();

            return RedirectToAction("Index", "Login");
        }

        public IActionResult RedefinirSenha()
        {
            return View();
        }

        [HttpPost]

        public async Task<IActionResult> RedefinirSenha(RedefinirSenhaUsuario redefinirSenhaUsuario)
        {

            try
            {

                if (ModelState.IsValid)
                {
                    var user = _usuarioRepositorio.UsuarioPorLoginEmail(redefinirSenhaUsuario.Login, redefinirSenhaUsuario.Email);

                    if (user != null)
                    {
                        string novaSenha = user.GerarSenha();


                        string mensagem = "Sua nova senha é: " + novaSenha;


                        await _emailService.SendEmailAsync(redefinirSenhaUsuario.Email, "Sistema de contatos", mensagem);
                        _usuarioRepositorio.AtualizarUsuario(user);
                        TempData["MensagemSucesso"] = "A nova senha foi enviada para o seu email cadastrado!";

                        return RedirectToAction("Index", "Login");

                    }
                    else
                    {
                        TempData["MensagemErro"] = "Login ou email inválidos! Tente novamente";
                        return View();
                    }

                }

                return View();
            }
            catch (Exception erro)
            {

                TempData["MensagemErro"] = $"Falha ao Redefinir a senha: {erro.Message}";
                return View("Index");
            }

        }

    }
}
