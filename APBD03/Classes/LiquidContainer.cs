namespace APBD03.Classes;

public class LiquidContainer : Container
{
    public LiquidContainer(double cargoMas, double height, double containerMas, double depth, double maxPayload)
        : base(cargoMas, height, containerMas, depth, maxPayload)
    {
        Type = "L";
    }
}