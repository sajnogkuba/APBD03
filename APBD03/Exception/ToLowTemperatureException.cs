namespace APBD03.Exception;

public class TooLowTemperatureException : SystemException
{
    public TooLowTemperatureException()
    {
    }

    public TooLowTemperatureException(string message) : base(message)
    {
    }

    public TooLowTemperatureException(string message, SystemException inner) : base(message, inner)
    {
    }
}