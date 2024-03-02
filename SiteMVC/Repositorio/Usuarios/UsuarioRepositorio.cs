using SiteMVC.Data;
using SiteMVC.Helper;
using SiteMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SiteMVC.Repositorio.Usuarios
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private readonly BancoContext _bancoContext;
        public UsuarioRepositorio(BancoContext banco)
        {
            _bancoContext = banco;
        }

        
        //Original retorna ContatoModel ao invés de void
        public void Adicionar(UsuarioModel usuario)
        {
             usuario.DataCadastro = DateTime.Now;
             usuario.SetHash();
            _bancoContext.Usuarios.Add(usuario);
            _bancoContext.SaveChanges();

        }

        public void ApagarUsuario(int id)
        {
            var usuario = ListarUsuarioPorID(id);
            _bancoContext.Usuarios.Remove(usuario);
            _bancoContext.SaveChanges();
        }

        public void AtualizarUsuario(UsuarioModel usuario)
        {

            if (usuario == null) { throw new System.ArgumentNullException(string.Empty); }

            var usuarioAlterado = ListarUsuarioPorID(usuario.Id);

            var date = DateTime.Now;

            usuarioAlterado.Nome = usuario.Nome;
            usuarioAlterado.Login = usuario.Login;
            usuarioAlterado.Email = usuario.Email;
            usuarioAlterado.Perfil = usuario.Perfil;
            usuarioAlterado.DataAtualizacao = date;

            _bancoContext.Usuarios.Update(usuarioAlterado);
            _bancoContext.SaveChanges();


        }

        public List<UsuarioModel> Listar()
        {
            return _bancoContext.Usuarios.ToList();
        }

        public UsuarioModel ListarUsuarioPorID(int id)
        {
            var usuario = Listar().FirstOrDefault(x => x.Id == id);

            return usuario;
        }

        public void RedefinirSenha(RedefinirModel model)
        {
            var user = ListarUsuarioPorID(model.Id);

            if (user == null) throw new Exception("Usuário não encontrado!");

            user.Senha = model.NovaSenha.GerarHash();
            user.DataAtualizacao = DateTime.Now;

            _bancoContext.Usuarios.Update(user);
            _bancoContext.SaveChanges();
        }

        public UsuarioModel UsuarioPorLogin(string login)
        {
            var user = Listar().FirstOrDefault(x => x.Login == login);

            return user;
        }

        public UsuarioModel UsuarioPorLoginEmail(string login, string email)
        {
            var user = Listar().FirstOrDefault(x => x.Login == login && x.Email == email);

            return user;
        }
    }
}
