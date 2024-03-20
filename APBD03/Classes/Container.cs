using APBD03.Exception;
using APBD03.Interfaces;

namespace APBD03.Classes;

public abstract class Container : IContainer
{
    private static int _nextId = 0;

    private double _cargoMas;
    public double Height { get; }
    public double ContainerMas { get; }
    public double Depth { get; }
    public string Number { get; }

    public double MaxPayload { get; }

    public double CargoMas
    {
        get => _cargoMas;
        set
        {
            if (value > MaxPayload)
            {
                throw new OverfillException();
            }
            else
            {
                _cargoMas = value;
            }
            
        }
    }

    public void Deloading()
    {
        CargoMas = 0;
    }

    public void LoadContainer(double mas)
    {
        CargoMas = CargoMas + mas;
    }

    public abstract string GenerateNumber();

    public override string ToString()
    {
        return $"[{GetType().Name}] -- Number: {Number}, Cargo mas: {CargoMas}, Height: {Height}, Depth: {Depth}" +
               $", Container mas: {CargoMas}";
    }
}