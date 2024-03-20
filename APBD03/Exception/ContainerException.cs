namespace APBD03.Exception;

public class ContainerException : SystemException
{
    public ContainerException()
    {
    }
    
    public ContainerException(string message) : base(message)
    {
    }

    public ContainerException(string message, SystemException inner) : base(message, inner)
    {
    }
    
}