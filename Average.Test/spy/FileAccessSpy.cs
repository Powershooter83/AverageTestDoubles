namespace Average.Test.spy;

public class FileAccessSpy : IFileAccess {
    private int _counter;
    private readonly List<int> _numbers = new();
    private readonly List<Exception> _exceptions = new();
    private readonly FileAccessImpl _fileAccessImpl;

    public FileAccessSpy(string path) {
        _fileAccessImpl = new FileAccessImpl(path);
    }

    public List<int> ReadNumbers() {
        _counter++;
        List<int> readNumbers;
        try {
            readNumbers = _fileAccessImpl.ReadNumbers();
        }
        catch (Exception e) {
            _exceptions.Add(e);
            throw;
        }

        _numbers.AddRange(readNumbers);
        return readNumbers;
    }

    public int TimesCalled() {
        return _counter;
    }

    public List<int> ReturnedValues() {
        return _numbers;
    }

    public List<Exception> ThrownExceptions() {
        return _exceptions;
    }
}