using APBD03.Interfaces;

namespace APBD03.Classes;

public class LiquidContainer(
    double cargoMas,
    double height,
    double containerMas,
    double depth,
    double maxPayload,
    bool dengerousCargo)
    : Container(cargoMas, height, containerMas, depth, maxPayload, "L"), IHazardNotifier
{
    public bool DengerousCargo { get; } = dengerousCargo;


    public string SendWarningMessage(string message)
    {
        return $"Container number: {Number} - Warning message: {message}";
    }

    public new void LoadContainer(double mas)
    {
        if (DengerousCargo)
        {
            if (CargoMass + mas > MaxPayload * 0.5)
            {
                SendWarningMessage("Loaded dangerous cargo to more than 50% of payload.");
            }
        }
        else
        {
            if (CargoMass + mas > MaxPayload * 0.9)
            {
                SendWarningMessage("Loaded liquid to more than 90% of payload.");
            }
        }

        base.LoadContainer(mas);
    }

    public override string ToString()
    {
        return $"{base.ToString()} Dengerous Cargo: {DengerousCargo}";
    }
}