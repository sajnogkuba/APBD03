namespace APBD03.Classes;

public class CoolantContainer : Container
{
    public CoolantContainer(double cargoMas, double height, double containerMas, double depth, double maxPayload) 
        : base(cargoMas, height, containerMas, depth, maxPayload)
    {
        Type = "C";
    }
}