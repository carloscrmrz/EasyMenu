using EasyMenu.Core.Dtos;
using EasyMenu.Core.Model.Domains;

namespace EasyMenu.Portal.Models.Maps;

public static class UserMap
{
    public static UserDto Map(this User user)
    {
        return new UserDto()
        {
            UserId = user.UserId,
            UserLogin = user.UserLogin,
            TenantId = user.TenantId,
            Tenant = user.Tenant
        };
    }
}