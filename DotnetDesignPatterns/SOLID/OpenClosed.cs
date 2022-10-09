namespace DotnetDesignPatterns.SOLID;

class OpenClosed
{
    static void Main(string[] args)
    {
        Product[] products =
        {
            new Product("Apple", Color.Green, Size.Small),
            new Product("House", Color.Blue, Size.Large)
        };
        
        var pf = new ProductFilter();
        Console.WriteLine("Green products (old)");
        pf.Filter(products, Color.Green).ToList().ForEach(Console.WriteLine);

        var bf = new BetterFilter();
        Console.WriteLine("Large products (new)");
        
        var largeSpec = new SizeSpecification(Size.Large);
        var largeGreenSpec = new AndSpecification<Product>(largeSpec, new ColorSpecification(Color.Green));
        
        bf.Filter(products, largeSpec).ToList().ForEach(Console.WriteLine);
        bf.Filter(products, largeSpec & new ColorSpecification(Color.Blue)).ToList().ForEach(Console.WriteLine);
    }
}

enum Color
{
    Red,
    Green,
    Blue
}

enum Size
{
    Small,
    Medium,
    Large
}

class Product
{
    public string Name { get; init; }
    public Color Color { get; init; }
    public Size Size { get; init; }

    public Product(string name, Color color, Size size)
    {
        Name = name;
        Color = color;
        Size = size;
    }

    public override string ToString()
    {
        return $"{nameof(Name)}: {Name}, {nameof(Color)}: {Color}, {nameof(Size)}: {Size}";
    }
}

class ProductFilter
{
    //if we had 3 states, we would need to have 7 methods

    #region State space explosion

    public IEnumerable<Product> Filter(IEnumerable<Product> products, Color color)
    {
        foreach (var product in products)
        {
            if (product.Color == color)
            {
                yield return product;
            }
        }
    }

    public IEnumerable<Product> Filter(IEnumerable<Product> products, Size size)
    {
        foreach (var product in products)
        {
            if (product.Size == size)
            {
                yield return product;
            }
        }
    }

    public IEnumerable<Product> Filter(IEnumerable<Product> products, Color color, Size size)
    {
        foreach (var product in products)
        {
            if (product.Color == color && product.Size == size)
            {
                yield return product;
            }
        }
    }

    #endregion
}

abstract class Specification<T>
{
    public abstract bool IsSatisfied(T item);

    public static Specification<T> operator &(Specification<T> first, Specification<T> second)
    {
        return new AndSpecification<T>(first, second);
    }
}

interface IFilter<T>
{
    IEnumerable<T> Filter(IEnumerable<T> products, Specification<T> specification);
}

class ColorSpecification : Specification<Product>
{
    private readonly Color _color;

    public ColorSpecification(Color color)
    {
        _color = color;
    }

    public override bool IsSatisfied(Product item)
    {
        return item.Color == _color;
    }
}

class SizeSpecification : Specification<Product>
{
    private readonly Size _size;

    public SizeSpecification(Size size)
    {
        _size = size;
    }

    public override bool IsSatisfied(Product item)
    {
        return item.Size == _size;
    }
}

//combinator
class AndSpecification<T> : Specification<T>
{
    private readonly Specification<T> _firstSpecification;
    private readonly Specification<T> _secondSpecification;

    public AndSpecification(Specification<T> firstSpecification, Specification<T> secondSpecification)
    {
        _firstSpecification = firstSpecification;
        _secondSpecification = secondSpecification;
    }

    public override bool IsSatisfied(T item) => _firstSpecification.IsSatisfied(item) && _secondSpecification.IsSatisfied(item);
}

class BetterFilter : IFilter<Product>
{
    public IEnumerable<Product> Filter(IEnumerable<Product> products, Specification<Product> specification)
    {
        foreach (var product in products)
        {
            if (specification.IsSatisfied(product))
            {
                yield return product;
            }
        }
    }
    
}