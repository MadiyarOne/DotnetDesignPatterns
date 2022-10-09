namespace DotnetDesignPatterns.Factory;

public class PointExample
{
    static void Main(string[] args)
    {
        
    }
}

class Point
{
    private double x, y;

    public Point(double x, double y, CoordinateSystem system = CoordinateSystem.Cartesian)
    {
        switch (system)
        {
            case CoordinateSystem.Cartesian:
                this.x = x;
                this.y = y;
                break;
            case CoordinateSystem.Polar:
                x = x * Math.Cos(y);
                y = y * Math.Sin(x);
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(system), system, null);
        }
        
    }


    public enum CoordinateSystem
    {
        Cartesian,
        Polar
    }
}