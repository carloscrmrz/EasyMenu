using EasyMenu.Core.Model.Domains;

namespace EasyMenu.Core.Dtos;

public class UserDto
{
    public int UserId { get; set; }
    public string UserLogin { get; set; }
    public int TenantId { get; set; }
    public Tenant Tenant { get; set; }
}