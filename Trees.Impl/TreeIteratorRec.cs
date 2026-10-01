namespace Trees.Impl;

public class TreeIteratorRec<T> : ITreeIterator<T>
{
    public IEnumerable<Tree<T>> Iterate(Tree<T> root)
    {
        yield return root;
        foreach (var item in root.Children)
        {
            Iterate(item);
        }
    }
}
