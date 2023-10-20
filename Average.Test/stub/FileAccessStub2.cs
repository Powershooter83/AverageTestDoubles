namespace Average.Test;

public class FileAccessStub2 : IFileAccess {
    private readonly List<int> _numbers;

    public FileAccessStub2(List<int> numbers) {
        _numbers = numbers;
    }
    
    public List<int> ReadNumbers() {
        return _numbers;
    }
}