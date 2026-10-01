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

    private int Traverse(Tree<int> root, ITreeIterator<int> iterator)
    {
        int sum = 0;
        foreach (var node in iterator.Iterate(root))
        {
            sum += node.Value;
        }
        return sum;
    }

    [Benchmark]
    public int BFS() => Traverse(_root, new TreeIteratorBFS<int>());

    [Benchmark]
    public int DFS() => Traverse(_root, new TreeIteratorDFS<int>());

    [Benchmark]
    public int Rec() => Traverse(_root, new TreeIteratorRec<int>());
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
