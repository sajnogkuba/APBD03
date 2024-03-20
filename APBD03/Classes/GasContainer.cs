namespace APBD03.Classes;

public class GasContainer : Container
{
    public GasContainer(double cargoMas, double height, double containerMas, double depth, double maxPayload)
        : base(cargoMas, height, containerMas, depth, maxPayload)
    {
        Type = "G";
    }
}