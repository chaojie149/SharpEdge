namespace Core.Service.Base;

public class ServiceOperator
{
    private static readonly string AnonymousUser = "Anonymous User";
    private string _userName;

    public string UserName
    {
        get
        {
            if (_userName == null) return AnonymousUser;

            return _userName;
        }
        set => _userName = value;
    }
}