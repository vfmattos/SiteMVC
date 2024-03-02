using System.ComponentModel.DataAnnotations;

namespace SiteMVC.Models
{

    public class RedefinirModel
    {

        public int Id { get; set; }
        [Required(ErrorMessage = "Campo obrigatório!")]
        public string SenhaAtual { get; set; }
        [Required(ErrorMessage = "Campo obrigatório!")]
        public string NovaSenha { get; set; }
        [Required(ErrorMessage = "Campo obrigatório!")]
        [Compare("NovaSenha", ErrorMessage = "A senha digitada deve ser igual a nova senha!")]
        public string ConfirmarSenha { get; set; }

    }
}
