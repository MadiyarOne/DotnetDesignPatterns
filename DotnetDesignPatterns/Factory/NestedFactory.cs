namespace DotnetDesignPatterns.Factory;

public class Factory
{
    static void Main(string[] args)
    {
        var cartP = Point.PointFactory.NewCartesianPoint(12, 10);
        var polarP = Point.PointFactory.NewPolarPoint(12, 10);
        
        //Task.Factory.StartNew()
    }
}

class Point
{
    private double _x, _y;

    private Point(double x, double y)
    {
        this._x = x;
        this._y = y;
    }
    
    public class PointFactory
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
    
    //for members of the factory instances
    public static PointFactory Factory => new PointFactory();
}

