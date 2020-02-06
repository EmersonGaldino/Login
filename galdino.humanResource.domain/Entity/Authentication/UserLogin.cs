using System;

namespace galdino.humanResource.domain.Entity.Authentication
{
    public class UserLogin
    {
        public UserLogin()
        {

        }
        public string ID_Usuario { get; set; }
        public string ID_Empresa { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public DateTime D_Inicio { get; set; }
        public DateTime? D_Inativado { get; set; }
        public string I_Situacao { get; set; }
        public string STR_Motivo_Inativado { get; set; }
    }
}
