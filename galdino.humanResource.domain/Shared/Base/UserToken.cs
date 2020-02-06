using System;

namespace galdino.humanResource.domain.Shared.Base
{
    public class UserToken
    {
        public string UsuarioId { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public bool Autenticado { get; set; }
        public DateTime Criacao { get; set; }
        public DateTime Expira { get; set; }
        public string Token { get; set; }
    }
}
