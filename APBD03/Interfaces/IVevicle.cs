using APBD03.Classes;

namespace APBD03.Interfaces;

public interface IVevicle
{
    public void LoadContainer(Container container);
    public void LoadContainer(List<Container> containers);
    public void RemoveContainer(Container container);
}