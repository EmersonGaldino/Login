namespace galdino.humanResource.infra.Base.Model
{
    public class BaseViewModel<T> where T : new()
    {
        public bool Success { get; set; } = true;
        public string Message { get; set; } = null;
        public long TimerProcessing { get; set; } = 0;
        public T ObjectReturn { get; set; } = new T();
        public string Version { get; set; }

        public void GerarRetornoErro(T objeto, string message)
        {
            Message = message;
            Success = false;
        }
    }
}
