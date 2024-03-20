using System.Data;
using APBD03.Exception;
using APBD03.Interfaces;

namespace APBD03.Classes;

public abstract class Container(
    double cargoMas,
    double height,
    double containerMas,
    double depth,
    double maxPayload,
    string type) : IContainer
{
    private static int _nextId;
    private const string NumberStart = "KON";

    private double _cargoMass;
    public string Type { get; }
    public double Height { get; }
    public double ContainerMas { get; }
    public double Depth { get; }
    public string Number { get; }

    public double MaxPayload { get; }

    public double CargoMass
    {
        get => _cargoMass;
        set
        {
            if (value > MaxPayload)
            {
                throw new OverfillException();
            }
            else
            {
                _cargoMass = value;
            }
        }
    }


    public void Deloading()
    {
        CargoMass = 0;
    }

    public void LoadContainer(double mas)
    {
        CargoMass += mas;
    }

    public string GenerateNumber()
    {
        return $"{NumberStart}-{Type}-{_nextId++}";
    }

    public static Container FindByNumber(List<Container> containers, string number)
    {
        foreach (var container in containers.Where(container => container.Number == number))
        {
            return container;
        }
        throw new ConstraintException($"Container with number {number} not found in given list.");
    }

    public override string ToString()
    {
        return $"[{GetType().Name}] -- Number: {Number}, Cargo mas: {CargoMass}, Height: {Height}, Depth: {Depth}" +
               $", Container mas: {ContainerMas}";
    }
}