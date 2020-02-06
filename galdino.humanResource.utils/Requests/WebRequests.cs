using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace galdino.humanResource.utils.Requests
{
    public class WebRequests
    {
        #region .::Enuns
        public enum Metodo
        {
            GET, POST, PUT,
            DELETE
        }
        #endregion

        #region .::Mehtods

        public static async Task<T> RequestJsonSerialize<T>(string url, object jsonData, Metodo metodo, string token = null) where T : class
        {
            HttpResponseMessage retorno = null;
            using (var api = new HttpClient())
            {
                if (!string.IsNullOrEmpty(token)) api.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                switch (metodo)
                {
                    case Metodo.GET:
                        retorno = await api.GetAsync(url);
                        break;
                    case Metodo.POST:
                        retorno = await api.PostAsync(url,
                            new StringContent(JsonConvert.SerializeObject(jsonData), Encoding.UTF8,
                                "application/json"));
                        break;
                    case Metodo.PUT:
                        retorno = await api.PutAsync(url,
                            new StringContent(JsonConvert.SerializeObject(jsonData), Encoding.UTF8,
                                "application/json"));
                        break;
                    case Metodo.DELETE:
                        retorno = await api.DeleteAsync(url);
                        break;
                    default:
                        throw new ArgumentOutOfRangeException(nameof(metodo), metodo, null);
                }
            }
            var retornoStr = await retorno.Content.ReadAsStringAsync();
            if (!string.IsNullOrEmpty(retornoStr))
                try
                {
                    return JsonConvert.DeserializeObject<T>(retornoStr);
                }
                catch
                {
                    throw new RequestException((int)retorno.StatusCode);
                }

            throw new RequestException((int)retorno.StatusCode);

        } 

        #endregion
    }
}
