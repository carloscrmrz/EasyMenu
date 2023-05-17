using EasyMenu.Core.Model.Domains;

namespace EasyMenu.Portal.Services.Interfaces;

public interface IUserService
{
    public Task<bool> NewSession(User user);
}