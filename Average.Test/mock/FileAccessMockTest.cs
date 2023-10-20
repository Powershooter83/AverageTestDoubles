namespace Average.Test.mock;

public class FileAccessMockTest {
    [Fact]
    public void WhenFileContainsNumbersThenReturnNumbersAsList() {
        var fileAccessMock = new FileAccessMock();

        Assert.Equal(new List<int> { 1, 22, 45, 0, 5, -5 }, fileAccessMock.ReadNumbers());
        Assert.Equal(new List<int> { 1, 22, 45, 0, 5, -5 }, fileAccessMock.ReadNumbers());
        Assert.Equal(new List<int> { 1, 22, 45, 0, 5, -5 }, fileAccessMock.ReadNumbers());
        Assert.Equal(3, fileAccessMock.TimesCalled());
    }
}