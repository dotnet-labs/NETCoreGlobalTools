using System.CommandLine;
using StatisticsToolbox.Statistics;

var sdOption = new Option<double[]>(name: "--numbers", description: "numbers.");
sdOption.AddAlias("-n");
var sdCmd = new Command("sd", "Standard Deviation of an array of numbers.")
{
    sdOption
};
sdCmd.SetHandler(numbers =>
{
    var stdDev = new StandardDeviation(numbers);
    Console.WriteLine($"Population Standard Deviation: {stdDev.Population}");
    Console.WriteLine($"    Sample Standard Deviation: {stdDev.Sample}");
}, sdOption);

var avgOption = new Option<double[]>(new[] { "--numbers", "-n" }, "numbers.");
var avgCmd = new Command("avg", "Arithmetic Average of an array of numbers.")
{
    avgOption
};
avgCmd.SetHandler(numbers =>
{
    Console.WriteLine($"Arithmetic Average: {numbers.Average()}");
}, avgOption);

var rootCommand = new RootCommand("Statistics Toolbox")
{
    sdCmd, avgCmd
};

rootCommand.Name = "stat";
rootCommand.Description = "Statistics Toolbox";

await rootCommand.InvokeAsync(args);