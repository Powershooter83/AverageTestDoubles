namespace Average.Test;

public class FileAccessStub : IFileAccess {
    public List<int> ReadNumbers() {
        return new List<int> { 1, 22, 45, 0, 5, -5 };
    }
}