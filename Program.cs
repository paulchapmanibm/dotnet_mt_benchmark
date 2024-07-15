using System;
using System.Diagnostics;
using System.Threading.Tasks;

class BenchmarkTest
{
    static async Task Main(string[] args)
    {
        int numThreads = Environment.ProcessorCount;
        Console.WriteLine($"Running benchmark on {numThreads} threads...");

        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();

        await RunBenchmark(numThreads);

        stopwatch.Stop();
        Console.WriteLine($"Total time: {stopwatch.ElapsedMilliseconds} ms");
    }

    static async Task RunBenchmark(int numThreads)
    {
        Task[] tasks = new Task[numThreads];

        for (int i = 0; i < numThreads; i++)
        {
            tasks[i] = Task.Run(() => PerformComputation());
        }

        await Task.WhenAll(tasks);
    }

    static void PerformComputation()
    {
        const int iterations = 100_000_000;
        double result = 0;

        for (int i = 0; i < iterations; i++)
        {
            result += Math.Sqrt(i) * Math.Sqrt(i);
        }

        Console.WriteLine($"Thread result: {result}");
    }
}
