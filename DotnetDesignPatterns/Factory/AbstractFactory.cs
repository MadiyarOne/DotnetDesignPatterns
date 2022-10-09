using System.Transactions;

namespace DotnetDesignPatterns.Factory;

public class AbstractFactory
{
    static void Main(string[] args)
    {
        var basicFactory = GetFactory(false);
        var basicCircle = basicFactory.Create(Shape.Circle);

        var roundedFactory = GetFactory(true);
        var roundedSquare = roundedFactory.Create(Shape.Square);
    }

    public static ShapeFactory GetFactory(bool rounded) => rounded ? new RoundedShapeFactory() : new BasicShapeFactory();
}

public enum Shape
{
    Circle,
    Square
}

class BasicShapeFactory : ShapeFactory
{


    public override IShape Create(Shape shape) =>
        shape switch
        {
            Shape.Circle => new RoundedCircle(),
            Shape.Square => new RoundedSquare(),
            _ => throw new ArgumentOutOfRangeException(nameof(shape), shape, null)
        };
}


class RoundedShapeFactory : ShapeFactory
{


    public override IShape Create(Shape shape) =>
        shape switch
        {
            Shape.Circle => new Circle(),
            Shape.Square => new Square(),
            _ => throw new ArgumentOutOfRangeException(nameof(shape), shape, null)
        };
}

public interface IShape
{
    void Draw();
}

class Square : IShape
{
    public void Draw()
    {
        Console.WriteLine("basic square");
    }
}

class Circle : IShape
{
    public void Draw()
    {
        Console.WriteLine("basic circle");
    }
}

class RoundedSquare : IShape
{
    public void Draw()
    {
        Console.WriteLine("Rounded square");
    }
}

class RoundedCircle : IShape
{
    public void Draw()
    {
        Console.WriteLine("Rounded circle");
    }
}

public abstract class ShapeFactory
{
    public abstract IShape Create(Shape shape);
}