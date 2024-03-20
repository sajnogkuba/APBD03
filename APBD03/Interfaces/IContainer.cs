namespace APBD03.Interfaces;

public interface IContainer
{
    public void Deloading();
    public void LoadContainer(double mas);
    public abstract string GenerateNumber();
}