using APBD03.Exception;
using APBD03.Interfaces;

namespace APBD03.Classes;

public class ContainerShip(string name, double maximumSpeed, int maxNumberOfContainers, double maxContainersWeight) : IVehicle
{
    public string Name { get; } = name;
    public List<Container> Containers { get; } = new();
    public double MaximumSpeed { get; } = maximumSpeed;
    public int MaxNumberOfContainers { get; } = maxNumberOfContainers;
    public double MaxContainersWeight { get; } = maxContainersWeight;
    public int CurrentNumberOfContainers { get; set; }
    public double CurrentContainersWeight { get; set; }

    public void LoadContainer(Container container)
    {
        
        if (CurrentNumberOfContainers == MaxNumberOfContainers)
        {
            throw new OverfillException("Maximum number of containers already reached.");
        }
        Containers.Add(container);
        CurrentNumberOfContainers++;
        if (CurrentContainersWeight + container.CargoMass > MaxContainersWeight)
        {
            throw new OverfillException($"Maximum container weight is {MaxContainersWeight}, you tray to set " +
                                        $"{CurrentContainersWeight + container.CargoMass}");
        }
        CurrentContainersWeight += container.CargoMass;
    }

    public void LoadContainer(List<Container> containers)
    {
        foreach (var container in containers)
        {
            LoadContainer(container);
        }
    }

    public void RemoveContainer(Container container)
    {
        Containers.Remove(container);
        CurrentNumberOfContainers--;
        CurrentContainersWeight -= container.CargoMass;
    }

    public void ReplaceContainer(string number, Container container)
    {
        RemoveContainer(Container.FindByNumber(Containers, number));
        LoadContainer(container);
    }

    public void TransferContainer(IVehicle baseVehicle, IVehicle newVehicle, Container container)
    {
        baseVehicle.RemoveContainer(container);
        newVehicle.LoadContainer(container);
    }

    public string ShipAndItsContainers()
    {
        var result = this + " Contains";
        return Containers.Aggregate(result, (current, container) => current + $"\n - {container}");
    }
    
    public override string ToString()
    {
        return $"{Name} (maximumSpeed = {MaximumSpeed}, maxNumberOfContainers = {MaxNumberOfContainers}," +
               $" maxWeight = {MaxContainersWeight})";
    }
}