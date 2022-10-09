namespace DotnetDesignPatterns.SOLID;

public class DependencyInversion
{
    static void Main(string[] args)
    {
        var parent = new Person {Name = "John"};
        var child1 = new Person {Name = "Matt"};
        var child2 = new Person {Name = "Ivan"};
        RelationShips relationShips = new();
        relationShips.AddParentAndChild(parent, child1);
        relationShips.AddParentAndChild(parent, child2);
        
        
        new Research(relationShips);

        IRelationShipBrowser relationShipBrowser = relationShips;
        new Research(relationShipBrowser);
    }
}

interface IRelationShipBrowser
{
    IEnumerable<Person> FindAllChildren(string name);
}

enum RelationShip
{
    Parent,
    Child, 
    Sibling
}

class Person
{
    public string Name;
    //job
}

//low level module
class RelationShips : IRelationShipBrowser
{
    private List<(Person, RelationShip, Person)> _relations = new ();

    public void AddParentAndChild(Person parent, Person child)
    {
        _relations.Add((parent, RelationShip.Parent, child));
        _relations.Add((child, RelationShip.Child, parent));
    }

    public List<(Person, RelationShip, Person)> Relations => _relations;
    public IEnumerable<Person> FindAllChildren(string name)
    {
        return _relations.Where(x => x.Item1.Name == "John" && x.Item2 == RelationShip.Parent).Select(r => r.Item3);
    }
}

//high level module
class Research
{
    public Research(RelationShips relationShips)
    {
        var relations = relationShips.Relations;
        foreach (var relation in relations.Where(x => x.Item1.Name == "John" && x.Item2 == RelationShip.Parent))
        {
            Console.WriteLine($"John has child called {relation.Item3.Name}");
        }
    }

    public Research(IRelationShipBrowser relationShipBrowser)
    {
        var children = relationShipBrowser.FindAllChildren("John");
        foreach (var child in children)
        {
            Console.WriteLine(child.Name);
        }
    }
}