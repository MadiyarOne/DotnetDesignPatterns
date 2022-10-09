namespace DotnetDesignPatterns.Factory;

public class FactoryMethod
{
    static void Main(string[] args)
    {
        var cartP = Point.NewCartesianPoint(12, 10);
        var polarP = Point.NewPolarPoint(12, 10);
    }
}

class Point
{
    private double _x, _y;

    public Point(double x, double y)
    {
        this._x = x;
        this._y = y;
    }


    public static Point NewCartesianPoint(double x, double y)
    {
        return new Point(x, y);
    }
    public static Point NewPolarPoint(double rho, double theta)
    {
        return new Point(rho * Math.Cos(theta), theta * Math.Sin(theta));
    }
}