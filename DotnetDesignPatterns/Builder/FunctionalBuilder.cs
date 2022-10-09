namespace DotnetDesignPatterns.Builder;

public class FunctionalBuilder
{
    static void Main(string[] args)
    {
        var b = new PersonBuilder();
        var p = b.Called("Madiyar").WorksAsA(".NET developer").Build();
    }
}

public class Person
{
    public string Name, Position;
}

public abstract class FunctionalBuilder<TSubject, TSelf> where TSelf : FunctionalBuilder<TSubject, TSelf> where TSubject : new()
{
    private readonly List<Func<TSubject, TSubject>> _actions = new();

    public TSelf Do(Action<TSubject> action) => AddAction(action);

    private TSelf AddAction(Action<TSubject> action)
    {
        _actions.Add(p =>
        {
            action(p);
            return p;
        });
        return (TSelf) this;
    }

    public TSubject Build() => _actions.Aggregate(new TSubject(), (p, f) => f(p));
}

public class PersonBuilder : FunctionalBuilder<Person, PersonBuilder>
{
    public PersonBuilder Called(string name) => Do(p => p.Name = name);
}

public static class PersonBuilderExtensions
{
    public static PersonBuilder WorksAsA(this PersonBuilder builder, string position)
    {
        builder.Do(p => p.Position = position);
        return builder;
    }
}