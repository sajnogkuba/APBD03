using APBD03.Interfaces;

namespace APBD03.Classes;

public abstract class Container : IContainer
{
    public double CargoMas { get; }
    public double Height { get; }
    public double ContainerMas { get; }
    public double Depth { get; }

    public void Deloading()
    {
        throw new NotImplementedException();
    }

    public void LoadContainer()
    {
        throw new NotImplementedException();
    }

    public abstract string GenerateNumber();
}