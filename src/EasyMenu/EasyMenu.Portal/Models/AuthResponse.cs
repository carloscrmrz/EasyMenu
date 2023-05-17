using EasyMenu.Core.Dtos;

namespace EasyMenu.Portal.Models;

public class AuthResponse
{
    public UserDto User { get; set; }
    public string Token { get; set; }
}