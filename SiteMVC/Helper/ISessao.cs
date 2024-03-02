using SiteMVC.Models;

namespace SiteMVC.Helper
{
    public interface ISessao
    {

        public void CriarSessao(UsuarioModel usuario);
        public UsuarioModel BuscarSessao();
        public void RemoverSessao();

    }
}
