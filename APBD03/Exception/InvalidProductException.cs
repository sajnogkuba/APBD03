namespace APBD03.Exception;

public class InvalidProductException : SystemException
{
    public InvalidProductException()
    {
    }

    public InvalidProductException(string message) : base(message)
    {
    }

    public InvalidProductException(string message, SystemException inner) : base(message, inner)
    {
    }
}