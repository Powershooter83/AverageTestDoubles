namespace Average;

public class Statistics
{
    public static double Mean(List<int> numbers) {
        if (!numbers.Any()) {
            throw new ArgumentException("cannot compute mean of an empty list");
        }

        var sum = numbers.Aggregate(0.0, (current, value) => current + value);
        return sum / numbers.Count;
    }

    public static double Median(List<int> numbers) {
        if (!numbers.Any()) {
            throw new ArgumentException("cannot compute median of an empty list");
        }
        numbers.Sort();
        var middle = numbers.Count / 2;
        return numbers.Count % 2 == 0
            ? (numbers[middle - 1] + numbers[middle]) / 2.0
            : numbers[middle];
    }

    public static List<int> Mode(List<int> numbers) {
        if (!numbers.Any()) {
            throw new ArgumentException("cannot compute mode of an empty list");
        }

        var frequencies = new Dictionary<int, int>();
        foreach (var value in numbers) {
            if (frequencies.ContainsKey(value)) {
                frequencies[value]++;
                continue;
            }
            frequencies[value] = 0;
        }

        var maxN = frequencies.Values.Prepend(-1).Max();
        return frequencies.Keys.Where(key => frequencies[key] == maxN).ToList();
    }
}
