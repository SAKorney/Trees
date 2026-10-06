namespace Trees.Impl;

public class TreeIteratorRec
{
    public static IEnumerable<Tree<T>> Iterate<T>(Tree<T> root)
    {
        yield return root;
        foreach (var item in root.Children)
        {
            foreach(var subItem in Iterate(item))
                yield return subItem;
        }
    }
}
