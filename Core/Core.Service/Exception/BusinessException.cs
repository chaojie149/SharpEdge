namespace Core.Service.Exception;

public class BusinessException:System.Exception
{
    public BusinessException()
    {
    }

    public BusinessException(string? message) : base(message)
    {
    }
}