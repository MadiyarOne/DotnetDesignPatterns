namespace DotnetDesignPatterns.Factory;

public class Factory
{
    static void Main(string[] args)
    {
        var cartP = PointFactory.NewCartesianPoint(12, 10);
        var polarP = PointFactory.NewPolarPoint(12, 10);
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
}

class PointFactory
{
    public static Point NewCartesianPoint(double x, double y)
    {
        return new Point(x, y);
    }
    public static Point NewPolarPoint(double rho, double theta)
    {
        return new Point(rho * Math.Cos(theta), theta * Math.Sin(theta));
    }
}