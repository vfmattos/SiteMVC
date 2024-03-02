using SiteMVC.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace SiteMVC.Models
{
    public class UsuarioEditado
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
        public DateTime? DataAtualizacao { get; set; }


    }
}
