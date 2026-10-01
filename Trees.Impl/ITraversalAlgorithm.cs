namespace Trees.Impl;

public interface ITraversalAlgorithm<T>
{
    Tree<T> CurrentNode { get; }
    void AddNext(Tree<T> node);
}
