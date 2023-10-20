namespace Average.Test.spy;

public class FileAccessSypTest : IDisposable {
    public void Dispose() {
        File.Delete(Path.Combine(Path.GetTempPath(), "test.txt"));
    }

    [Fact]
    public void WhenFileDoesNotExistThenThrowFileNotFoundException() {
        var spy = new FileAccessSpy("test.txt");

        var exception = Assert.ThrowsAny<FileNotFoundException>(() => spy.ReadNumbers());
        Assert.Equal("Die Datei existiert nicht.", exception.Message);
        Assert.Equal(1, spy.TimesCalled());
        Assert.Empty(spy.ReturnedValues());
        Assert.Single(spy.ThrownExceptions());
    }

    [Fact]
    public void WhenFileIsEmptyThenThrowInvalidOperationException() {
        var tempFilePath = Path.Combine(Path.GetTempPath(), "test.txt");
        var writer = new StreamWriter(tempFilePath);
        writer.Write("");
        writer.Close();

        var spy = new FileAccessSpy(tempFilePath);
        var exception = Assert.ThrowsAny<InvalidOperationException>(() => spy.ReadNumbers());

        Assert.Equal("Die Datei ist leer.", exception.Message);
        Assert.Equal(1, spy.TimesCalled());
        Assert.Empty(spy.ReturnedValues());
        Assert.Single(spy.ThrownExceptions());
    }

    [Fact]
    public void WhenFileContainsNotValidCharactersThenThrowFormatException() {
        var tempFilePath = Path.Combine(Path.GetTempPath(), "test.txt");
        var writer = new StreamWriter(tempFilePath);
        writer.Write("1");
        writer.Write("a");
        writer.Close();

        var spy = new FileAccessSpy(tempFilePath);
        var exception = Assert.ThrowsAny<FormatException>(() => spy.ReadNumbers());

        Assert.Equal("Die Datei enthält ungültige Zeichen.", exception.Message);
        Assert.Equal(1, spy.TimesCalled());
        Assert.Empty(spy.ReturnedValues());
        Assert.Single(spy.ThrownExceptions());
    }

    [Fact]
    public void WhenFileContainsNumbersThenReturnNumbersAsList() {
        var tempFilePath = Path.Combine(Path.GetTempPath(), "test.txt");
        var writer = new StreamWriter(tempFilePath);
        writer.Write("1\n");
        writer.Write("2\n");
        writer.Write("445343\n");
        writer.Close();

        var spy = new FileAccessSpy(tempFilePath);
        var actual = spy.ReadNumbers();

        Assert.Equal(new List<int> { 1, 2, 445343 }, actual);
        Assert.Equal(1, spy.TimesCalled());
        Assert.Equal(spy.ReturnedValues(), actual);
        Assert.Empty(spy.ThrownExceptions());
    }
}