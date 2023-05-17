using EasyMenu.Core.Dtos;
using EasyMenu.Core.Model.Domains;
using EasyMenu.Portal.Models;

namespace EasyMenu.Portal.Services.Interfaces;

public interface IAuthService
{
     public Task<LoginResult<User>> Login(Credentials credentials);
     public EasyMenuToken BuildToken(UserDto user, bool needChangePwd = false);
}