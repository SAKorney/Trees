namespace Trees.Impl;

public interface ITreeIterator<T>
{
    IEnumerable<Tree<T>> Iterate(Tree<T> root);
}
