namespace EasyMenu.Core.Dtos;

public class LoginResult<T> where T : class
{
    public bool Succeeded { get; set; }
    public bool IsLockedOut { get; set; }
    public bool IsTemporaryLockedOut { get; set; }
    public bool IsNotAllowed { get; set; }
    public bool IsDisabled { get; set; }
    public bool TenantIsDisabled { get; set; }
    public bool HasAccess { get; set; } = true;
    public T Data { get; set; }
    public string Param { get; set; }

    public static LoginResult<T> Failed { get; } = new();
    public static LoginResult<T> Disabled { get; } = new() {IsDisabled = true};
    public static LoginResult<T> Success(T data)
    {
        return new LoginResult<T>
        {
            Succeeded = true,
            Data = data
        };
    }
    
    public static LoginResult<T> LockedOut(T data, string param = null)
    {
        return new LoginResult<T>
        {
            Succeeded = false,
            IsLockedOut = true,
            Data = data,
            Param = param
        };
    }
    
    public static LoginResult<T> NotAllowed(T data)
    {
        return new LoginResult<T>
        {
            Succeeded = true,
            IsNotAllowed = true,
            Data = data
        };
    }
    
    public static LoginResult<T> TenantDisabled()
    {
        return new LoginResult<T>
        {
            TenantIsDisabled = true,
            HasAccess = false
        };
    }
}