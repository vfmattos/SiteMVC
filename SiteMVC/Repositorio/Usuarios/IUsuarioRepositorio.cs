using SiteMVC.Models;
using System.Collections.Generic;

namespace SiteMVC.Repositorio.Usuarios
{
    public interface IUsuarioRepositorio
    {

        public UsuarioModel ListarUsuarioPorID(int id);
        public void RedefinirSenha(RedefinirModel model);
        public UsuarioModel UsuarioPorLogin(string login);
        public UsuarioModel UsuarioPorLoginEmail(string login, string email);
        public void AtualizarUsuario(UsuarioModel usuario);
        public void ApagarUsuario(int id);
        public List<UsuarioModel> Listar();
        public void Adicionar(UsuarioModel usuario);

    }
}
