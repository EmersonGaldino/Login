using System.ComponentModel.DataAnnotations;

namespace galdino.humanResource.Web_cli.Models.ModelView
{
    public class UserModelView
    {
        [Display(Name = "Login")]
        [Required(ErrorMessage = "Login inválido")]
        public string Usuario { get; set; }
        [Display(Name = "Senha")]
        [Required(ErrorMessage = "Senha inválida")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
