namespace Average.Test.standard;

public class FileAccessTest : IDisposable {
    public void Dispose() {
        File.Delete(Path.Combine(Path.GetTempPath(), "test.txt"));
    }

    [Fact]
    public void WhenFileDoesNotExistThenThrowFileNotFoundException() {
        var sut = new FileAccessImpl("test.txt");
        var exception = Assert.ThrowsAny<FileNotFoundException>(() => sut.ReadNumbers());

        Assert.Equal("Die Datei existiert nicht.", exception.Message);
    }

    [Fact]
    public void WhenFileIsEmptyThenThrowInvalidOperationException() {
        var tempFilePath = Path.Combine(Path.GetTempPath(), "test.txt");
        var writer = new StreamWriter(tempFilePath);
        writer.Write("");
        writer.Close();

        var sut = new FileAccessImpl(tempFilePath);
        var exception = Assert.ThrowsAny<InvalidOperationException>(() => sut.ReadNumbers());

        Assert.Equal("Die Datei ist leer.", exception.Message);
    }

    [Fact]
    public void WhenFileContainsNotValidCharactersThenThrowFormatException() {
        var tempFilePath = Path.Combine(Path.GetTempPath(), "test.txt");
        var writer = new StreamWriter(tempFilePath);
        writer.Write("1");
        writer.Write("a");
        writer.Close();

        var sut = new FileAccessImpl(tempFilePath);
        var exception = Assert.ThrowsAny<FormatException>(() => sut.ReadNumbers());

        Assert.Equal("Die Datei enthält ungültige Zeichen.", exception.Message);
    }

    [Fact]
    public void WhenFileContainsNumbersThenReturnNumbersAsList() {
        var tempFilePath = Path.Combine(Path.GetTempPath(), "test.txt");
        var writer = new StreamWriter(tempFilePath);
        writer.Write("1\n");
        writer.Write("2\n");
        writer.Write("445343\n");
        writer.Close();

        var sut = new FileAccessImpl(tempFilePath);
        Assert.Equal(new List<int> { 1, 2, 445343 }, sut.ReadNumbers());
    }
}