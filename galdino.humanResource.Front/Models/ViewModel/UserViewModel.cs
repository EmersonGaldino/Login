using System.ComponentModel.DataAnnotations;

namespace galdino.humanResource.Front.Models.ViewModel
{
    public class UserViewModel
    {
        [Required(ErrorMessage = "Insira seu email para logar!")]
        [DataType(DataType.Text)]
        public string Usuario { get; set; }
        [Required(ErrorMessage = "Digite sua senha!")]
        [DataType(DataType.Password)]
        public string Senha { get; set; }

        public int EmoresaId { get; set; }
    }
}
