namespace Trees.Impl;

public class Tree<T>
{
    public T Value { get; set; }
    public IEnumerable<Tree<T>> Children { get; set; } = [];
}
