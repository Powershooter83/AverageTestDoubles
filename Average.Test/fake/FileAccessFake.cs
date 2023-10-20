namespace Average.Test.fake;

public class FileAccessFake : IFileAccess {
    private readonly Dictionary<string, int[]> _paths = new();

    public FileAccessFake(string path) {
        this.path = path;
    }

    private readonly string path;


    public void AddFakePath(string path, int[] numbers) {
        _paths.Add(path, numbers);
    }

    public List<int> ReadNumbers() {
        _paths.TryGetValue(path, out var values);

        if (values == null) {
            throw new FileNotFoundException("Die Datei existiert nicht.");
        }

        if (values.Length == 0) {
            throw new InvalidOperationException("Die Datei ist leer.");
        }

        return values.ToList();
    }
}