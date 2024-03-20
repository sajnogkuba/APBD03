using APBD03.Exception;
using APBD03.Interfaces;

namespace APBD03.Classes;

public abstract class Container : IContainer
{
    private static string _numberStart = "KON";
    private static int _nextId;

    private double _cargoMas;
    public string? Type { get; set; }
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

    protected Container(double cargoMas, double height, double containerMas, double depth, double maxPayload)
    {
        _cargoMas = cargoMas;
        Height = height;
        ContainerMas = containerMas;
        Depth = depth;
        MaxPayload = maxPayload;
        Number = GenerateNumber();
    }

    public void Deloading()
    {
        CargoMas = 0;
    }

    public void LoadContainer(double mas)
    {
        CargoMas = CargoMas + mas;
    }

    public string GenerateNumber()
    {
        return $"{_numberStart}-{Type}-{_nextId++}";
    }

    public override string ToString()
    {
        return $"[{GetType().Name}] -- Number: {Number}, Cargo mas: {CargoMas}, Height: {Height}, Depth: {Depth}" +
               $", Container mas: {CargoMas}";
    }
}