namespace galdino.humanResource.domain.Shared.Base
{
    public class Base<T> where T : new()
    {
        public bool Sucesso { get; set; } = true;
        public string Mensagem { get; set; } = null;
        public long tempoDeProcessamento { get; set; } = 0;
        public T objetoDeRetorno { get; set; } = new T();
    }
}
