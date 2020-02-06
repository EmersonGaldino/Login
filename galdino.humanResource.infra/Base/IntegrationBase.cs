namespace galdino.humanResource.infra.Base
{
    public class IntegrationBase
    {
        protected readonly string UrlApi;
        protected readonly string Versao;

        protected IntegrationBase(string urlApi, string versao)
        {
            UrlApi = urlApi;
            Versao = versao;
        }
    }
}
