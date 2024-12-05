namespace Common;

public interface IFileParsingStrategy<out TResult>
{
    TResult Parse();
}

public abstract class AbstractParsingStrategy<T>(string filename) : IFileParsingStrategy<T>, IDisposable, IAsyncDisposable
{
    protected readonly FileStream _stream = File.Open(filename, FileMode.Open);

    public virtual T Parse() { throw new NotImplementedException(); }

    public void Dispose()
    {
        _stream.Dispose();
    }

    public async ValueTask DisposeAsync()
    {
        await _stream.DisposeAsync();
    }
}
