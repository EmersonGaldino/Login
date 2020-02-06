using System.ComponentModel.DataAnnotations;

namespace galdino.humanResource.Web_cli.Models.ModelView
{
    public class UserViewModel
    {
        [Required(ErrorMessage = "Insira seu email para logar!")]
        [DataType(DataType.Text)]
        public string Usuario { get; set; }
        [Required(ErrorMessage = "Digite sua senha!")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
      
    }
}
