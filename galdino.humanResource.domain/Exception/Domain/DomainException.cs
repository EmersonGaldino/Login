namespace galdino.humanResource.domain.Exception.Domain
{
    public class DomainException : System.Exception
    {
        protected string Erro { get; }

        public DomainException(string erro)
        {
            Erro = erro;
        }

        public DomainException()
        {

        }
    }
}
