namespace DotnetDesignPatterns.SOLID;

class InterfaceSegregation
{
    static void Main(string[] args)
    {
        
    }
}



class Document
{
    
}

interface IMachine
{
    void Print(Document document);
    void Fax(Document document);
    void Scan(Document document);
}

class MultiFuncMachine : IMachine
{
    public void Print(Document document)
    {
        //        
    }

    public void Fax(Document document)
    {
        //
    }

    public void Scan(Document document)
    {
        //
    }
}
//YAGNI you are not gonna need it
class OldFashionMachine : IMachine
{
    public void Print(Document document)
    {
        //ok
    }
    
    //may be
    [Obsolete("Not supported")]
    public void Fax(Document document)
    {
        //do nothing - principe of least surprise
    }
    
    [Obsolete("Not supported", true)]
    public void Scan(Document document)
    {
        throw new NotImplementedException();
    }
}

interface IPrint
{
    void Print(Document document);
}

interface IScanner
{
    void Scan(Document document);
}

interface IFax
{
    void Fax(Document document);
}

class PhotoCopier : IPrint, IScanner
{
    public void Print(Document document)
    {
        //
    }

    public void Scan(Document document)
    {
        //
    }
}


interface IMultiFuncDevice : IPrint, IScanner, IFax
{
    
}

class MultiFunctionMachine : IMultiFuncDevice
{
    private IPrint _printer;
    private IFax _fax;
    private IScanner _scanner;

    public MultiFunctionMachine(IPrint printer, IFax fax, IScanner scanner)
    {
        _printer = printer;
        _fax = fax;
        _scanner = scanner;
    }


    public void Fax(Document document)
    {
        //
    }

    public void Print(Document document)
    {
        //
    }

    public void Scan(Document document)
    {
        //
    }
}