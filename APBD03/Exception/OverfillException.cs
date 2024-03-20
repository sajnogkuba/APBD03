namespace APBD03.Exception;

public class OverfillException : SystemException
{
    public OverfillException()
    {
    }

    public OverfillException(string message) : base(message)
    {
    }

    public OverfillException(string message, SystemException inner) : base(message, inner)
    {
    }
}