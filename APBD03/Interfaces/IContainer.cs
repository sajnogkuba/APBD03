using APBD03.Classes;

namespace APBD03.Interfaces;

public interface IContainer
{
    private const string NumberStart = "KON";
    public void Deloading();
    public void LoadContainer(double mas);

    public static string GenerateNumber(string type, int num)
    {
        return $"{NumberStart}-{type}-{num}";
    }
}