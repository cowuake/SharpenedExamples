#!/usr/bin/env dotnet-script

Random random = new Random();
List<int> sample = Enumerable.Range(1, 10).Select(x => random.Next(1, 100)).ToList();
Console.WriteLine($"Sample\n\t{{ {String.Join(", ", sample.Select(x => x.ToString()))} }}\n");

var statistics1 = ComputeStatistics(sample);
var statisticsWithName1 = (name: "Sir Statistics The First", statistics: statistics1);
PrintOutput(statisticsWithName1);

(double stat1, double stat2) statistics2 = ComputeStatistics(sample);
var statisticsWithName2 = (name: "Sir Statistics The Second", statistics: statistics2);
PrintOutput(statisticsWithName2);

(string name, (double m, double v) stats) statisticsWithName3 = ("Sir Statistics The Third", ComputeStatistics(sample));
PrintOutput(statisticsWithName3);


private static (double mean, double variance) ComputeStatistics(IEnumerable<int> sample)
{
    if (sample == null || !sample.Any())
        return (double.NaN, double.NaN);

    double mean = sample.ToList().Average();
    double variance = sample.Select(x => Math.Pow(x - mean, 2)).Sum() / sample.Count();

    return (mean, variance);
}

private static void PrintOutput((string name, (double mean, double variance) stats) statistics)
{
    Console.WriteLine(
        $"{statistics.name}\n" +
        $"\tMean:{statistics.stats.mean:F}\n" +
        $"\tVariance: {statistics.stats.variance:F}\n");
}
