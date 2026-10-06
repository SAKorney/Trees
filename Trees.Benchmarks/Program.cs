using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Running;
using BenchmarkDotNet.Toolchains.InProcess.NoEmit;
using Trees.Impl;

[MemoryDiagnoser]
public class TreeBenchmark
{
    private readonly Tree<int> _root;

    public TreeBenchmark()
    {
        _root = IntTreeGenerator.Generate();
    }

    private int Traverse(IEnumerable<Tree<int>> root)
    {
        int sum = 0;
        foreach (var node in root)
        {
            sum += node.Value;
        }
        return sum;
    }

    [Benchmark]
    public int BFS() => Traverse(_root.GetBfsEnumerator());

    [Benchmark]
    public int DFS() => Traverse(_root.GetDfsEnumerator());

    [Benchmark]
    public int Rec() => Traverse(_root.GetRecEnumerator());

    [Benchmark]
    public int RecMethod() => Traverse(TreeIteratorRec.Iterate(_root));
}


public class Program
{
    public static void Main(string[] args)
    {
        var config = DefaultConfig.Instance
            .AddJob(Job
                .MediumRun
                .WithLaunchCount(1)
                .WithToolchain(InProcessNoEmitToolchain.Instance));

        var summary = BenchmarkRunner.Run<TreeBenchmark>(config);
    }
}
