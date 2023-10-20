namespace Average.Test;

public class FileAccessStubTest {
    [Fact]
    public void WhenFileContainsNumbersThenReturnNumbersAsList() {
        var sut = new FileAccessStub();

        Assert.Equal(new List<int> { 1, 22, 45, 0, 5, -5 }, sut.ReadNumbers());
    }

    /* Der untere Test ist lesbarer, da direkt ersichtlich ist, welche Testdaten verwendet wurden.
     Ich würde von einem Stub reden, da die Logik noch immer gänzlich fehlt.
    */

    [Fact]
    public void WhenFileContainsNumbersThenReturnNumbersAsListWithOtherStub() {
        var numbers = new List<int> { 1, 22, 45, 0, 5, -5 };

        var sut = new FileAccessStub2(numbers);

        Assert.Equal(numbers, sut.ReadNumbers());
    }
}