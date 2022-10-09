using System.Text;

namespace DotnetDesignPatterns.Builder;

public class FluentBuilder
{
    static void Main(string[] args)
    {
        var words = new[] {"hello", "world"};
        var builder = new HtmlBuilder("ul");

        foreach (var word in words)
        {
            builder.AddChild("li", word).AddChild("p", "some info");
        }


        Console.WriteLine(builder);

        HtmlElement element = new HtmlElement().Create("ul").AddChild("p", "lurum ipsum").AddChild("li", "some info");
    }
}

class HtmlElement
{
    public string Name { get; set; }
    public string Text { get; set; }
    public List<HtmlElement> HtmlElements { get; set; } = new List<HtmlElement>();

    private int indentSize = 2;

    public HtmlElement()
    {
        
    }

    public HtmlElement(string name, string text)
    {
        Name = name;
        Text = text;
    }

    public override string ToString()
    {
        return ToStringImpl(0);
    }

    private string ToStringImpl(int indent)
    {
        var sb = new StringBuilder();
        var i = new string(' ', indentSize * indent);
        sb.Append($"{i}<{Name}>\n");
        if (!string.IsNullOrWhiteSpace(Text))
        {
            sb.Append(new string(' ', indentSize * (indent + 1)));
            sb.Append(Text);
            sb.Append("\n");
        }

        foreach (var e in HtmlElements)
            sb.Append(e.ToStringImpl(indent + 1));

        sb.Append($"{i}</{Name}>\n");
        return sb.ToString();
    }

    public HtmlBuilder Create(string name) => new HtmlBuilder(name);
}

class HtmlBuilder
{
    private readonly string rootName;
    protected HtmlElement root = new HtmlElement();


    public HtmlBuilder(string rootName)
    {
        this.rootName = rootName;
        root.Name = rootName;
    }


    public HtmlBuilder AddChild(string childName, string childText)
    {
        var e = new HtmlElement(childName, childText);
        root.HtmlElements.Add(e);
        return this;
    }

    public override string ToString()
    {
        return root.ToString();
    }

    public void Clear()
    {
        root = new HtmlElement {Name = rootName};
    }

    public HtmlElement Build() => root;

    public static implicit operator HtmlElement (HtmlBuilder builder)
    {
        return builder.Build();
    }
}