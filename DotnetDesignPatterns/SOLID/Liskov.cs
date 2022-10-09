namespace DotnetDesignPatterns.SOLID;

public class Liskov
{
    static void Main(string[] args)
    {
        var rc = new Rectangle(2, 3);
        UseIt(rc);

        var sq = new Square(2);
        UseIt(sq);
    }

    static void UseIt(Rectangle r)
    {
        int width = r.Width;
        r.Height = 10;
        Console.WriteLine(r);
    }
}

class Rectangle
{
    public virtual int Width { get; set; }
    public virtual int Height { get; set; }

    public Rectangle(int width, int height)
    {
        Width = width;
        Height = height;
    }

    public Rectangle()
    {
        
    }

    public int Area => Width * Height;

    public override string ToString()
    {
        return $"{nameof(Width)}: {Width}, {nameof(Height)}: {Height}, {nameof(Area)}: {Area}";
    }
}

class Square : Rectangle
{
    public Square(int side)
    {
        Width = Height = side;
    }

    public override int Height
    {
        set => base.Height = base.Width = value;
    }

    public override int Width
    {
        set => base.Width = base.Height = value;
    }
}