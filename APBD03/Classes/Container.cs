using System.Data;
using APBD03.Exception;
using APBD03.Interfaces;

namespace APBD03.Classes;

public abstract class Container(
    double height,
    double containerMas,
    double depth,
    double maxPayload,
    string type) : IContainer
{
    private static int _nextId;

    private double _cargoMass;
    public string Type { get; } = type;
    public double Height { get; } = height;
    public double ContainerMas { get; } = containerMas;
    public double Depth { get; } = depth;
    public string Number { get; } = IContainer.GenerateNumber(type, _nextId++);

    public double MaxPayload { get; } = maxPayload;

    public double CargoMass
    {
        get => _cargoMass;
        set
        {
            if (value > MaxPayload)
            {
                throw new OverfillException($"Max payload is {MaxPayload}, you tried set {value}");
            }

            _cargoMass = value;
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