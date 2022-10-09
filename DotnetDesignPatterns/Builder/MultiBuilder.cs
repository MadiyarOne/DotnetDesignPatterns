namespace DotnetDesignPatterns.Builder;

public class MultiBuilder
{
    static void Main(string[] args)
    {
        var pb = new PersonBuilder();
        Person person = pb
            .Lives()
                .At("12 Republic street ")
                .In("Astana")
                .WithPostCode("05B1111")
            .Works()
                .As(".NET developer")
                .At("Microsoft")
                .Earns(100);

        Console.WriteLine(person);
        
    }
}

class Person
{
    public string StreetAddress, Postcode, City;

    public string CompanyName, Position;
    public int AnnualIncome;

    public override string ToString()
    {
        return $"{nameof(StreetAddress)}: {StreetAddress}, {nameof(Postcode)}: {Postcode}, {nameof(City)}: {City}, {nameof(CompanyName)}: {CompanyName}, {nameof(Position)}: {Position}, {nameof(AnnualIncome)}: {AnnualIncome}";
    }
}

class PersonBuilder
{
    protected Person _person;

    public PersonBuilder(Person person)
    {
        _person = person;
    }

    public PersonBuilder()
    {
        _person = new Person();
    }

    public PersonAddressBuilder Lives() => new PersonAddressBuilder(_person);
    public PersonJobBuilder Works() => new PersonJobBuilder(_person);
    

    public static implicit operator Person(PersonBuilder pb) => pb._person;
}


class PersonAddressBuilder : PersonBuilder
{

    public PersonAddressBuilder(Person person) : base(person)
    {
    }

    public PersonAddressBuilder At(string address)
    {
        _person.StreetAddress = address;
        return this;
    }
    
    public PersonAddressBuilder In(string city)
    {
        _person.City = city;
        return this;
    }
    
    public PersonAddressBuilder WithPostCode(string postcode)
    {
        _person.Postcode = postcode;
        return this;
    }
}

class PersonJobBuilder : PersonBuilder
{
    public PersonJobBuilder(Person person) : base(person)
    {
    }

    public PersonJobBuilder At(string company)
    {
        _person.CompanyName = company;
        return this;
    }
    
    public PersonJobBuilder As(string position)
    {
        _person.Position = position;
        return this;
    }
    
    public PersonJobBuilder Earns(int annualIncome)
    {
        _person.AnnualIncome = annualIncome;
        return this;
    }
}