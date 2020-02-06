namespace galdino.humanResource.Front.Configurations.Token
{
    public class TokenConfiguration
    {
        public string Audience { get; set; }
        public string Issuer { get; set; }
        public int ExpireIn { get; set; }
        public string SigningKey { get; set; }
    }
}
