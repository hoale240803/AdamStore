using System.Collections.Generic;
using System.Threading.Tasks;
using ViewModels.System.Roles;

namespace Application.System.Roles
{
    public interface IRoleService
    {
        Task<List<RoleVm>> GetAll();
    }
}