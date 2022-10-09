namespace DotnetDesignPatterns.SOLID;


class SingleResponsibility
{
    static void Main(string[] args)
    {
        Journal journal = new();
        
        journal.AddEntry("I did something today");
        Console.WriteLine(journal);

        var filename = "folder/filename";
        
        //Indirect functionality of journal
        journal.Save(filename);

        
        
        PersistenceManager persistenceManager = new();
        //Can be used polymorphism by using abstraction instead of journal
        persistenceManager.Save(journal, filename);
    }
}


class Journal
{
    private readonly List<string> _entries = new List<string>();

    #region Direct responsibility of Journal
    
    public void AddEntry(string text) => _entries.Add(text);

    public void RemoveEntry(int index)
    {
        if (index >= 0 && index <= _entries.Count) 
            _entries.RemoveAt(index);
    }
    
    public override string ToString()
    {
        return string.Join(Environment.NewLine, _entries);
    }
    
    #endregion
    
    #region Indirect responsibility of Journal

    //There are can several options to save file
    public void Save(string filename, bool overwrite = false) => File.WriteAllText(filename, ToString());

    public void Load(string filename)
    {
        
    }

    public void Load(Uri uri)
    {
        
    }

    #endregion
}

class PersistenceManager
{
    //verify that file exists
    private void Verify(string filename)
    {
        
    }
    
    public void Save(Journal journal, string filename, bool overwrite = false)
    {
        Verify(filename);
        File.WriteAllText(filename, journal.ToString());
    }
}