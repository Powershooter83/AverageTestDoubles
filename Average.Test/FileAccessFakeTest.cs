namespace Average.Test;

public class FileAccessFakeTest {
    
    [Fact]
    public void WhenFileDoesNotExistThenThrowFileNotFoundException() {
        var sut = new FileAccessFake("test.txt");

        var exception = Assert.ThrowsAny<FileNotFoundException>(() => sut.ReadNumbers());

        Assert.Equal("Die Datei existiert nicht.", exception.Message);
    }

    [Fact]
    public void WhenFileIsEmptyThenThrowInvalidOperationException() {
        var sut = new FileAccessFake("test.txt");
        sut.AddFakePath("test.txt", Array.Empty<int>());
        var exception = Assert.ThrowsAny<InvalidOperationException>(() => sut.ReadNumbers());

        Assert.Equal("Die Datei ist leer.", exception.Message);
    }


    [Fact]
    public void WhenFileContainsNumbersThenReturnNumbersAsList() {
        var sut = new FileAccessFake("test.txt");
        sut.AddFakePath("test.txt", new[] { 1, 2, 445343 });

        var actual = sut.ReadNumbers();

        Assert.Equal(new List<int> { 1, 2, 445343 }, actual);
    }
    
}