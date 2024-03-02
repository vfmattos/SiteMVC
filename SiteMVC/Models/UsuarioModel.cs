using SiteMVC.Enums;
using SiteMVC.Helper;
using System;
using System.ComponentModel.DataAnnotations;

namespace SiteMVC.Models
{
    public class UsuarioModel
    {

        public int Id { get; set; }

        [Required(ErrorMessage = "Campo obrigatório!")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Campo obrigatório!")]
        public string Login { get; set; }

        
        [Required(ErrorMessage = "Campo obrigatório!")]
        [EmailAddress(ErrorMessage = "Insira um email válido!")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Campo obrigatório!")]
        public PerfilEnums? Perfil { get; set; }

        [Required(ErrorMessage = "Campo obrigatório!")]
        public string Senha { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime? DataAtualizacao { get; set; }

        public bool SenhaValida(string senha)
        {
            return Senha == senha.GerarHash();
        }

        public void SetHash()
        {
            Senha = Senha.GerarHash();
        }

        public string GerarSenha()
        {
            var novaSenha = Guid.NewGuid().ToString().Substring(0, 8);

            Senha = novaSenha.GerarHash();

            return novaSenha;
        }

    }
}
