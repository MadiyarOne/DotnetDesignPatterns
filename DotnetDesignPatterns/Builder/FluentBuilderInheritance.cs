namespace DotnetDesignPatterns.Builder;


//recursive generics
public class FluentBuilderInheritance
{
    static void Main(string[] args)
    {
        Person person = Person.New.Called("Madiyar").WorksAs(".NET developer").Build();

    }
}

class Person
{
    public string Name { get; set; }
    public string Position { get; set; }

    public class Builder : PersonJobBuilder<Builder>
    {
        internal Builder()
        {
            
        }
    }

    public static Builder New => new Builder();
}




class PersonBuilder
{
    protected Person _person => new Person();

    public Person Build()
    {
        return _person;
    }
}

class PersonInfoBuilder<SELF> : PersonBuilder where SELF : PersonInfoBuilder<SELF>
{
    public SELF Called(string name)
    {
        _person.Name = name;
        return (SELF)this;
    }
}

class PersonJobBuilder<SELF> : PersonInfoBuilder<SELF> where SELF : PersonJobBuilder<SELF>
{
    public SELF WorksAs(string position)
    {
        _person.Position = position;
        return (SELF) this;
    }
}