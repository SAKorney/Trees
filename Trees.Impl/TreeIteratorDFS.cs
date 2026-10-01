namespace Trees.Impl;

public class TreeIteratorDFS<T> : ITreeIterator<T>
{
    public IEnumerable<Tree<T>> Iterate(Tree<T> root)
    {
        Stack<Tree<T>> stack = new ();
        stack.Push(root);
        while (stack.Count > 0)
        {
            var currNode = stack.Pop();
            foreach(var child in currNode.Children)
            {
                stack.Push(child);
            }
            yield return currNode;
        }
    }
}
