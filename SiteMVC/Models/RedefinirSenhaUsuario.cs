using System.ComponentModel.DataAnnotations;

namespace SiteMVC.Models
{
    public class RedefinirSenhaUsuario
    {
        [Required(ErrorMessage ="Campo Obrigatório!")]
        public string Login { get; set; }
        [Required(ErrorMessage = "Campo Obrigatório!")]
        public string Email { get; set; }

    }
}
