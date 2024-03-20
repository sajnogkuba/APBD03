namespace APBD03.Interfaces;

public interface IContainer
{
    public void Deloading();
    public void LoadContainer();
    public abstract string GenerateNumber();
}