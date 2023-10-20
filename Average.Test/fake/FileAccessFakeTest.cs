namespace Average.Test.fake;

public class FileAccessFakeTest {
    [Fact]
    public void WhenFileDoesNotExistThenThrowFileNotFoundException() {
        var fileAccessFake = new FileAccessFake("test.txt");

        var exception = Assert.ThrowsAny<FileNotFoundException>(() => fileAccessFake.ReadNumbers());

        Assert.Equal("Die Datei existiert nicht.", exception.Message);
    }

    [Fact]
    public void WhenFileIsEmptyThenThrowInvalidOperationException() {
        var fileAccessFake = new FileAccessFake("test.txt");
        fileAccessFake.AddFakePath("test.txt", Array.Empty<int>());
      
        var exception = Assert.ThrowsAny<InvalidOperationException>(() => fileAccessFake.ReadNumbers());

        Assert.Equal("Die Datei ist leer.", exception.Message);
    }


    [Fact]
    public void WhenFileContainsNumbersThenReturnNumbersAsList() {
        var fileAccessFake = new FileAccessFake("test.txt");
        fileAccessFake.AddFakePath("test.txt", new[] { 1, 2, 445343 });

        var actual = fileAccessFake.ReadNumbers();

        Assert.Equal(new List<int> { 1, 2, 445343 }, actual);
    }
}