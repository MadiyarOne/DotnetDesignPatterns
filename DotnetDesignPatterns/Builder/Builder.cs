using System.Text;

namespace DotnetDesignPatterns.Builder;

public class Builder
{
    static void Main(string[] args)
    {
        var words = new[] {"hello", "world"};
        var builder = new HtmlBuilder("ul");

        foreach (var word in words)
        {
            builder.AddChild("li", word);
        }

        Console.WriteLine(builder.ToString());
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


    public void AddChild(string childName, string childText)
    {
        var e = new HtmlElement(childName, childText);
        root.HtmlElements.Add(e);
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
}
