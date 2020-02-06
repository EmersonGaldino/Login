using System;

namespace galdino.humanResource.Front.Models.Token
{
    public class TokenModelView
    {
        public string UserId { get; set; }
        public string Name { get; set; }
        public string Mail { get; set; }
        public bool Authenticate { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime ExpireAt { get; set; }
        public string Token { get; set; }
    }
}
