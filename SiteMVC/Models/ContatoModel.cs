using System.ComponentModel.DataAnnotations;

namespace SiteMVC.Models
{
    public class ContatoModel
    {

        public int Id { get; set; }
        [Required(ErrorMessage ="Campo obrigatório!")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Campo obrigatório!")]
        [EmailAddress(ErrorMessage ="Insira um email válido!")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Campo obrigatório!")]
        [Phone(ErrorMessage ="Insira um número válido!")]
        public string Celular { get; set; }

    }
}
