namespace EasyMenu.Core.Dtos;

public class ErrorResponse
{
    public string Message { get; }
    public object Params { get; set; }

    public ErrorResponse(string message, object @params = null)
    {
        Message = message;
        Params = @params;
    }
}