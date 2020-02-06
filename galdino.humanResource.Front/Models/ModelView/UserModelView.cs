using System.ComponentModel.DataAnnotations;

namespace galdino.humanResource.Front.Models.ModelView
{
    public class UserModelView
    {
      
        [Display(Name = "Login")]
        [Required(ErrorMessage = "Login inválido")]
        public string Usuario { get; set; }
        [Display(Name = "Senha")]
        [Required(ErrorMessage = "Senha inválida")]
        [DataType(DataType.Password)]
        public string Senha { get; set; }

        
    }
}
