using APBD03.Classes;

namespace APBD03.Interfaces;

public interface IContainer
{
    public void Deloading();
    public void LoadContainer(double mas);
    public string GenerateNumber();
    public Container FindByNumber(List<Container> containers, string number);
}