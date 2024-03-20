using APBD03.Classes;

namespace APBD03.Interfaces;

public interface IVehicle
{
    public void LoadContainer(Container container);
    public void LoadContainer(List<Container> containers);
    public void RemoveContainer(Container container);
    public void ReplaceContainer(string number, Container container);
    public void TransferContainer(IVehicle baseVehicle, IVehicle newVehicle, Container container);
}