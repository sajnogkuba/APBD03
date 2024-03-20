using APBD03.Exception;

namespace APBD03.Classes;

public class CoolantContainer(
    double cargoMas,
    double height,
    double containerMas,
    double depth,
    double maxPayload,
    Product product,
    double temperature) : Container(cargoMas, height, containerMas, depth, maxPayload, "C")
{
    public Product Product { get; } = product;
    public double Temperature { get; } = temperature;

    private static readonly Dictionary<Product, double> MinTemperatures = new()
    {
        { Product.Bananas, 13.3 },
        { Product.Chocolate, 18 },
        { Product.Fish, 2 },
        { Product.Meat, -15 },
        { Product.IceCream, -18 },
        { Product.FrozenPizza, -30 },
        { Product.Cheese, 7.2 },
        { Product.Sausages, 5 },
        { Product.Butter, 20.5 },
        { Product.Eggs, 19 },
    };


    public void LoadContainer(double mas, Product product)
    {
        if (!product.Equals(Product))
        {
            throw new InvalidProductException($"You can not pac {product} to container for {Product}");
        }

        if (Temperature < MinTemperatures[product])
        {
            throw new TooLowTemperatureException($"Minimum temperature for {product} is" +
                                                 $" {MinTemperatures[product]} temperature in this" +
                                                 $" container is {Temperature}");
        }

        base.LoadContainer(mas);
    }

    public override string ToString()
    {
        return $"{base.ToString()} Product: {Product}, Temperature: {Temperature}";
    }

    public new void LoadContainer(double mas)
    {
        throw new InvalidProductException($"You have to specify which product you try to pack.");
    }
}