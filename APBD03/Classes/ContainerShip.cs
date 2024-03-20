using APBD03.Exception;
using APBD03.Interfaces;

namespace APBD03.Classes;

public class ContainerShip(double maximumSpeed, int maxNumberOfContainers, double maxContainersWeight) : IVevicle
{
    public List<Container> Containers { get; } = new();
    public double MaximumSpeed { get; } = maximumSpeed;
    public int MaxNumberOfContainers { get; } = maxNumberOfContainers;
    public double MaxContainersWeight { get; } = maxContainersWeight;
    public int CurrentNumberOfContainers { get; set; }
    public double CurrentContainersWeight { get; set; }

    public void LoadContainer(Container container)
    {
        Containers.Add(container);
        CurrentContainersWeight += container.CargoMas;
        if (CurrentNumberOfContainers == MaxNumberOfContainers)
        {
            throw new OverfillException("Maximum number of containers already reached.");
        }
        CurrentNumberOfContainers++;
        if (CurrentContainersWeight + container.CargoMas > MaxContainersWeight)
        {
            throw new OverfillException($"Maximum container weight is {MaxContainersWeight}, you tray to set " +
                                        $"{CurrentContainersWeight + container.CargoMas}");
        }
        CurrentContainersWeight += CurrentContainersWeight + container.CargoMas;
    }
}