namespace Trees.Impl;

public static class TreeExtensions
{
    public static IEnumerable<Tree<T>> GetDfsEnumerator<T>(this Tree<T> root)
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

    public static IEnumerable<Tree<T>> GetBfsEnumerator<T>(this Tree<T> root)
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

    public static IEnumerable<Tree<T>> GetRecEnumerator<T>(this Tree<T> root)
    {
        yield return root;
        foreach (var child in root.Children)
        {
            foreach(var item in child.GetRecEnumerator())
            {
                yield return item;
            }
        }
    }
}
