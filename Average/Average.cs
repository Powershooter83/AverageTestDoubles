namespace Average;

public class Average
{
    public Average(IFileAccess fileAccess)
    {
        this.fileAccess = fileAccess;
    }

    private readonly IFileAccess fileAccess;

    public double ComputeMeanOfFile()
    {
        var numbers = fileAccess.ReadNumbers();
        return Statistics.Mean(numbers);
    }

    public double ComputeMedianOfFile()
    {
        var numbers = fileAccess.ReadNumbers();
        return Statistics.Median(numbers);
    }

    public List<int> ComputeModeOfFile()
    {
        var numbers = fileAccess.ReadNumbers();
        return Statistics.Mode(numbers);
    }
}
