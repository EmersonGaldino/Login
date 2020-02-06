using galdino.humanResource.domain.Entity.Authentication;
using galdino.humanResource.domain.Exception.Access;
using galdino.humanResource.domain.Exception.Domain;
using galdino.humanResource.domain.Interfaeces.User;
using galdino.humanResource.domain.Shared.Base;
using galdino.humanResource.infra.Base;
using galdino.humanResource.utils.Requests;
using System;
using System.Net;
using System.Threading.Tasks;

namespace galdino.humanResource.infra.User
{
    public class UserIntegration : IntegrationBase, IUserIntegration
    {
        #region .::Constructor
        public UserIntegration(string urlApi, string versao) : base(urlApi, versao)
        {
        }
        #endregion

        #region .::Methods

        public async Task<Base<UserLogin>> GetById(int usuarioId)
        {
            try
            {
                return await WebRequests.RequestJsonSerialize<Base<UserLogin>>(
                           $"{UrlApi}/Authentication/getUser", new UserLogin { ID_Usuario = Convert.ToString(usuarioId)}, WebRequests.Metodo.POST);
            }            
            catch (RequestException e)
            {
                var stsCode = (HttpStatusCode)e.StatusCode;
                switch (stsCode)
                {
                    case HttpStatusCode.Accepted:
                        break;
                    case HttpStatusCode.AlreadyReported:
                        break;
                    case HttpStatusCode.Ambiguous:
                        break;
                    case HttpStatusCode.BadGateway:
                        break;
                    case HttpStatusCode.BadRequest:
                        break;
                    case HttpStatusCode.Conflict:
                        break;
                    case HttpStatusCode.Continue:
                        break;
                    case HttpStatusCode.Created:
                        break;
                    case HttpStatusCode.EarlyHints:
                        break;
                    case HttpStatusCode.ExpectationFailed:
                        break;
                    case HttpStatusCode.FailedDependency:
                        break;
                    case HttpStatusCode.Forbidden:
                        throw new AccessDeniedDomainException();
                    case HttpStatusCode.Found:
                        break;
                    case HttpStatusCode.GatewayTimeout:
                        break;
                    case HttpStatusCode.Gone:
                        break;
                    case HttpStatusCode.HttpVersionNotSupported:
                        break;
                    case HttpStatusCode.IMUsed:
                        break;
                    case HttpStatusCode.InsufficientStorage:
                        break;
                    case HttpStatusCode.InternalServerError:
                        break;
                    case HttpStatusCode.LengthRequired:
                        break;
                    case HttpStatusCode.Locked:
                        break;
                    case HttpStatusCode.LoopDetected:
                        break;
                    case HttpStatusCode.MethodNotAllowed:
                        break;
                    case HttpStatusCode.MisdirectedRequest:
                        break;
                    case HttpStatusCode.Moved:
                        break;
                    case HttpStatusCode.MultiStatus:
                        break;
                    case HttpStatusCode.NetworkAuthenticationRequired:
                        break;
                    case HttpStatusCode.NoContent:
                        break;
                    case HttpStatusCode.NonAuthoritativeInformation:
                        break;
                    case HttpStatusCode.NotAcceptable:
                        break;
                    case HttpStatusCode.NotExtended:
                        break;
                    case HttpStatusCode.NotFound:
                        break;
                    case HttpStatusCode.NotImplemented:
                        break;
                    case HttpStatusCode.NotModified:
                        break;
                    case HttpStatusCode.OK:
                        break;
                    case HttpStatusCode.PartialContent:
                        break;
                    case HttpStatusCode.PaymentRequired:
                        break;
                    case HttpStatusCode.PermanentRedirect:
                        break;
                    case HttpStatusCode.PreconditionFailed:
                        break;
                    case HttpStatusCode.PreconditionRequired:
                        break;
                    case HttpStatusCode.Processing:
                        break;
                    case HttpStatusCode.ProxyAuthenticationRequired:
                        break;
                    case HttpStatusCode.RedirectKeepVerb:
                        break;
                    case HttpStatusCode.RedirectMethod:
                        break;
                    case HttpStatusCode.RequestedRangeNotSatisfiable:
                        break;
                    case HttpStatusCode.RequestEntityTooLarge:
                        break;
                    case HttpStatusCode.RequestHeaderFieldsTooLarge:
                        break;
                    case HttpStatusCode.RequestTimeout:
                        break;
                    case HttpStatusCode.RequestUriTooLong:
                        break;
                    case HttpStatusCode.ResetContent:
                        break;
                    case HttpStatusCode.ServiceUnavailable:
                        break;
                    case HttpStatusCode.SwitchingProtocols:
                        break;
                    case HttpStatusCode.TooManyRequests:
                        break;
                    case HttpStatusCode.Unauthorized:
                        throw new AccessDeniedDomainException();
                    case HttpStatusCode.UnavailableForLegalReasons:
                        break;
                    case HttpStatusCode.UnprocessableEntity:
                        break;
                    case HttpStatusCode.UnsupportedMediaType:
                        break;
                    case HttpStatusCode.Unused:
                        break;
                    case HttpStatusCode.UpgradeRequired:
                        break;
                    case HttpStatusCode.UseProxy:
                        break;
                    case HttpStatusCode.VariantAlsoNegotiates:
                        break;
                }
                throw new DomainException("Erro na requsição");
            }
        }
        public async Task<Base<UserToken>> LoginAsync(UserLogin user)
        {
            try
            {
                return await WebRequests.RequestJsonSerialize<Base<UserToken>>(
                    $"{UrlApi}/Authentication/SigIn", new
                    {
                        Login = user.Login,
                        Password = user.Password,


                    }, WebRequests.Metodo.POST);
            }
            catch (RequestException e)
            {
                var stsCode = (HttpStatusCode)e.StatusCode;
                switch (stsCode)
                {
                    case HttpStatusCode.Accepted:
                        break;
                    case HttpStatusCode.AlreadyReported:
                        break;
                    case HttpStatusCode.Ambiguous:
                        break;
                    case HttpStatusCode.BadGateway:
                        break;
                    case HttpStatusCode.BadRequest:
                        break;
                    case HttpStatusCode.Conflict:
                        break;
                    case HttpStatusCode.Continue:
                        break;
                    case HttpStatusCode.Created:
                        break;
                    case HttpStatusCode.EarlyHints:
                        break;
                    case HttpStatusCode.ExpectationFailed:
                        break;
                    case HttpStatusCode.FailedDependency:
                        break;
                    case HttpStatusCode.Forbidden:
                        throw new AccessDeniedDomainException();
                    case HttpStatusCode.Found:
                        break;
                    case HttpStatusCode.GatewayTimeout:
                        break;
                    case HttpStatusCode.Gone:
                        break;
                    case HttpStatusCode.HttpVersionNotSupported:
                        break;
                    case HttpStatusCode.IMUsed:
                        break;
                    case HttpStatusCode.InsufficientStorage:
                        break;
                    case HttpStatusCode.InternalServerError:
                        break;
                    case HttpStatusCode.LengthRequired:
                        break;
                    case HttpStatusCode.Locked:
                        break;
                    case HttpStatusCode.LoopDetected:
                        break;
                    case HttpStatusCode.MethodNotAllowed:
                        break;
                    case HttpStatusCode.MisdirectedRequest:
                        break;
                    case HttpStatusCode.Moved:
                        break;
                    case HttpStatusCode.MultiStatus:
                        break;
                    case HttpStatusCode.NetworkAuthenticationRequired:
                        break;
                    case HttpStatusCode.NoContent:
                        break;
                    case HttpStatusCode.NonAuthoritativeInformation:
                        break;
                    case HttpStatusCode.NotAcceptable:
                        break;
                    case HttpStatusCode.NotExtended:
                        break;
                    case HttpStatusCode.NotFound:
                        break;
                    case HttpStatusCode.NotImplemented:
                        break;
                    case HttpStatusCode.NotModified:
                        break;
                    case HttpStatusCode.OK:
                        break;
                    case HttpStatusCode.PartialContent:
                        break;
                    case HttpStatusCode.PaymentRequired:
                        break;
                    case HttpStatusCode.PermanentRedirect:
                        break;
                    case HttpStatusCode.PreconditionFailed:
                        break;
                    case HttpStatusCode.PreconditionRequired:
                        break;
                    case HttpStatusCode.Processing:
                        break;
                    case HttpStatusCode.ProxyAuthenticationRequired:
                        break;
                    case HttpStatusCode.RedirectKeepVerb:
                        break;
                    case HttpStatusCode.RedirectMethod:
                        break;
                    case HttpStatusCode.RequestedRangeNotSatisfiable:
                        break;
                    case HttpStatusCode.RequestEntityTooLarge:
                        break;
                    case HttpStatusCode.RequestHeaderFieldsTooLarge:
                        break;
                    case HttpStatusCode.RequestTimeout:
                        break;
                    case HttpStatusCode.RequestUriTooLong:
                        break;
                    case HttpStatusCode.ResetContent:
                        break;
                    case HttpStatusCode.ServiceUnavailable:
                        break;
                    case HttpStatusCode.SwitchingProtocols:
                        break;
                    case HttpStatusCode.TooManyRequests:
                        break;
                    case HttpStatusCode.Unauthorized:
                        throw new AccessDeniedDomainException();
                    case HttpStatusCode.UnavailableForLegalReasons:
                        break;
                    case HttpStatusCode.UnprocessableEntity:
                        break;
                    case HttpStatusCode.UnsupportedMediaType:
                        break;
                    case HttpStatusCode.Unused:
                        break;
                    case HttpStatusCode.UpgradeRequired:
                        break;
                    case HttpStatusCode.UseProxy:
                        break;
                    case HttpStatusCode.VariantAlsoNegotiates:
                        break;
                }
                throw new DomainException("Erro na requsição");
            }

        }

     
        #endregion
    }
}
