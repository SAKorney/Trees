namespace Trees.Impl;

public class TreeIteratorBFS<T> : ITreeIterator<T>
{
    public IEnumerable<Tree<T>> Iterate(Tree<T> root)
    {
        Queue<Tree<T>> queue = new();
        queue.Enqueue(root);
        while (queue.Count > 0)
        {
            var currNode = queue.Dequeue();
            foreach(var child in currNode.Children)
            {
                queue.Enqueue(child);
            }
            yield return currNode;
        }
    }
}
