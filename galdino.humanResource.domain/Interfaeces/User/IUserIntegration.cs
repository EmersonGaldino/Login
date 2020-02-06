using galdino.humanResource.domain.Entity.Authentication;
using galdino.humanResource.domain.Shared.Base;
using System.Threading.Tasks;

namespace galdino.humanResource.domain.Interfaeces.User
{
    public interface IUserIntegration
    {
        Task<Base<UserLogin>> GetById(int usuarioId);
        Task<Base<UserToken>> LoginAsync(UserLogin empresaUsuario);
    }
}
