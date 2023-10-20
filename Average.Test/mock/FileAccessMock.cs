namespace Average.Test.mock;

public class FileAccessMock : IFileAccess {
    private int? _timesCalled;

    public List<int> ReadNumbers() {
        // Fancy, Null-Coalescing-Operator
        _timesCalled = (_timesCalled ?? 0) + 1;
        return new List<int> { 1, 22, 45, 0, 5, -5 };
    }

    public int? TimesCalled() {
        return _timesCalled;
    }
}