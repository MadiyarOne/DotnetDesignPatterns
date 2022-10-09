using System.Text;

namespace DotnetDesignPatterns.Builder;

public class StringBuilderExample
{
    static void Main(string[] args)
    {
        var hello = "Hello";
        var text = $"<p>{hello}</p>";

        text = "<p>"; // <p> -> text
        text += hello; // <p>hello -> text
        text += "</p>";

        Console.WriteLine(text);

        //StringBuilder
        var words = new[] {"hello", "world"};

        var sb = new StringBuilder();
        sb.Append("<ul>");
        foreach (var word in words)
        {
            sb.AppendFormat("<li>{0}</li>", word);
        }

        sb.Append("</ul>");
        Console.WriteLine(sb);
    }
}