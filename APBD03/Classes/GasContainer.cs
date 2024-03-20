using APBD03.Interfaces;

namespace APBD03.Classes;

public class GasContainer(
    double cargoMas,
    double height,
    double containerMas,
    double depth,
    double maxPayload,
    double pressure) : Container(cargoMas, height, containerMas, depth, maxPayload, "G"), IHazardNotifier
{
    public double Pressure { get; } = pressure;

    public string SendWarningMessage(string message)
    {
        return $"Container number: {Number} - Warning message: {message}";
    }

    public new void Deloading()
    {
        CargoMas *= 0.05;
    }
}