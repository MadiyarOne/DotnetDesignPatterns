namespace DotnetDesignPatterns.Factory;

public class AsyncFactoryExample
{
    static async Task Main(string[] args)
    {
        var foo = await AsyncFactory.Create<Foo>();

    }


}

public interface IAsyncInit<T>
{
    Task<T> InitAsync();
}

public static class AsyncFactory
{
    public static async Task<T> Create<T>() where T : IAsyncInit<T>, new()
    {
        return await new T().InitAsync();
    }
}

class Foo : IAsyncInit<Foo>
{
    //Not valid
    // public Foo()
    // {
    //     await Task.Delay(1000);
    // }

    public async Task<Foo> InitAsync()
    {
        await Task.Delay(1000);
        return this;
    }
    
    public static async Task<Foo> CreateAsync()
    {
        var result = new Foo();
        return await result.InitAsync();
    }
}