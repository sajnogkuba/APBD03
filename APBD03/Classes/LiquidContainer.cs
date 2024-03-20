namespace APBD03.Classes;

using APBD03.Interfaces;

public class LiquidContainer(double cargoMas, double height, double containerMas, double depth, double maxPayload)
    : Container(cargoMas, height, containerMas, depth, maxPayload, "L"), IHazardNotifier
{
    public string SendWarningMessage()
    {
        throw new NotImplementedException();
    }
}