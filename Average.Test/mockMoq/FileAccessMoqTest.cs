using Moq;

namespace Average.Test.mockMoq;

public class FileAccessMoqTest  {

    [Fact]
    public void WhenFileDoesNotExistThenThrowFileNotFoundException() {
        var mock = new Mock<IFileAccess>();
        mock.Setup(m => m.ReadNumbers()).Throws<FileNotFoundException>();

        Assert.ThrowsAny<FileNotFoundException>(() => mock.Object.ReadNumbers());
    }


    [Fact]
    public void WhenFileContainsNumbersThenReturnNumbersAsList() {
        var mock = new Mock<IFileAccess>();
        mock.Setup(m => m.ReadNumbers()).Returns(new List<int> { 1, 2, 445343 });

        Assert.Equal(new List<int> { 1, 2, 445343 }, mock.Object.ReadNumbers());
    }
}